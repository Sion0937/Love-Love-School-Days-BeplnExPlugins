using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace LoveLoveSchoolDays_Plugin
{

    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.God1Plugin", "God1Plugin", "1.0")]
    public class God1Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> God1Config;
        void Awake()
        {
            Logger.LogInfo("God1Plugin开始加载");
            God1Config = Config.Bind<bool>("config", "美少女无视玩家?", false, "如果正在被追击，则逃脱追击后生效。\n启用时会导致一些事件无法触发");
            God1Patcher.DoPatching();
            Logger.LogInfo("God1Plugin加载完成");
        }
    }
    public class God1Patcher
    {
        public static void DoPatching()
        {
            var harmony = new Harmony("Sion0937.plugin.LoveLoveSchoolDays.God1Plugin");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(PlayerMapChecker), "IsWithNear")]
    class God1Patch
    {
        private static bool God1Config => God1Plugin.God1Config.Value;
        private static void Postfix(ref bool __result)
        {
            if (__result && __result != !God1Config)
            {
                __result = !God1Config;
            }
        }
    }


}
