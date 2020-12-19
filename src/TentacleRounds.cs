using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SemiPeculiarPack
{
    class TentacleRounds : BulletStatusEffectItem
    {
        public GameObject TelefragVFXPrefab;
        public static List<AIActor> CurrentlyTentacledEnemies = new List<AIActor>() { };

        public void PostProcessProjectile(Projectile proj, float f)
        {

            proj.OnHitEnemy += this.OnHitEnemy;

        }

        private void PostProcessBeamTick(BeamController beam, SpeculativeRigidbody hitRigidBody, float tickrate)
        {

            float procChance = 0.12f;
            GameActor gameActor = hitRigidBody.gameActor;
            if (!gameActor)
            {
                return;
            }
            else if (!CurrentlyTentacledEnemies.Contains(hitRigidBody.aiActor))
            {
                if (UnityEngine.Random.value < BraveMathCollege.SliceProbability(procChance, tickrate))
                {

                    EatCharmedEnemy(hitRigidBody.aiActor);
                    CurrentlyTentacledEnemies.Add(hitRigidBody.aiActor);
                }
            }

        }
        public void DelayedDestroyEnemy(AIActor enemy)
        {
            this.TelefragVFXPrefab = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Tentacleport");
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.TelefragVFXPrefab);
            gameObject.GetComponent<tk2dBaseSprite>().PlaceAtLocalPositionByAnchor(enemy.sprite.WorldCenter, tk2dBaseSprite.Anchor.MiddleCenter);
            gameObject.transform.position = gameObject.transform.position.Quantize(0.0625f);
            gameObject.GetComponent<tk2dBaseSprite>().UpdateZDepth();
            if (enemy)
            {
                StartCoroutine(deleteEnemy(enemy));

            }
        }

        private void EatCharmedEnemy(AIActor a)
        {
            if (!a)
            {
                return;
            }
            if (a.behaviorSpeculator)
            {
                a.behaviorSpeculator.Stun(2f, true);
                StartCoroutine(WaitForStun(a));
            }
            if (a.knockbackDoer)
            {
                a.knockbackDoer.SetImmobile(true, "YellowChamberItem");
            }

        }


        IEnumerator WaitForStun(AIActor a)
        {
            yield return new WaitForSeconds(0.3f);
            DelayedDestroyEnemy(a);
        }

        private void OnHitEnemy(Projectile proj, SpeculativeRigidbody enemy, bool fatal)
        {
            if (!CurrentlyTentacledEnemies.Contains(enemy.aiActor) && !enemy.aiActor.healthHaver.IsBoss && !fatal)
            {
                if (UnityEngine.Random.value <= 0.1 && !fatal)
                {

                    EatCharmedEnemy(enemy.aiActor);
                    CurrentlyTentacledEnemies.Add(enemy.aiActor);
                }
            }
        }

        IEnumerator deleteEnemy(AIActor enemy)
        {
            yield return new WaitForSeconds(1.3f);
            enemy.EraseFromExistenceWithRewards(false);
        }



        public void OnEnemyDamaged(float damage, bool fatal, HealthHaver enemy)
        {
            if (fatal && Owner.CurrentGun.PickupObjectId == 474)
            {
                Owner.CurrentGun.GainAmmo(5);
            }
        }

        public override void Pickup(PlayerController player)
        {
            player.PostProcessBeamTick += this.PostProcessBeamTick;
            player.PostProcessProjectile += this.PostProcessProjectile;
            player.OnAnyEnemyReceivedDamage += this.OnEnemyDamaged;
            base.Pickup(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.PostProcessBeamTick -= this.PostProcessBeamTick;
            player.PostProcessProjectile -= this.PostProcessProjectile;
            player.OnAnyEnemyReceivedDamage -= this.OnEnemyDamaged;
            return base.Drop(player);
        }

    }
}
