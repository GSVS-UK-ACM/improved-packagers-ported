# IMPROVED PACKAGERS PORTED

> **✅ WORKS WITH THE NEW SPECIAL CUSTOMERS UPDATE — SCHEDULE I 0.4.7f12**
> Version 2.0.2 has been rebuilt and play-tested on the current IL2CPP release.

> **The original Improved Packagers, restored for Schedule I 0.4.7f12 IL2CPP.**
> Original mod by **GuysWeForgotDre** · Compatibility port maintained by **GSVS UK ACM**

Your Packaging Stations can package *and* unpackage. Your employees should be able to do the same.

Improved Packagers PORTED restores the original mod's full workflow on the current 0.4.7f12 IL2CPP build: assigned Packagers follow each station's selected mode, operate unpacking jobs, collect the loose product and deliver it through the normal management routes. It also preserves the original vehicle-loading feature for vans parked at Loading Bays.

This is a compatibility port—not a replacement claim over the original work. **GuysWeForgotDre created Improved Packagers and remains credited as its original author.** GSVS UK ACM maintains this port so the mod remains usable while the game and its APIs continue to change.

---

## At a glance

- **Unpackage automatically:** assigned Packagers can break down baggies, jars and bricks.
- **Follow the station mode:** workers respect the Package/Unpackage selection on each assigned Packaging Station.
- **Complete the whole job:** workers operate the station, collect its loose output and deliver it to configured storage through the game's normal transit system.
- **Load vehicles:** use management routes to move products from storage or equipment into vehicles parked at Loading Bays.
- **Control every bay:** set each Loading Bay to **Load Only**, **Unload Only** or **Dual Direction**.
- **Keep vanilla rules:** item filters, stack sizes, slot compatibility, worker assignments and ordinary route mechanics still apply.
- **Made for the new update:** verified Harmony targets, IL2CPP types, station state handling and transit-slot routing for Schedule I 0.4.7f12.
- **Quiet by default:** detailed diagnostics now sit behind an optional Extended Logging setting in Mod Manager.

---

## Requirements

You need all three of the following:

1. **Schedule I 0.4.7f12 — IL2CPP/main branch**
2. **MelonLoader 0.7.0 Open-Beta**
3. **Mod Manager & Phone App — REQUIRED**  
   https://www.nexusmods.com/schedule1/mods/397

> **Mod Manager & Phone App is required, not merely recommended.** It provides the in-game Mod Manager and configuration screens used by this release.

The IL2CPP and legacy Mono builds are not interchangeable. Version 2.0.2 makes no new Mono compatibility claim.

---

## Installation

1. **Close Schedule I completely.**
2. Open the game's installation directory, then open its `Mods` folder.
3. Remove every older/original Improved Packagers DLL. Look specifically for:
   - `ImprovedPackagers.dll`
   - `ImprovedPackagersPORTED.dll`
   - `Main-ImprovedPackagers.dll`
4. Install MelonLoader and the required Mod Manager & Phone App if they are not already present.
5. Extract `ImprovedPackagersPORTED.dll` from this download into `Schedule I/Mods`.
6. Launch the game, open the in-game Mod Manager and confirm **Improved Packagers PORTED** is enabled.

> **Only keep one Improved Packagers DLL installed. Do not run the original release and PORTED release together.**

The correct setup shows `ImprovedPackagersPORTED.dll` and `ModManager&PhoneApp.dll` in the game's `Mods` folder. On launch, MelonLoader identifies the mod as **Improved Packagers PORTED** and credits both the original author and port maintainer.

---

## Using automatic unpacking

1. Place and configure a Packaging Station.
2. Select **Unpackage** mode and choose/load the product you want to break down.
3. Assign a Handler/Packager to that station using the management clipboard.
4. Configure the station's destination route as you normally would for employee transit.
5. Ensure the destination has room and accepts the selected product.

The worker can load and unpack **baggies, jars or bricks**. Packaged items are loaded into the station's physical Output slot—the same slot used by manual unpacking—and the loose result is collected from the Product slot. Leftover baggies in the Packaging slot no longer block brick unpacking and are left untouched. Once the cycle completes, the worker collects the loose product and delivers it using the configured route.

Station-mode choices are persisted in `UserData/ImprovedPackagers.json`. Opening or changing a station records its explicit selection; on a fresh setup, the port can also infer the mode when exactly one work mode is ready.

Detailed station, worker-selection and transit diagnostics are available through **Extended Logging** in Mod Manager. It defaults to off and can be changed while the game is running, keeping ordinary logs clean.

---

## Loading vehicles

Improved Packagers also allows employee routes to use the storage inside vehicles parked at Loading Bays.

- **Load Only:** workers can place routed items into the vehicle but will not unload it.
- **Unload Only:** retains the normal unload workflow without adding vehicle input slots.
- **Dual Direction:** allows both loading and unloading and remains the default.

