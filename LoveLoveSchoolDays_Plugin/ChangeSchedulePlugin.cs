using BepInEx;
using BepInEx.Configuration;
using UnityEngine;


namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.ChangeSchedulePlugin", "ChangeSchedulePlugin", "1.0")]
    class ChangeSchedulePlugin : BaseUnityPlugin
    {
        static ScheduleManager ScheduleChanger;
        static ConfigEntry<string> ChangeScheduleConfig;
        void Start()
        {
            ChangeScheduleConfig = Config.Bind<string>("config","按K换下一个课程", "Unused", "立即切换课程");
        }
        void Update()
        {
            if (SingletonMonoBehaviour<GameManager>.Instance != null && SingletonMonoBehaviour<GameManager>.Instance.state == GameManager.GAME_STATE.PLAY)
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.K))
                {
                    if (ScheduleChanger == null)
                    {
                        ScheduleChanger = ScheduleManager.Instance;
                        ScheduleChanger?.ChangeSchedule();
                    }
                    else
                    {
                        ScheduleChanger.ChangeSchedule();
                    }
                }
            }
        }
    }
}
