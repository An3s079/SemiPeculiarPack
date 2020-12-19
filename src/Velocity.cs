using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SemiPeculiarPack
{
    class Velocity : PassiveItem
    {
        bool IsSpedUp = false;
        private void OnKilledEnemy(PlayerController player, HealthHaver enemy)
        {
            if (IsSpedUp == false)
            {
                player.ownerlessStatModifiers.Add(Modifier);
                Owner.stats.RecalculateStats(Owner, false, false);
                IsSpedUp = true;
                StartCoroutine(RemoveSpeed(player));
            }
        }
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.MovementSpeed,
            amount = 1.4f,
            modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
        };
        IEnumerator RemoveSpeed(PlayerController player)
        {
            yield return new WaitForSecondsRealtime(3);
            ReturnNormalSpeed(player);

        }
        void ReturnNormalSpeed(PlayerController player)
        {
            player.ownerlessStatModifiers.Remove(Modifier);
            Owner.stats.RecalculateStats(Owner, false, false);
            IsSpedUp = false;
        }
        public override void Pickup(PlayerController player)
        {
            player.OnKilledEnemyContext += OnKilledEnemy;
            base.Pickup(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.OnKilledEnemyContext -= OnKilledEnemy;
            return base.Drop(player);
        }
    }
}
