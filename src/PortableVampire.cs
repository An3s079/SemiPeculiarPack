using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SemiPeculiarPack
{
    class PortableVampire : PlayerItem
    {
        public PortableVampire()
        {
            consumable = false;
            roomCooldown = 0;
            damageCooldown = 70f;
            timeCooldown = 0;
        }
        protected override void DoEffect(PlayerController user)
        {
            if (CanBeUsed(user))
            {
                user.healthHaver.ApplyHealing(-.5f);
                user.carriedConsumables.Currency += 15;
                StartCoroutine(PlaySound());
            }
        }
        public override bool CanBeUsed(PlayerController user)
        {
            return user.healthHaver.GetCurrentHealth() > .5f;
        }
        IEnumerator PlaySound()
        {
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
            yield return new WaitForSeconds(0.1f);
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
            yield return new WaitForSeconds(0.1f);
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
            yield return new WaitForSeconds(0.1f);
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
            yield return new WaitForSeconds(0.1f);
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
            yield return new WaitForSeconds(0.1f);
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
            yield return new WaitForSeconds(0.1f);
            AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject); AkSoundEngine.PostEvent("Play_WPN_ak47_shells_01", base.gameObject);
        }
       
        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Curse,
            amount = 2f,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.ownerlessStatModifiers.Add(Modifier);

        }
    }
}
