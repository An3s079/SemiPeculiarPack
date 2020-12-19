using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using Dungeonator;

namespace SemiPeculiarPack
{
    class LeatherJacket : PassiveItem
    {
        private static FleePlayerData fleeData;
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Coolness,
            amount = 3,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };

        protected override void Update()
        {

            base.Update();
            if (base.Owner.HasPassiveItem(290))
            {
                RoomHandler currentRoom = base.Owner.CurrentRoom;
                foreach (AIActor aiactor in currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
                {
                    bool flag3 = aiactor.behaviorSpeculator != null;
                    if (flag3)
                    {
                        aiactor.behaviorSpeculator.FleePlayerData = LeatherJacket.fleeData;
                        FleePlayerData fleePlayerData = new FleePlayerData();
                        GameManager.Instance.StartCoroutine(LeatherJacket.RemoveFear(aiactor));
                    }

                }
            }
        }

        private static IEnumerator RemoveFear(AIActor aiactor)
        {

            yield return new WaitForSeconds(3f);
            aiactor.behaviorSpeculator.FleePlayerData = null;
            yield break;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            bool flag = LeatherJacket.fleeData == null || LeatherJacket.fleeData.Player != player;
            if (flag)
            {
                LeatherJacket.fleeData = new FleePlayerData();
                LeatherJacket.fleeData.Player = player;
                LeatherJacket.fleeData.StartDistance = 6f;
            }
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
