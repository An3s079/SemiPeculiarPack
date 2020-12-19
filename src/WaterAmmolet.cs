using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SemiPeculiarPack
{
    class WaterAmmolet : SpecialBlankModificationItem
    {
        public WaterAmmolet()
        {
            BlankStunTime = 0.1f;
		}
		protected override void OnBlank(Vector2 centerPoint, PlayerController user)
		{
			AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
			GoopDefinition goopDefinition = assetBundle.LoadAsset<GoopDefinition>("assets/data/goops/water goop.asset");
			DeadlyDeadlyGoopManager goopManagerForGoopType = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDefinition);
			goopManagerForGoopType.TimedAddGoopCircle(base.Owner.sprite.WorldCenter, 20f, 0.35f, false);
		}
		public override void Pickup(PlayerController player)
		{
			SpecialBlankModificationItem.InitHooks();
			base.Pickup(player);
		}
		public override DebrisObject Drop(PlayerController player)
		{
		
			return base.Drop(player);
		}
	}
}
