using EasySelect;
using BepInEx.Configuration;
using BepInEx;
using HarmonyLib;
using UnityEngine;


namespace LoveLoveSchoolDays_Plugin
{
    class Debugg_unused
    {
        static PasscodeLockTool passcode;
        static EasySelectInventoryCore itemGet;
        //if (UnityEngine.Input.GetKeyDown(KeyCode.B))
        //{
        //    if (items == null)
        //    {
        //        items = EasySelectInventoryCore.Instance;
        //        Logger.LogInfo($"尝试获取EasySelectInventoryCore实例，结果：{!(items is null)}");
        //    }
        //    else
        //    {
        //        //查看当前拥有的物品的iditemsAddSetting
        //        foreach (var item in items.itemList)
        //        {
        //            Logger.LogInfo($"ItemID:{item.itemID}, Value:{item.value}");
        //        }
        //        Logger.LogInfo("\n");
        //    }
        //}

        //if (UnityEngine.Input.GetKeyDown(KeyCode.K))
        //{
        //    if (passcode == null)
        //    {
        //        passcode = PasscodeLockTool.FindAnyObjectByType<PasscodeLockTool>();//进入卧室才行
        //        Logger.LogInfo($"尝试获取PasscodeLockTool实例，结果：{!(items is null)}");
        //    }
        //    else
        //    {
        //        //查看卧室保险箱的所有密码
        //        foreach (var Pcode in passcode.passCodeList)
        //        {
        //            Logger.LogInfo($"code:{Pcode.code}");
        //        }
        //        Logger.LogInfo("\n");
        //    }
        //}
    }
}
