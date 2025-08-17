using HarmonyLib;


namespace LoveLoveSchoolDays_Patcher
{

    [HarmonyPatch(typeof(PlayerMapChecker), "IsWithNear")]
    class God1Patch
    {
        private static void Postfix(ref bool __result)
        {
            __result = false;
        }
    }
}

