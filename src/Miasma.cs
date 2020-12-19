using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungeonator;
using UnityEngine;
using Semi;

namespace SemiPeculiarPack
{
    class Miasma : PassiveItem
    {
        private void OnEnemyKilled(PlayerController player, HealthHaver enemy)
        {
            RoomHandler currentRoom = player.CurrentRoom;
            if (enemy.specRigidbody != null && enemy.aiActor != null && base.Owner != null)
            {
                foreach (AIActor aiactor in currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
                {
                    bool flag3 = aiactor.behaviorSpeculator != null;
                    if (flag3)
                    {
                        float distance = Vector3.Distance(enemy.aiActor.transform.position, aiactor.transform.position);
                        if (distance <= 7f)
                        {

                            aiactor.ApplyEffect(Gungeon.Items["irradiated_lead"].GetComponent<BulletStatusEffectItem>().HealthModifierEffect);
                        }
                    }
                }
            }
        }



        public override void Pickup(PlayerController player)
        {
            player.OnKilledEnemyContext += this.OnEnemyKilled;
            base.Pickup(player);
        }


        public override DebrisObject Drop(PlayerController player)
        {
            DebrisObject debrisObject = base.Drop(player);
            player.OnKilledEnemyContext -= this.OnEnemyKilled;
            return base.Drop(player);
        }
    }
}
