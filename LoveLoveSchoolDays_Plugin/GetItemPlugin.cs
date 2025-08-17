using BepInEx;
using BepInEx.Configuration;
using EasySelect;
using UnityEngine;


namespace LoveLoveSchoolDays_Plugin
{
    [BepInPlugin("Sion0937.plugin.LoveLoveSchoolDays.GetItemPlugin", "GetItemPlugin", "1.0")]
    class GetItemPlugin : BaseUnityPlugin
    {     
        static EasySelectInventoryCore items;
        static ConfigEntry<int> itemsAddSetting;
        static ConfigDescription configDescription;
        void Start()
        {
            configDescription = new ConfigDescription(
                "44 箭头		    100 Recovery			20 蓝色液体\n" +
                          "8 炸药            34 火焰骑士模型           45 绿草盆栽\n" +
                          "30 面包           52 网络直播摄像头         42 快速传送\n" +
                          "56 眼药水         61 网络直播麦克风          12 油桶\n" +
                          "27 尖叫玩偶        19 粉色寻呼机             25 钱包\n" +
                          "50 直播混音台      17 未解锁的硬盘           37 壁咚杂志\n" +
                          "26 能量饮料        49 Emiiri修复芯片        35 天台钥匙\n" +
                          "3 USB             14 榔头                 21 粉色液体\n" +
                          "24 手机           36 照相机                10 乐谱\n" +
                          "6 闹钟            5 体育馆钥匙              28 泳池阀门\n" +
                          "39 基友传送装置    40 保险箱修复芯片          13 灭火器\n" +
                          "48图书馆莎尤里的心  38 碰撞修复脚本           32 心跳回忆\n" +
                          "3 大脑            54 运动俱乐部卡           7 引线雷管\n" +
                          "31 基友修护芯片     29 维修室房卡            21 红花盆栽", new AcceptableValueRange<int>(-1, 100));
            itemsAddSetting = Config.Bind<int>("config", "输入物品ID并按U添加", -1, configDescription);
        }
        void Update()
        {
            if (SingletonMonoBehaviour<GameManager>.Instance != null && SingletonMonoBehaviour<GameManager>.Instance.state == GameManager.GAME_STATE.PLAY)
            {

                if (UnityEngine.Input.GetKeyDown(KeyCode.U))
                {
                    if (items == null)
                    {
                        items = EasySelectInventoryCore.Instance;
                        Logger.LogInfo($"尝试获取EasySelectInventoryCore实例，结果：{!(items is null)}");
                        items?.AddItem(itemsAddSetting.Value, 1);
                    }
                    else
                    {
                        items.AddItem(itemsAddSetting.Value, 1);
                    }
                }              
            }

        }
    }
}
