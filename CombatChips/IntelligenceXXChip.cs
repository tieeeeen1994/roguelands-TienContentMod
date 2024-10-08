﻿using GadgetCore.API;
using TienContentMod.Services;

namespace TienContentMod.CombatChips
{
    public class IntelligenceXXChip : CombatChip
    {
        public override ChipType Type => ChipType.PASSIVE;

        public override string Name => "Intelligence XX";

        public override string Description => "+24 Intelligence";

        public override EquipStats Stats => StatService.EquipStats(MAG: 24);

        public override bool Advanced => true;
    }
}