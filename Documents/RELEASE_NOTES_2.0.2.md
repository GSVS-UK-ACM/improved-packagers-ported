# Improved Packagers PORTED v2.0.2

> ✅ **Works with the new Schedule I 0.4.7f12 Special Customers update.**

This release updates the maintained IL2CPP compatibility port and publishes the exact DLL that passed the complete in-game unpack and delivery test.

## What changed

- Updated and verified every required Harmony/API target against Schedule I 0.4.7f12.
- Corrected worker input routing so packaged bricks, jars and baggies enter the station's physical Output slot in Unpackage mode.
- Corrected brick unpacking when leftover baggies remain in the Packaging slot; those baggies are left untouched.
- Preserved vanilla capacity and compatibility checks for jar and baggie unpacking.
- Added an optional **Extended Logging** setting in Mod Manager. It defaults to off so normal logs stay concise.
- Retained unpacked-product delivery and Loading Bay vehicle-loading support.

## Installation

1. Close Schedule I.
2. Remove any original or older Improved Packagers DLL from the game's `Mods` folder.
3. Extract `ImprovedPackagersPORTED.dll` from the download into `Schedule I/Mods`.
4. Install the required **Mod Manager & Phone App** if it is not already present.
5. Launch the game and confirm **Improved Packagers PORTED** is enabled.

Do not install the original Improved Packagers and Improved Packagers PORTED together.

## Credit

Improved Packagers was created by **GuysWeForgotDre**. This compatibility port is maintained by **GSVS UK ACM** under the original MIT licence.
