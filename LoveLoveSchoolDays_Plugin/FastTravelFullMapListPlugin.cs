using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;


namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.FastTravelFullMapListPlugin", "FastTravelFullMapListPlugin", "1.0")]
    class FastTravelFullMapListPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> FastTravelFullMapListConfig;
        void Awake()
        {
            FastTravelFullMapListConfig = Config.Bind<bool>("config", "快速传送解锁所有地图", false, "快速传送解锁所有地图");
        }

    }
    public class FastTravelFullMapListPatcher
    {
        public static void DoPatching()
        {
            var harmony = new Harmony("Sion0937.plugin.LoveLoveSchoolDays.FastTravelFullMapListPlugin");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(FastTravelView), "Show")]
    class FastTravelFullMapListPatch
    {
        private static bool FastTravelFullMapListConfig => FastTravelFullMapListPlugin.FastTravelFullMapListConfig.Value;
        private static bool Prefix(FastTravelView __instance)
        {
            if (FastTravelFullMapListConfig)
            {
                __instance.isDebug = true;
            }
            return true;
        }
        private static void Postfix(FastTravelView __instance)
        {
            if (FastTravelFullMapListConfig)
            {
                __instance.isDebug = false;
            }
        }
    }
}
