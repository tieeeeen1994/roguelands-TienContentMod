using GadgetCore.API;
using HarmonyLib;
using MoreCombatChips.Services;
using UnityEngine;

namespace MoreCombatChips.Patches
{
    [HarmonyPatch(typeof(ItemStandScript))]
    [HarmonyPatch("GetChip")]
    [HarmonyGadget("More Combat Chips")]
    public static class Patch_ItemStandScript_GetChip
    {
        [HarmonyPrefix]
        public static bool Prefix(ItemStandScript __instance, ref int __result)
        {
            if (__instance.isAdvanced)
            {
                int randNum = Random.Range(0, 100);
                if (randNum < 3)
                {
                    __result = ChipManagementService.RandomlyGetIDFromAdvanced();
                    MoreCombatChips.Log($"Generating Item Stand with Chip ID {__result}");
                    return false;
                }
            }

            return true;
        }
    }
}