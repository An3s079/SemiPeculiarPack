using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SemiPeculiarPack
{
    class FearBullets : BulletStatusEffectItem
    {
        private static FleePlayerData fleeData;

        public void PostProcessProjectile(Projectile proj, float f)
        {
            proj.OnHitEnemy += this.OnHitEnemy;

        }
        private void OnHitEnemy(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
        {
            if (UnityEngine.Random.value <= 0.3)
            {
                enemy.aiActor.behaviorSpeculator.FleePlayerData = FearBullets.fleeData;
                FleePlayerData fleePlayerData = new FleePlayerData();
                GameManager.Instance.StartCoroutine(FearBullets.RemoveFear(enemy.aiActor));
            }

        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.PostProcessProjectile += this.PostProcessProjectile;
            bool flag = FearBullets.fleeData == null || FearBullets.fleeData.Player != player;
            if (flag)
            {
                FearBullets.fleeData = new FleePlayerData();
                FearBullets.fleeData.Player = player;
                FearBullets.fleeData.StartDistance = 500f;
            }
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.PostProcessProjectile -= this.PostProcessProjectile;
            return base.Drop(player);
        }

        private static IEnumerator RemoveFear(AIActor aiactor)
        {
            yield return new WaitForSeconds(3f);
            aiactor.behaviorSpeculator.FleePlayerData = null;
            yield break;
        }
    }
   
}
