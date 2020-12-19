using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungeonator;
using System.Collections;
using UnityEngine;

namespace SemiPeculiarPack
{
    class ThreateningAura : PlayerItem
    {
        private static FleePlayerData fleeData;
        public ThreateningAura()
        {
            consumable = false;
            roomCooldown = 0;
            damageCooldown = 0f;
            timeCooldown = 27f;
        }

        protected override void DoEffect(PlayerController user)
        {

            RoomHandler currentRoom = user.CurrentRoom;
            foreach (AIActor aiactor in currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
            {
                bool flag3 = aiactor.behaviorSpeculator != null;
                if (flag3)
                {
                    aiactor.behaviorSpeculator.FleePlayerData = ThreateningAura.fleeData;
                    FleePlayerData fleePlayerData = new FleePlayerData();
                    GameManager.Instance.StartCoroutine(ThreateningAura.RemoveFear(aiactor));
                }
            }
        }
        private static IEnumerator RemoveFear(AIActor aiactor)
        {

            yield return new WaitForSeconds(6f);
            aiactor.behaviorSpeculator.FleePlayerData = null;
            yield break;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            ThreateningAura.fleeData = new FleePlayerData();
            ThreateningAura.fleeData.Player = player;
            ThreateningAura.fleeData.StartDistance = 9f;
          
        }
    }
}
