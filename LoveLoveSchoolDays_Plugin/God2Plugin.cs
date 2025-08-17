using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;


namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.God2Plugin", "God2Plugin", "1.0")]
    class God2Plugin : BaseUnityPlugin
    {
        public static ZintaimokeiAI mokeoAI;
        public static ConfigEntry<bool> God2Config;
        void Awake()
        {
            Logger.LogInfo("God2Plugin开始加载");
            God2Config = Config.Bind<bool>("config", "模型无视玩家?", false, "如果正在被追击，则逃脱追击后生效。");
            God1Patcher.DoPatching();
            Logger.LogInfo("God2Plugin加载完成");
        }

        void Update()
        {
            if (SingletonMonoBehaviour<GameManager>.Instance != null && SingletonMonoBehaviour<GameManager>.Instance.state == GameManager.GAME_STATE.PLAY)
            {
                if (mokeoAI == null)
                {
                    mokeoAI = ZintaimokeiAI.FindObjectOfType<ZintaimokeiAI>();
                    //Logger.LogInfo($"尝试获取模型实例，结果：{!(mokeoAI is null)}");
                }
                else
                {
                    if (mokeoAI.sensor.activeSelf != !God2Config.Value)
                    {
                        mokeoAI.sensor.gameObject.SetActive(!God2Config.Value);
                        Logger.LogInfo($"当前模型传感器的状态：{mokeoAI.sensor.activeSelf}");
                    }
                }
            }
        }
    }
}