Configure each Loading Bay from Mod Manager & Phone App. Loading Bay preferences are stored in `UserData/MelonPreferences.cfg`.

Normal filters, stack sizes and route rules are preserved. Be deliberate with **Dual Direction** routes: two Packagers configured in opposite directions can move the same items back and forth.

---

## Compatibility and testing

Version **2.0.2** was built specifically against **Schedule I 0.4.7f12 IL2CPP** and play-tested through the complete workflow:

- assigned worker selects the unpack-mode station;
- worker loads and operates the station;
- station produces loose output;
- worker collects that output;
- worker delivers it to the configured destination;
- the cycle repeats instead of stopping after one operation.
- brick unpacking continues with the Packaging slot partially filled or full of leftover baggies.

The port uses the game's native grab, walk, placement, locking and behaviour-completion flow rather than replacing employee movement with a custom simulation. The exact published DLL is the play-tested build.

Because Schedule I is actively developed, a future game update may change these APIs again. If the game version shown here no longer matches yours, check the maintained source/release page before reporting a fault.

---

## Troubleshooting

### The mod does not appear

- Confirm the file is exactly `Schedule I/Mods/ImprovedPackagersPORTED.dll`.
- Confirm MelonLoader 0.7.0 Open-Beta is installed and loading.
- Confirm Improved Packagers PORTED is enabled in Mod Manager.

### Both the original and PORTED versions appear

Close the game, remove every Improved Packagers DLL from `Mods`, then install only `ImprovedPackagersPORTED.dll`.

### The worker stands at the station or completes only one cycle

- Confirm the station is assigned to that worker.
- Confirm the station is set to Unpackage and has compatible input.
- Confirm its destination route is valid, has capacity and accepts the output product.
- Confirm you are using the exact 0.4.7f12 IL2CPP release named on this page.

### The log says “Undefined target method”

The installed DLL was built for a different Schedule I version. Remove it and install the release matching your game build.

### First launch mentions a missing `ImprovedPackagers.json`

That message indicates an older build is still installed. Version 2.0.2 creates its configuration cleanly on first use.

When reporting a reproducible issue, include your Schedule I version, MelonLoader version, mod list and `MelonLoader/Latest.log` on the maintained GitHub issue tracker.

---

## Why the name says PORTED

The original release predates breaking changes in Schedule I's IL2CPP APIs. **PORTED** appears in the page title, in-game Mod Manager, DLL filename and log tag so players can instantly distinguish this compatibility build from the original and avoid loading both at once.

The port updates compatibility and restores the affected worker workflow. It does not erase or reassign authorship of the original mod.

---

## Credits, source and licence

### Original project

**Improved Packagers** was created by **GuysWeForgotDre** and was formerly called *Packagers Load Vehicles*.

- Original Nexus page: https://www.nexusmods.com/schedule1/mods/1142
- Original source: https://github.com/GuysWeForgotDre/Improved-Packagers
- Original author contact shown by the project: Discord `OnlyMurdersSometimes` · GitHub `GuysWeForgotDre`

### Compatibility port

The Schedule I 0.4.7f12 IL2CPP port is maintained by **GSVS UK ACM**.

- Maintained source, releases and issue tracker: https://github.com/xboxnuker-rgb/improved-packagers-ported

The original project is open source under the **MIT License**, which permits modification and redistribution while retaining its copyright and licence notice. This upload includes the original `LICENSE.txt`, an explicit `NOTICE.txt`, complete source history and prominent original-author credit. It is an independently maintained compatibility port and is not presented as an official release by the original author. Contact was attempted through Discord and GitHub before publication; no response had been received at the time this page was prepared.

Routing insight was adapted from an earlier contribution by **ecrgr** (upstream PR #2), then rewritten against the current APIs and tested as part of this port.

### Development disclosure

Codex was used as an AI-assisted development and documentation tool during the compatibility investigation. All changes were human-directed, source-reviewed, compiled and repeatedly validated in game. The listing uses Nexus Mods' **AI-Generated Content** tag to disclose that assistance accurately; the mod contains no generated visual, audio or dialogue assets.

---

## Version 2.0.2 — Special Customers update

- Updated and verified the IL2CPP port for Schedule I 0.4.7f12.
- Corrected worker input routing so packaged bricks, jars and baggies enter the station's physical Output slot in Unpackage mode.
- Corrected brick readiness when leftover baggies remain in the Packaging slot; existing baggies are untouched.
- Preserved safe vanilla packaging-capacity checks for jar and baggie unpacking.
- Added an **Extended Logging** Mod Manager setting for detailed diagnostics without normal log spam.
- Retained the tested worker selection, station operation, loose-product pickup, destination delivery and vehicle-loading workflows.

If this port saves your production line, leave a useful bug report, screenshot or endorsement—the best support is helping keep the compatibility information accurate for the next player.

