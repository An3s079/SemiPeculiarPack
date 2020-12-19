using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemiPeculiarPack
{
    class CleansingWater : PlayerItem
    {
        public CleansingWater()
        {
            consumable = true;
        }
        protected override void DoEffect(PlayerController user)
        {
            float Curse = user.stats.GetStatValue(PlayerStats.StatType.Curse);
            if (CanBeUsed(user) && Curse <= 9)
            {
                StatModifier statModifier = new StatModifier();
                user.ownerlessStatModifiers.Add(statModifier);
                statModifier.statToBoost = PlayerStats.StatType.Curse;
                statModifier.amount = (Curse * -1);
                statModifier.modifyType = StatModifier.ModifyMethod.ADDITIVE;
                user.stats.RecalculateStats(user, false, false);
                AkSoundEngine.PostEvent("Play_UI_secret_reveal_01", base.gameObject);
            }
        }

        public override bool CanBeUsed(PlayerController user)
        {
            float Curse = user.stats.GetStatValue(PlayerStats.StatType.Curse);

            return Curse > 0 && Curse < 10;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
    }
}
