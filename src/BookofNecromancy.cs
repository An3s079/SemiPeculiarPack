using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Semi;
using UnityEngine;

namespace SemiPeculiarPack
{
    class BookofNecromancy : PlayerItem
    {
        public BookofNecromancy()
        {
            consumable = false;
            consumable = false;
            roomCooldown = 0;
            damageCooldown = 700f;
            timeCooldown = 0;
        }
        protected override void DoEffect(PlayerController owner)
        {



                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid("d5a7b95774cd41f080e517bea07bf495");
                IntVector2? intVector = new IntVector2?(owner.CurrentRoom.GetRandomVisibleClearSpot(1, 1));
                bool flag = intVector != null;
                if (flag)
                {


                    AIActor one = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                    one.IgnoreForRoomClear = true;
                    CompanionController companionComponent = one.gameObject.GetOrAddComponent<CompanionController>();
                    companionComponent.companionID = CompanionController.CompanionIdentifier.NONE;
                    companionComponent.Initialize(owner);
                    CompanionisedEnemyBulletModifiers companionisedBullets = one.gameObject.GetOrAddComponent<CompanionisedEnemyBulletModifiers>();
                    companionisedBullets.jammedDamageMultiplier = 2f;
                    companionisedBullets.TintBullets = true;
                    companionisedBullets.TintColor = Color.yellow;
                    companionisedBullets.baseBulletDamage = 3f;
                    one.gameObject.AddComponent<KillOnRoomClear>();


                }
           
        }

        public StatModifier Modifier = new StatModifier
        {
            statToBoost = PlayerStats.StatType.Curse,
            amount = 2,
            modifyType = StatModifier.ModifyMethod.ADDITIVE
        };

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.ownerlessStatModifiers.Add(Modifier);
            player.stats.RecalculateStats(player);
        }

        protected override void OnPreDrop(PlayerController user)
        {
            user.ownerlessStatModifiers.Remove(Modifier);
            user.stats.RecalculateStats(user);
            base.OnPreDrop(user);
        }
    }
}
