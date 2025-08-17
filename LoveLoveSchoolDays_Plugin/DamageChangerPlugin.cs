using BepInEx.Configuration;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.DamageChangerPlugin", "DamageChangerPlugin", "1.0")]
    class DamageChangerPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> DamageEnableConfig;
        static PlayerLife playerLife;
        void Awake()
        {
            //绑定时有4个参数，分别是 分类 Key 默认值 描述
            DamageEnableConfig = Config.Bind<bool>("config", "被美少女攻击时玩家扣血?", true, "控制被美少女攻击时玩家是否扣血");
            Logger.LogInfo("DamageChanger1Plugin加载完成");
        }
        void Update()
        {
            if (SingletonMonoBehaviour<GameManager>.Instance != null && SingletonMonoBehaviour<GameManager>.Instance.state == GameManager.GAME_STATE.PLAY)
            {
                if (playerLife == null)
                {
                    playerLife = PlayerLife.FindObjectOfType<PlayerLife>();
                }
                else
                {
                    if (playerLife.damageEnabled != DamageEnableConfig.Value)
                    {
                        playerLife.damageEnabled = DamageEnableConfig.Value;
                    }
                }
            }
        }
    }
}
