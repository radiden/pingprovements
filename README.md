# Pingprovements

This is an updated version of [pixeldesu](https://github.com/pixeldesu)'s Pingprovements mod. All credits go to them.

This mod has been ~~hacked together~~ carefully assembled to work again on the latest version of the game (when the first DLC came out). It might break very fast. I don't know.

# Original README

A mod that improves pings in Risk of Rain 2 in several different ways.

## Features

- Allows multiple pings by the same player
- Colors pings by the tier of the target
- Configurable lifetimes for all ping types
- Configurable colors for all ping types
- Show labels for ping targets (instead of just chat messages)
- Show the distance to pings
- Show a notification on item pings containing the item description (like pickup notifications) if the item has already been discovered
- Hide offscreen ping labels

## Installation

Simply copy `Pingprovements.dll` to your BepInEx plugin folder.

## Configuration

After the game has been started with the mod installed once, you will have a config file available with following options:

- `Durations`
    - `DefaultPingLifetime`: Lifetime of the default walk ping in seconds (Default: `6`)
    - `EnemyPingLifetime`: Lifetime of the enemy ping in seconds (Default: `8`)
    - `InteractablePingLifetime`: Lifetime of the interactable ping in seconds (Default: `30`)
- `Colors`
    - `DefaultPingColor`: Color of the default ping text (Default: `0.525,0.961,0.486,1.000`)
    - `EnemyPingColor`: Color of the enemy ping text (Default: `0.820,0.122,0.122,1.000`)
    - `InteractablePingColor`: Color of the interactable ping text (Default: `0.886,0.871,0.173,1.000`)
    - `TieredInteractablePingColor`: Color pings in their target tier color (Default: `true`)
- `SpriteColors`
    - `DefaultPingSpriteColor`: Color of the default ping sprite (Default: `0.527,0.962,0.486,1.000`)
    - `EnemyPingSpriteColor`: Color of the enemy ping sprite (Default: `0.821,0.120,0.120,1.000`)
    - `InteractablePingSpriteColor`: Color of the interactable ping sprite (Default: `0.887,0.870,0.172,1.000`)
- `ShowPingText`
    - `Chests`: Shows item names and cost on chest pings (Default: `true`)
    - `ShopTerminals`: Shows item names and cost on shop terminal pings (Default: `true`)
    - `Drones`: Shows drone type on broken drone pings (Default: `true`)
    - `Shrines`: Shows shrine type on shrine pings (Default: `true`)
    - `Pickups`: Shows item names on pickup pings (Default: `true`)
    - `Enemies`: Show names on enemy pings (Default: `true`)
    - `Distance`: Show the distance to made pings (Default: `true`)
    - `HideOffscreenPingText`: Hides the ping label if the ping goes offscreen (Default: `true`)
- `Notifications`
    - `ShowItemNotification`: Show pickup-style notification with description on ping of an already discovered item (Default: `true`)

This mod overrides the internal `fixedTimer` for pings after it has been built, so no special conditions like teleporter or shrine pings will change the time for `InteractablePingLifetime`.

## Changelog

### 1.8.0

- **Feature:** Now functions! And uses the in game functions for creating notifications!

### 1.7.0

- **Feature:** Ping Indicators on interactables are now colored in their game-defined tier color. This is enabled by default, but can be adjusted with the new `TieredInteractablePingColor` option in the `Colors` section! If the option is enabled and a tier cannot be found properly, it'll fall back to using `InteractablePingColor`.

**Notes on Ping Colors:** These ping colors are not chosen by me, these are the colors the game defines. This might be a bit jarring considering the Shrine of Combat/Shrine of the Mountain feature a very bright pink.

### 1.6.3

- **Bugfix:** Add another null reference check because apparently users lose their bodies sometimes.
- **Code Quality:** Major refactor splitting mod functionality in more subclasses to ease feature development for later.

### 1.6.2

- **Bugfix:** Add another null reference check that caused per-frame error output with some mod combinations.

### 1.6.1

- **Task:** Rebuild with the 1.0 Release assemblies.

### 1.6.0

- **Bugfix:** Fixed "interactible" typo to "interactable", as it should be everywhere.
- **Bugfix:** Fixed configuration parsing being broken for non-english languages that don't use "." as default float delimiter. Thanks to [ric20007](https://github.com/ric20007) for this contribution.

**Upgrade:** Configuration values don't migrate on change, so the "new" Interactable* values have the default configuration values. Just copy the old values to the new ones in the configuration file!

### 1.5.1

- **Bugfix:** Missing null reference check caused movement pings to be persistent all time (since they flatout broke).

### 1.5.0

- **Task:** Update to latest BepInExPack version and convert to new configuration format to mitigate several issues.

**Upgrade:** Download and install the latest [BepInExPack from Thunderstore](https://thunderstore.io/package/bbepis/BepInExPack/).
If there are any issues with configuration loading, which there shouldn't be, delete your configuration and run Risk of Rain 2 once.

### 1.4.3

- **Feature:** Support pinging known artifacts for an item notification.
- **Task:** Rebuild with newest Content Update assemblies.

### 1.4.2

- **Bugfix:** Fixed pings on barrels persisting even after a barrel has been opened.

### 1.4.1

- **Task:** Rebuild with newest Content Update assemblies.

### 1.4.0

- **Feature:** Ping Indicators on items now can show a pickup-like notification that shows the item name and description, if the item is already present in your logbook. This new option is enabled by default, and a new `Notifications` section with a `ShowItemNotification` option has been added to the configuration.

### 1.3.1

- **Bugfix:** Fixed override for `fixedTimer` on anything that wasn't a `PurchaseInteraction`.

### 1.3.0

- **Feature:** Enemies also have been enabled for `ShowPingText`, with a new option `Enemies` having been added for them.
- **Feature:** Ping labels also have the ability to show the distance from the player to a ping now. It can be enabled or disabled with the configuration option `Distance` in `ShowPingText`. Thanks to [underscorea for their PingDistance mod](https://thunderstore.io/package/underscorea/PingDistance/) that this feature is inspired from.
- **Feature:** To declutter the screen from the many labels that are now possible to be shown, a new option `HideOffscreenPingText` has been added to `ShowPingText`. If enabled, it will hide the text for any ping outside of the player viewport, the icons are still shown!
- **Code Quality:** Major refactor splitting code in multiple classes.

### 1.2.0

- **Feature:** Ping Indicators now can be enabled to show a label of what has been pinged, akin the chat messages, a new `ShowPingText` configuration category has been added for this. Thanks to [mltnhm](https://github.com/mltnhm) for this addition! Following configuration values are available:
    - `Chests`
    - `ShopTerminals`
    - `Drones`
    - `Shrines`
    - `Pickups`
- **Code Quality:** Instead of using several private `Color` instances, we now utilize a Dictionary for these.
- **Bugfix:** We now prevent pings being created at `0,0,0` because in most cases, this is not possible to happen. This was happening when a previously unpinged area was pinged.

### 1.1.0

- **Feature:** Ping Indicator colors are now customizable! The following new configuration variables are available:
    - `DefaultPingColor`
    - `DefaultPingSpriteColor`
    - `EnemyPingColor`
    - `EnemyPingSpriteColor`
    - `InteractiblePingColor`
    - `InteractiblePingSpriteColor`
- **Improvement:** Configuration is now split into three different sections `Colors`, `SpriteColors` and `Durations`.
- **Code Quality:** Removed superfluous cast to `int` for `PingIndicator.PingType` checks and directly cast to that enum type now.

**Upgrade:** _(applies to any version before 1.1.0)_  
The config section for lifetimes has changed, rename it from `Main` to `Durations` for your old settings to carry over!

### 1.0.1

- **Bugfix:** Fix issue where creating a ping on an object that already has been pinged, but the ping has been destroyed since, didn't work.

### 1.0.0

- Initial Release
