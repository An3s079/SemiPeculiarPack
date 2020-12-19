using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemiPeculiarPack
{
    class CoolerHeart : PassiveItem
    {
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Health,
            amount = 1,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };

        public StatModifier Modifier2 = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Coolness,
            amount = 4,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.ownerlessStatModifiers.Add(Modifier);
            player.ownerlessStatModifiers.Add(Modifier2);
            player.stats.RecalculateStats(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.ownerlessStatModifiers.Remove(Modifier);
            player.ownerlessStatModifiers.Remove(Modifier2);
            player.stats.RecalculateStats(player);
            return base.Drop(player);
        }
    }
}
