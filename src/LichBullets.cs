using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemiPeculiarPack
{
    class LichBullets : PassiveItem
    {
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.DamageToBosses,
            amount = 1.5f,
            modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
        };

        public StatModifier Modifier2 = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Curse,
            amount = 3,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };
        public void PostProcessProjectile(Projectile proj, float f)
        {
            proj.ignoreDamageCaps = true;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.PostProcessProjectile += this.PostProcessProjectile;
            player.ownerlessStatModifiers.Add(Modifier);
            player.ownerlessStatModifiers.Add(Modifier2);
            player.stats.RecalculateStats(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.PostProcessProjectile -= this.PostProcessProjectile;
            player.ownerlessStatModifiers.Remove(Modifier);
            player.ownerlessStatModifiers.Remove(Modifier2);
            player.stats.RecalculateStats(player);
            return base.Drop(player);
        }
    }
}
