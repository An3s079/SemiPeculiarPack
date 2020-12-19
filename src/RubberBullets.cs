using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemiPeculiarPack
{
    class RubberBullets : PassiveItem
    {
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.RangeMultiplier,
            amount = 1.5f,
            modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
        };

        public StatModifier Modifier2 = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Damage,
            amount = -0.2f,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };

        public StatModifier Modifier3 = new StatModifier
        {
            statToBoost = PlayerStats.StatType.AdditionalShotBounces,
            amount = 1,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.ownerlessStatModifiers.Add(Modifier);
            player.ownerlessStatModifiers.Add(Modifier2);
            player.ownerlessStatModifiers.Add(Modifier3);
            player.stats.RecalculateStats(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.ownerlessStatModifiers.Remove(Modifier);
            player.ownerlessStatModifiers.Remove(Modifier2);
            player.ownerlessStatModifiers.Remove(Modifier3);
            player.stats.RecalculateStats(player);
            return base.Drop(player);
        }
    }
}
