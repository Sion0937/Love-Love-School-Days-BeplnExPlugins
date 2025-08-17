
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.FastTravelShowPlugin", "FastTravelShowPlugin", "1.0")]
    class FastTravelShowPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<string> FastTravelShowContent;
        UseItemFastTravel fastTravel;
        void Start()
        {
            FastTravelShowContent = Config.Bind<string>("config", "按T键打开快速传送", "Unused", "便捷快速传送");
        }
        void Update()
        {
            if (SingletonMonoBehaviour<GameManager>.Instance != null && SingletonMonoBehaviour<GameManager>.Instance.state == GameManager.GAME_STATE.PLAY)
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.T))
                {
                    if (fastTravel == null)
                    {

                        fastTravel = UseItemFastTravel.FindObjectOfType<UseItemFastTravel>();
                        Logger.LogInfo($"尝试获取快速传送实例，结果：{!(fastTravel is null)}");
                        fastTravel?.Use();

                    }
                    else
                    {
                        fastTravel.Use();
                    }
                }
            }

        }
    }
}
