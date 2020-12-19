using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SemiPeculiarPack
{
    class OldWarStealthKit : PassiveItem
    {
        private bool isStealth;
        public void OnReceivedDamage(PlayerController player)
        {
            if (UnityEngine.Random.value <= 0.4f && isStealth == false)
            {
                isStealth = true;
                player.ownerlessStatModifiers.Add(Modifier);
                Owner.stats.RecalculateStats(Owner, false, false);
                this.HandleStealth(player);
            }
        }
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.MovementSpeed,
            amount = 1.4f,
            modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
        };

        private void HandleStealth(PlayerController player)
        {
            AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", base.gameObject);
            player.ChangeSpecialShaderFlag(1, 1f);
            player.SetIsStealthed(true, "smoke");
            player.SetCapableOfStealing(true, "StealthItem", null);
            player.specRigidbody.AddCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.EnemyHitBox, CollisionLayer.EnemyCollider));

            player.OnItemStolen += this.BreakStealthOnSteal;
            StartCoroutine(WaitaSec(player));
        }
        IEnumerator WaitaSec(PlayerController player)
        {

            yield return new WaitForSecondsRealtime(3);
            player.OnDidUnstealthyAction += this.BreakStealth;
        }

        public void BreakStealth(PlayerController player)
        {
            isStealth = false;
            player.OnDidUnstealthyAction -= this.BreakStealth;
            player.OnItemStolen -= this.BreakStealthOnSteal;
            player.specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.EnemyHitBox, CollisionLayer.EnemyCollider));
            player.ChangeSpecialShaderFlag(1, 0f);
            player.SetIsStealthed(false, "smoke");
            player.SetCapableOfStealing(false, "StealthItem", null);
            AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", base.gameObject);
            player.ownerlessStatModifiers.Remove(Modifier);
            Owner.stats.RecalculateStats(Owner, false, false);
        }
        private void BreakStealthOnSteal(PlayerController arg1, ShopItemController arg2)
        {
            this.BreakStealth(arg1);
        }

        public override void Pickup(PlayerController player)
        {
            player.OnReceivedDamage += this.OnReceivedDamage;
            base.Pickup(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.OnReceivedDamage -= this.OnReceivedDamage;
            return base.Drop(player);
        }
    }
}
