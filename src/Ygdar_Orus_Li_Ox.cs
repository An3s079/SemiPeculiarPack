using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace SemiPeculiarPack
{
    class Ygdar_Orus_Li_Ox : PassiveItem
    {
        bool usable = true;
        private void ModifyIncomingDamage(HealthHaver source, HealthHaver.ModifyDamageEventArgs args)
        {
            if (source.GetCurrentHealth() <= 0.5 && source.Armor <= 0)
            {
                if (usable == true)
                {
                    float MaxHealth = Owner.healthHaver.GetMaxHealth();
                    args.ModifiedDamage = 0f;
                    Owner.healthHaver.ApplyHealing(MaxHealth * 0.5f);
                    Owner.healthHaver.ApplyDamage(0.5f, Vector2.zero, "Ygdar Orus Li Ox Bug(PlsReport)", CoreDamageTypes.None, DamageCategory.Normal, true, null, false);
                    usable = false;
                    Destroy(gameObject);
                }

            }
        }


        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            HealthHaver healthHaver = player.healthHaver;
            healthHaver.ModifyDamage = (Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>)Delegate.Combine(healthHaver.ModifyDamage, new Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>(this.ModifyIncomingDamage));
        }

        public override DebrisObject Drop(PlayerController player)
        {
            DebrisObject debrisObject = base.Drop(player);
            HealthHaver healthHaver = player.healthHaver;
            healthHaver.ModifyDamage = (Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>(this.ModifyIncomingDamage));
            return debrisObject;
        }

        protected override void OnDestroy()
        {
            HealthHaver healthHaver = Owner.healthHaver;
            healthHaver.ModifyDamage = (Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>)Delegate.Remove(healthHaver.ModifyDamage, new Action<HealthHaver, HealthHaver.ModifyDamageEventArgs>(this.ModifyIncomingDamage));
            base.OnDestroy();
        }
    }
}
