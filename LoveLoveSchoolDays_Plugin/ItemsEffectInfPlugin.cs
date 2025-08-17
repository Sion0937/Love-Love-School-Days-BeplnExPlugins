using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;


namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.ItemsEffectInfPlugin", "ItemsEffectInfPlugin", "1.0")]
    class ItemsEffectInfPlugin : BaseUnityPlugin
    {

        public static ConfigEntry<bool>  ItemsEffectInfConfig;
        void Awake()
        {
            Logger.LogInfo("ItemsEffectPlugin开始加载");
            ItemsEffectInfConfig = Config.Bind<bool>("config", "道具持续时间无穷?", false, "");
            ItemsEffectInfPatcher.DoPatching();
            Logger.LogInfo("ItemsEffectPlugin加载完成");
        }

    }
    public class ItemsEffectInfPatcher
    {
        public static void DoPatching()
        {
            var harmony = new Harmony("Sion0937.plugin.LoveLoveSchoolDays.ItemsEffectInfPlugin");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(ItemEffectData), "Update")]
    class ItemsEffectInfPatch
    {
        private static bool ItemsEffectInfConfig => ItemsEffectInfPlugin.ItemsEffectInfConfig.Value;
        private static bool Prefix(ItemEffectData __instance)
        {
            if (ItemsEffectInfConfig)
            {
                __instance.timerCount = 0;
            }
            return true;
        }
    }
}
