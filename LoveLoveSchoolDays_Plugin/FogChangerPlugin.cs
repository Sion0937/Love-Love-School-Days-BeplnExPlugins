using BepInEx;
using BepInEx.Configuration;
using UnityEngine;


namespace LoveLoveSchoolDays_Plugin
{
    //插件描述特性 分别为 插件ID 插件名字 插件版本(必须为数字)
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.FogChangerPlugin", "FogChangerPlugin", "1.0")]
    public class FogChangerPlugin : BaseUnityPlugin
    {
        ConfigEntry<bool> FogConfig;
        void Start()
        {
            //绑定时有4个参数，分别是 分类 Key 默认值 描述
            FogConfig = Config.Bind<bool>("config", "使用环境雾?", true, "玩家视野的黑雾控制");
            if (RenderSettings.fog != FogConfig.Value)
            {
               FogConfig.Value = RenderSettings.fog;
                Logger.LogInfo($"初始设置环境雾启用：{RenderSettings.fog}");
            }
        }
        void Update()
        {
            if (RenderSettings.fog != FogConfig.Value)
            {
                RenderSettings.fog = FogConfig.Value;
                Logger.LogInfo($"当前环境雾启用：{RenderSettings.fog}");
            }
        }
    }
}
