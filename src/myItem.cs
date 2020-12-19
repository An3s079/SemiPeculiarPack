using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemiPeculiarPack
{
	public class myItem : PassiveItem
	{
		public StatModifier Modifier = new StatModifier
		{
			statToBoost = PlayerStats.StatType.Health,
			amount = 2,
			modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
		};

		public override void Pickup(PlayerController player)
		{
			base.Pickup(player);

			player.ownerlessStatModifiers.Add(Modifier);
			player.stats.RecalculateStats(player);
		}

		public override DebrisObject Drop(PlayerController player)
		{
			player.ownerlessStatModifiers.Remove(Modifier);
			player.stats.RecalculateStats(player);

			return base.Drop(player);
		}
	}
}
