using Fleck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace scratch_link
{
    public class App : ApplicationContext
    {
        public const int SDMPort = 20110;

        private static class SDMPath
        {
            public const string BLE = "/scratch/ble";
            public const string BT = "/scratch/bt";
        }

        private readonly NotifyIcon _icon;
        private readonly WebSocketServer _server;
        private readonly SortedDictionary<string, SessionManager> _sessionManagers;

        public App()
        {
            Application.ApplicationExit += new EventHandler(Application_Exit);

            var appAssembly = typeof(App).Assembly;
            var simpleVersionString = $"{scratch_link.Properties.Resources.AppTitle} {appAssembly.GetName().Version}";
            _icon = new NotifyIcon
            {
                Icon = scratch_link.Properties.Resources.NotifyIcon,
                Text = scratch_link.Properties.Resources.AppTitle,
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items =
                    {
                        new ToolStripMenuItem(simpleVersionString, null, OnAppVersionClicked) {
                            ToolTipText = "Copy version to clipboard"
                        },
                        new ToolStripSeparator(),
                        new ToolStripMenuItem("E&xit", null, OnExitClicked)
                    },
                    ShowItemToolTips = true
                }
            };

            _sessionManagers = new SortedDictionary<string, SessionManager>
            {
                [SDMPath.BLE] = new SessionManager(webSocket => new BLESession(webSocket)),
                [SDMPath.BT] = new SessionManager(webSocket => new BTSession(webSocket))
            };
            foreach (var sessionManager in _sessionManagers.Values)
            {
                sessionManager.ActiveSessionCountChanged += new EventHandler(UpdateIconText);
            }

            var certificate = GetWssCertificate();
            _server = new WebSocketServer($"wss://0.0.0.0:{SDMPort}", false)
            {
                RestartAfterListenError = true,
                Certificate = certificate,
                EnabledSslProtocols =
                    System.Security.Authentication.SslProtocols.Tls |
                    System.Security.Authentication.SslProtocols.Tls11 |
                    System.Security.Authentication.SslProtocols.Tls12
            };
            _server.ListenerSocket.NoDelay = true;

            try
            {
                _server.Start(OnNewSocket);
            }
            catch (SocketException e)
            {
                switch (e.SocketErrorCode)
                {
                    case SocketError.AddressAlreadyInUse:
                        OnAddressInUse();
                        break;
                    default:
                        throw;
                }
            }

            UpdateIconText(this, null);
        }

        private byte[] DecryptBuffer(byte[] encrypted)
        {
            const int bufferSize = 4096;

            using (MemoryStream decrypted = new MemoryStream())
            {
                var aes = Aes.Create();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = ServerConstants.Key;
                aes.IV = ServerConstants.IV;

                var decryptor = aes.CreateDecryptor();
                using (var encryptedStream = new MemoryStream(encrypted.Reverse().ToArray()))
                {
                    using (var cryptoStream = new CryptoStream(encryptedStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var decryptedStream = new MemoryStream())
                        {
                            var buffer = new byte[bufferSize];
                            int count;
                            while ((count = cryptoStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                decryptedStream.Write(buffer, 0, count);
                            }
                            return decryptedStream.ToArray();
                        }
                    }
                }
            }
        }

        private X509Certificate2 GetWssCertificate()
        {
            var certificateBytes = DecryptBuffer(ServerConstants.EncodedPFX);
            var certificate = new X509Certificate2(certificateBytes, "Scratch");
            return certificate;
        }

        private void OnAddressInUse()
        {
            PrepareToClose();

            using (var dialog = new Dialogs.AddressInUse())
            {
                dialog.ShowDialog();
            }

            Environment.Exit(1);
        }

        private void OnAppVersionClicked(object sender, EventArgs e)
        {
            var appAssembly = typeof(App).Assembly;
            var informationalVersionAttribute =
                appAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            var versionDetails = string.Join(Environment.NewLine,
                $"{scratch_link.Properties.Resources.AppTitle} {informationalVersionAttribute.InformationalVersion}",
                Environment.OSVersion.Platform
            );

            Clipboard.SetText(versionDetails);
            _icon.ShowBalloonTip(5000, "Version information copied to clipboard", versionDetails, ToolTipIcon.Info);
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            PrepareToClose();
            Environment.Exit(0);
        }

        private void PrepareToClose()
        {
            _icon.Visible = false;
            _server.Dispose();
        }

        private void OnNewSocket(IWebSocketConnection websocket)
        {
            var sessionManager = _sessionManagers[websocket.ConnectionInfo.Path];
            if (sessionManager != null)
            {
                sessionManager.ClientDidConnect(websocket);
            }
            else
            {
                // TODO: reply with a message indicating that the client connected to an unknown/invalid path
                // See https://github.com/statianzo/Fleck/issues/199
                websocket.OnOpen = () => websocket.Close();
                Debug.Print($"Client tried to connect to unknown path: {websocket.ConnectionInfo.Path}");
            }
        }

        internal void UpdateIconText(object sender, EventArgs e)
        {
            int totalSessions = _sessionManagers.Values.Aggregate(0,
                (total, sessionManager) =>
                {
                    return total + sessionManager.ActiveSessionCount;
                }
            );

            string text = scratch_link.Properties.Resources.AppTitle;
            if (totalSessions > 0)
            {
                text += $"{Environment.NewLine}{totalSessions} active {(totalSessions == 1 ? "session" : "sessions")}";
            }
            _icon.Text = text;
        }

        private void Application_Exit(object sender, EventArgs args)
        {
            PrepareToClose();
        }
    }
}
