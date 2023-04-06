# Changelog

All notable changes to this project will be documented in this file. See
[Conventional Commits](https://conventionalcommits.org) for commit guidelines.

# [2.0.0-develop.1](https:/home/circleci/project/semantic-release-remote/compare/v1.4.0...v2.0.0-develop.1) (2023-04-06)


### Bug Fixes

* always call context.completeRequest, even when not returning a value ([9cabb03](https:/home/circleci/project/semantic-release-remote/commit/9cabb03495b089cdc23fb257a0c3fea7e603c225))
* **ci:** speculative fix for Homebrew failing on CI ([4b12ce4](https:/home/circleci/project/semantic-release-remote/commit/4b12ce4d1501eaea92ee76c1e11fc808ccc7ad11))
* **ci:** update VS Mac installer script for 17.4 ([9221e1e](https:/home/circleci/project/semantic-release-remote/commit/9221e1e68a0c5cb8e35777c914fd9e17e954a5d7))
* **common:** make session immediately so we don't miss the first message ([d53d5c8](https:/home/circleci/project/semantic-release-remote/commit/d53d5c8a9dd02563c5e75208cfc7125386d5f85a))
* **common:** remove `EventAwaiter(EventHandler<T>, ...` ([9032a01](https:/home/circleci/project/semantic-release-remote/commit/9032a013c8b5dc967f5a53a50546499b55af6b55))
* disable BLE restore to fix 'Bluetooth unavailable' issue ([8fdc3d1](https:/home/circleci/project/semantic-release-remote/commit/8fdc3d166edb6fb49b25ed2f467a0f77227dc630))
* dispose of cbManager on session shutdown ([5423e78](https:/home/circleci/project/semantic-release-remote/commit/5423e7800ba21bdb50874d23a88d0cee64c2c54d))
* don't embed IOBluetooth.framework ([563070d](https:/home/circleci/project/semantic-release-remote/commit/563070d67e5a88cc96a196759f2d2b59b0f4706b))
* **extension:** inject project marketing version into web extension manifest ([6aa609d](https:/home/circleci/project/semantic-release-remote/commit/6aa609d100961b7f74f4345c28137393988a2835))
* fix DisposedException by removing cancellation token ([eed937f](https:/home/circleci/project/semantic-release-remote/commit/eed937fd185f58295733e63dc8879a32e5a5ee10))
* fix minor MAS compliance issues ([149076c](https:/home/circleci/project/semantic-release-remote/commit/149076c07aa6c6e725e09130ee23a397b3e6e9eb))
* implement a BT connection dance that works on macOS 10 and 12 ([159ca00](https:/home/circleci/project/semantic-release-remote/commit/159ca006789956de12e4282b2d088217eb5bb17a))
* **Mac:** add real Bluetooth permissions request messages ([39cdf3c](https:/home/circleci/project/semantic-release-remote/commit/39cdf3cd509a1c475dbc80b08d919607a6ac1f22))
* **Mac:** add real icons for Safari extension ([f081c71](https:/home/circleci/project/semantic-release-remote/commit/f081c7130d97a86f55259bd76eef4fdd51bd1856))
* **MacBLE:** allow more time for the Bluetooth state to settle ([d2c1cf9](https:/home/circleci/project/semantic-release-remote/commit/d2c1cf97845060e88a00d69a66c13580abb7c74e))
* **macBLE:** fix 'API MISUSE' log message ([b46f435](https:/home/circleci/project/semantic-release-remote/commit/b46f4359f6ed9feb8734cfbc66d9936af6303201))
* **macBLE:** handle UpdatedState even if it fires during CBCentralManager ctor ([d2df409](https:/home/circleci/project/semantic-release-remote/commit/d2df40995861311b02875c03c2f2151038e3c8e5))
* **macBT:** add 'Options' / PIN instructions to pairing dialog ([d58f5d2](https:/home/circleci/project/semantic-release-remote/commit/d58f5d243aeafb7756c987350b439b698c7eaa7d))
* **MacBT:** dispose of inquiry & channel properly ([b3c48ef](https:/home/circleci/project/semantic-release-remote/commit/b3c48ef1662a93776e68181a5e745a4b88b9670d))
* **MacBT:** make BT disconnect/reconnect more reliable, especially after pairing ([53bbe3b](https:/home/circleci/project/semantic-release-remote/commit/53bbe3b6e39fc9b27bf11119c888c4b36a39771c))
* **macBT:** poll to reliably detect RFCOMM channel open ([d42cfdb](https:/home/circleci/project/semantic-release-remote/commit/d42cfdb63751ce511f2053ff4130e2a41b99a751))
* **Mac:** correct target macOS version ([71e7a13](https:/home/circleci/project/semantic-release-remote/commit/71e7a1303397c7138604131c89bbdcf5793adc9a))
* **Mac:** embed Safari helper extension into the Scratch Link app bundle ([9c6bb30](https:/home/circleci/project/semantic-release-remote/commit/9c6bb30273b4597e1e3ddd451167cffe6231a854))
* **Mac:** fix Safari, especially Link->Client notifications ([5bae1ea](https:/home/circleci/project/semantic-release-remote/commit/5bae1ea319dd96eed6a92074a1ba59ecdaca89ca))
* **mac:** fix tccd error message about kTCCServiceAppleEvents ([bdfc8c0](https:/home/circleci/project/semantic-release-remote/commit/bdfc8c08a6caae205e599b9cca28aedc627d1589))
* **Mac:** hide Safari extensions for non-MAS builds ([58138c5](https:/home/circleci/project/semantic-release-remote/commit/58138c5c89d17ff6d4dfd40d1bfa3ad95c88f27b))
* **Mac:** make sure GetSettledBluetoothState() doesn't miss an event ([124b6a0](https:/home/circleci/project/semantic-release-remote/commit/124b6a0cef58bd027249656ac4d183f76454d8f5))
* **Mac:** properly Dispose() of the status bar item ([4cb46b5](https:/home/circleci/project/semantic-release-remote/commit/4cb46b56588d74cd8cf54e79f36a7a6fafe53f59))
* **Mac:** remove browser_action popup ([9717935](https:/home/circleci/project/semantic-release-remote/commit/971793558fdf949622c79e28db93dd43083c8938))
* **Mac:** Safari extension improvements ([14f9f99](https:/home/circleci/project/semantic-release-remote/commit/14f9f99b8cb25e7704e53f31f6589f7205b4c66a))
* **Mac:** show Safari extension menu only if supported ([d019142](https:/home/circleci/project/semantic-release-remote/commit/d01914241789fc639def818f8553799b2915c198))
* make CI robust against VS updates ([950d3de](https:/home/circleci/project/semantic-release-remote/commit/950d3deb307226403b537874cadb1f64d2886ac6))
* make didDiscoverPeripheral a notification ([e51fa01](https:/home/circleci/project/semantic-release-remote/commit/e51fa01b799fcc2c9030a66c4bfe448f4aabbc08))
* **menu:** 'Manage Safari Extensions' => 'Manage Safari Extensions...' ([dc5c481](https:/home/circleci/project/semantic-release-remote/commit/dc5c48127842be5e3f756f077a0d1e284d1002e8))
* more BT connection tweaks ([7a1e0d0](https:/home/circleci/project/semantic-release-remote/commit/7a1e0d014a05f3af968d998c2caf888987501618))
* resolve crash on session close while connecting ([32f8981](https:/home/circleci/project/semantic-release-remote/commit/32f89814873eb19045cffcfe40a3c96f70bce54b))
* **Safari:** add timeout for initial connection ([e1c9de0](https:/home/circleci/project/semantic-release-remote/commit/e1c9de00f1dbf55c1da8bd2bd935f23015b34450))
* **Safari:** close session if Scratch Link goes away ([83f85f0](https:/home/circleci/project/semantic-release-remote/commit/83f85f028996d12e2a7d6f2b6c4f93608d60bef8))
* **safari:** don't cause Safari to steal focus for every Scratch Link -> page message ([f17184f](https:/home/circleci/project/semantic-release-remote/commit/f17184f5a1e163232a0ee76133cd2953bb382a0d))
* **version:** embed GitVersion info correctly and document version scheme ([6501e49](https:/home/circleci/project/semantic-release-remote/commit/6501e49073ac852e71ccd048973fb7b5a383c506))
* **webextension:** close session on client unload ([caac99e](https:/home/circleci/project/semantic-release-remote/commit/caac99e9c0fa15a940642dc5c9063dba45a40b5f))
* **webextension:** keep Safari sessions alive for longer than 5 seconds ([4981508](https:/home/circleci/project/semantic-release-remote/commit/498150869982c3d21f5463cf646e337fd789b970))
* **webextension:** limit number of outstanding poll requests ([c5137bb](https:/home/circleci/project/semantic-release-remote/commit/c5137bb7a06c1701592669196508ae9b26ee97be))
* work around macOS 12 OpenRfcommChannelSync timeout ([68e7efc](https:/home/circleci/project/semantic-release-remote/commit/68e7efc069e8188dd7ee4d0b0e5deff43d7bdd14))


### chore

* clean slate for Scratch Link 2.0 ([f30cff3](https:/home/circleci/project/semantic-release-remote/commit/f30cff3e5b0fbd2fda423e8609cbd6576c45131a))


### Features

* **MacBT:** display pairing help when connecting to unpaired peripheral ([feb100e](https:/home/circleci/project/semantic-release-remote/commit/feb100e3c0e40ce34759246ca27b247ecbb201fc))
* **Safari:** inject client script into page if script ID is present ([9bc1ef4](https:/home/circleci/project/semantic-release-remote/commit/9bc1ef433ced60b1dc40dc68d0ffe833ce137199))


### BREAKING CHANGES

* Scratch Link 2.0 will drop support for some older
versions of macOS.