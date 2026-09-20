#if   Il2Cpp
using Il2CppScheduleOne.Delivery;
using Il2CppScheduleOne.Property;
#elif Mono
using ScheduleOne.Delivery;
using ScheduleOne.Property;
#endif
using MelonLoader;
using System;
using System.Collections.Generic;

namespace ImprovedPackagers
{
    public enum EDirection { Dual_Direction, Unload_Only, Load_Only }

    public class ImprovedPackagers : MelonMod
    {
        public const string ModName = "Improved Packagers PORTED";
        public const string Version = "2.0.2";
        public const string Author = "GuysWeForgotDre | Ported by GSVS UK ACM";
        public const string ModDesc = "PORTED for Schedule I f13: enables Packagers to unpack product and load vehicles parked in Loading Bays";
        public const string BuildIdentity = "f13-logging-rc2";

        private MelonPreferences_Category PropertyGroup;
        private static MelonPreferences_Entry<bool> ExtendedLoggingPreference;
        private static bool LastExtendedLoggingValue;
#if Il2Cpp
        private readonly List<MelonPreferences_Entry<EDirection>> LoadingBayPrefs = new List<MelonPreferences_Entry<EDirection>>();
        private const EDirection prefDefault = EDirection.Dual_Direction;
#elif Mono
        private readonly List<MelonPreferences_Entry<bool>> LoadingBayPrefs = new List<MelonPreferences_Entry<bool>>();
        private const bool prefDefault = true;
#endif
        private static readonly Dictionary<string, ImprovedPackagers> AllProperties = new Dictionary<string, ImprovedPackagers>();

        internal static bool ExtendedLoggingEnabled => ExtendedLoggingPreference?.Value ?? false;

        public override void OnInitializeMelon()
        {
            // Mod Manager & Phone App associates categories by matching the
            // whitespace-free Melon name at the start of the category ID.
            var category = MelonPreferences.CreateCategory("ImprovedPackagersPORTED", ModName);
            ExtendedLoggingPreference = category.CreateEntry(
                "ExtendedLogging",
                false,
                "Extended Logging",
                "Write detailed station state, worker selection and transit diagnostics to the MelonLoader log.");
            LastExtendedLoggingValue = ExtendedLoggingEnabled;
        }

        public override void OnLateInitializeMelon()
        {
            ReflectionHelper.Initialize();
            StationModeRegistry.Load();
            StartupBanner.Print();
            MelonLogger.Msg($"Compatibility build {BuildIdentity} loaded.");
            MelonLogger.Msg($"Extended Logging is {(ExtendedLoggingEnabled ? "enabled" : "disabled")}.");
        }

        public override void OnDeinitializeMelon()
        {
            ReflectionHelper.Deinitialize();
            StationModeRegistry.ClearAll();
        }

        internal static void NotifyPreferencesSaved()
        {
            bool current = ExtendedLoggingEnabled;
            if (current == LastExtendedLoggingValue) return;

            LastExtendedLoggingValue = current;
            RuntimeTrace.Reset();
            MelonLogger.Msg($"Extended Logging {(current ? "enabled" : "disabled")}.");
        }

        public static ImprovedPackagers AddLoadingDocks(Property property)
        {
            string name = property.PropertyName;
            ImprovedPackagers prefs = new ImprovedPackagers { PropertyGroup = MelonPreferences.CreateCategory($"PackagersLoadVehicles_{name}", name) };

            foreach (LoadingDock dock in property.LoadingDocks)
                prefs.LoadingBayPrefs.Add(prefs.PropertyGroup.CreateEntry(dock.Name.Replace(" ", ""), default_value: prefDefault, dock.Name));
            return prefs;
        }

        public static void AddProperty(Property property)
        {
            if (property.LoadingDockCount == 0 || AllProperties.TryGetValue(property.PropertyName, out _)) return;
            AllProperties.Add(property.PropertyName, AddLoadingDocks(property));
        }

#if Il2Cpp
        public static EDirection GetDockStatus(string property, string dock)
#elif Mono
        public static bool GetDockStatus(string property, string dock)
#endif
        {
            if (AllProperties.TryGetValue(property, out ImprovedPackagers docks))
                foreach (var pref in docks.LoadingBayPrefs)
                    if (pref.DisplayName == dock)
                        return pref.Value;

            return prefDefault;
        }
    }
}
