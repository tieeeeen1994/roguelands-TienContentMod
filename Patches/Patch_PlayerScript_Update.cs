﻿using GadgetCore.API;
using GadgetCore.Util;
using HarmonyLib;
using MoreCombatChips.ID;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace MoreCombatChips.Patches
{
    /// <summary>
    /// This will modify behavior in PlayerScript.Update.
    /// </summary>
    [HarmonyPatch(typeof(PlayerScript))]
    [HarmonyPatch("Update")]
    [HarmonyGadget("More Combat Chips")]
    public static class Patch_PlayerScript_Update
    {
        private static FieldInfo CurAugment
        {
            get => typeof(Menuu).GetField("curAugment", BindingFlags.Static | BindingFlags.Public);
        }

        private static FieldInfo Fspd
        {
            get => typeof(PlayerScript).GetField("fspd", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> insns, ILGenerator il)
        {
            var p = TranspilerHelper.CreateProcessor(insns, il);
            if (MoreCombatChips.EyepodHatChange)
            {
                var ilRefs = p.FindAllRefsByInsns(new List<CodeInstruction>
                {
                    new CodeInstruction(OpCodes.Ldsfld, CurAugment),
                    new CodeInstruction(OpCodes.Ldc_I4_S, (byte)AugmentID.EyepodHat),
                    new CodeInstruction(OpCodes.Bne_Un),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Ldc_I4_0),
                    new CodeInstruction(OpCodes.Stfld, Fspd)
                });
                if (ilRefs.Length == 0)
                {
                    MoreCombatChips.Log("Patch_PlayerScript_Update: Could not find any reference point.");
                }
                else
                {
                    foreach (var ilRef in ilRefs)
                    {
                        p.RemoveInsns(ilRef, 6);
                    }
                }
            }
            return p.Insns;
        }
    }
}
