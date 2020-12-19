using System;
using Semi;
using Logger = ModTheGungeon.Logger;
using System.Collections.Generic;

namespace SemiPeculiarPack {
	public class SemiPeculiarPack : Mod {
		public Logger Logger = new Logger("SemiPeculiarPack");
		public static SemiPeculiarPack Instance;
		public override void Loaded() {
			Logger.Info($"Hello world!");
		}

		public override void RegisterContent() {
			Logger.Debug($"Registering content.");

			var def = RegisterEncounterIcon("@:my_item_icon", "my_item.png");
			RegisterSpriteCollection(
				"@:my_item_coll",
				def
			);
			RegisterSpriteTemplate(
				"@:my_item_sprite",
				"@:my_item_coll",
				"@:my_item_icon"
			);
			RegisterLocalization(
				"@:english_items",
				"english_items.txt",
				"gungeon:english",
				I18N.StringTable.Items
			);

			RegisterItem<myItem>(
				"@:my_item",
				"@:my_item_icon",
				"@:my_item_sprite",
				"#@:MY_ITEM_NAME",
				"#@:MY_ITEM_SHORT_DESC",
				"#@:MY_ITEM_LONG_DESC"
			);
			//coolerHeartContainer
			var cool_heart_def = RegisterEncounterIcon("@:cooler_heart_icon", "cooler_heart.png");
			
			RegisterSpriteCollection(
				"@:cooler_heart_coll",
				cool_heart_def
				);
			RegisterSpriteTemplate(
				 "@:cooler_heart_sprite",
			     "@:cooler_heart_coll",
				 "@:cooler_heart_icon"
			    );

			RegisterItem<CoolerHeart>
				(
					"@:cooler_heart",
					"@:cooler_heart_icon",
					"@:cooler_heart_sprite",
					"#@:CoolerHeartName",
					"#@:CoolerHeartShortDesc",
					"#@:CoolerHeartLongDesc"
				);

			//threatening Aura
			var aura_def = RegisterEncounterIcon("@:aura_icon", "aura.png");
			
			RegisterSpriteCollection(
				"@:aura_coll",
				aura_def
				);
			RegisterSpriteTemplate(
				 "@:aura_sprite",
				 "@:aura_coll",
				 "@:aura_icon"
				);
			RegisterItem<ThreateningAura>
				(
					"@:aura",
					"@:aura_icon",
					"@:aura_sprite",
					"#@:AuraName",
					"#@:AuraShortDesc",
					"#@:AuraLongDesc"
				);
			
			//water Ammolet
			var water_ammolet_def = RegisterEncounterIcon("@:water_ammolet_icon", "water_ammolet.png");
			RegisterSpriteCollection(
				"@:water_ammolet_coll",
				water_ammolet_def
				);
			RegisterSpriteTemplate(
				 "@:water_ammolet_sprite",
				 "@:water_ammolet_coll",
				 "@:water_ammolet_icon"
				);
			RegisterItem<WaterAmmolet>
				(
					"@:water_ammolet",
					"@:water_ammolet_icon",
					"@:water_ammolet_sprite",
					"#@:WaterAmmoletName",
					"#@:WaterAmmoletShortDesc",
					"#@:WaterAmmoletLongDesc"
				);

			//cleansing Water
			var cleansing_def = RegisterEncounterIcon("@:cleansing_icon", "cleansing.png");
			
			RegisterSpriteCollection(
				"@:cleansing_coll",
				cleansing_def
				);
			RegisterSpriteTemplate(
				 "@:cleansing_sprite",
				 "@:cleansing_coll",
				 "@:cleansing_icon"
				);
			RegisterItem<CleansingWater>
				(
					"@:cleansing",
					"@:cleansing_icon",
					"@:cleansing_sprite",
					"#@:CleansingName",
					"#@:CleansingShortDesc",
					"#@:CleansingLongDesc"
				);

			//FearBullets
			var fear_bullets_def = RegisterEncounterIcon("@:fear_bullets_icon", "fear_bullets.png");

			RegisterSpriteCollection(
				"@:fear_bullets_coll",
				fear_bullets_def
				);
			RegisterSpriteTemplate(
				 "@:fear_bullets_sprite",
				 "@:fear_bullets_coll",
				 "@:fear_bullets_icon"
				);
			RegisterItem<FearBullets>
				(
					"@:fear_bullets",
					"@:fear_bullets_icon",
					"@:fear_bullets_sprite",
					"#@:FearBulletsName",
					"#@:FearBulletsShortDesc",
					"#@:FearBulletsLongDesc"
				);

			//Leather Jacket
			var jacket_def = RegisterEncounterIcon("@:jacket_icon", "jacket.png");

			RegisterSpriteCollection(
				"@:jacket_coll",
				jacket_def
				);
			RegisterSpriteTemplate(
				 "@:jacket_sprite",
				 "@:jacket_coll",
				 "@:jacket_icon"
				);
			RegisterItem<LeatherJacket>
				(
					"@:jacket",
					"@:jacket_icon",
					"@:jacket_sprite",
					"#@:JacketName",
					"#@:JacketShortDesc",
					"#@:JacketLongDesc"
				);
			
			//lich bullets
			var lich_bullets_def = RegisterEncounterIcon("@:lich_bullets_icon", "lich_bullets.png");

			RegisterSpriteCollection(
				"@:lich_bullets_coll",
				lich_bullets_def
				);
			RegisterSpriteTemplate(
				 "@:lich_bullets_sprite",
				 "@:lich_bullets_coll",
				 "@:lich_bullets_icon"
				);
			RegisterItem<LichBullets>
				(
					"@:lich_bullets",
					"@:lich_bullets_icon",
					"@:lich_bullets_sprite",
					"#@:LichBulletsName",
					"#@:LichBulletsShortDesc",
					"#@:LichBulletsLongDesc"
				);

			//Miasma
			var miasma_def = RegisterEncounterIcon("@:miasma_icon", "miasma.png");

			RegisterSpriteCollection(
				"@:miasma_coll",
				miasma_def
				);
			RegisterSpriteTemplate(
				 "@:miasma_sprite",
				 "@:miasma_coll",
				 "@:miasma_icon"
				);
			RegisterItem<Miasma>
				(
					"@:miasma",
					"@:miasma_icon",
					"@:miasma_sprite",
					"#@:MiasmaName",
					"#@:MiasmaShortDesc",
					"#@:MiasmaLongDesc"
				);

			//Old War Stealthkit
			var stealthkit_def = RegisterEncounterIcon("@:stealthkit_icon", "stealthkit.png");

			RegisterSpriteCollection(
				"@:stealthkit_coll",
				stealthkit_def
				);
			RegisterSpriteTemplate(
				 "@:stealthkit_sprite",
				 "@:stealthkit_coll",
				 "@:stealthkit_icon"
				);
			RegisterItem<OldWarStealthKit>
				(
					"@:stealthkit",
					"@:stealthkit_icon",
					"@:stealthkit_sprite",
					"#@:StealthkitName",
					"#@:StealthkitShortDesc",
					"#@:StealthkitLongDesc"
				);

			//Portable Vampire
			var vampire_def = RegisterEncounterIcon("@:vampire_icon", "vampire.png");

			RegisterSpriteCollection(
				"@:vampire_coll",
				vampire_def
				);
			RegisterSpriteTemplate(
				 "@:vampire_sprite",
				 "@:vampire_coll",
				 "@:vampire_icon"
				);
			RegisterItem<PortableVampire>
				(
					"@:vampire",
					"@:vampire_icon",
					"@:vampire_sprite",
					"#@:VampireName",
					"#@:VampireShortDesc",
					"#@:VampireLongDesc"
				);
			//Book of Necromancy
			var necromancy_def = RegisterEncounterIcon("@:necromancy_icon", "necromancy.png");

			RegisterSpriteCollection(
				"@:necromancy_coll",
				necromancy_def
				);
			RegisterSpriteTemplate(
				 "@:necromancy_sprite",
				 "@:necromancy_coll",
				 "@:necromancy_icon"
				);
			RegisterItem<BookofNecromancy>
				(
					"@:necromancy",
					"@:necromancy_icon",
					"@:necromancy_sprite",
					"#@:NecromancyName",
					"#@:NecromancyShortDesc",
					"#@:NecromancyLongDesc"
				);

			//rubber bullets
			var rubber_bullets_def = RegisterEncounterIcon("@:rubber_bullets_icon", "rubber_bullets.png");

			RegisterSpriteCollection(
				"@:rubber_bullets_coll",
				rubber_bullets_def
				);
			RegisterSpriteTemplate(
				 "@:rubber_bullets_sprite",
				 "@:rubber_bullets_coll",
				 "@:rubber_bullets_icon"
				);
			RegisterItem<RubberBullets>
				(
					"@:rubber_bullets",
					"@:rubber_bullets_icon",
					"@:rubber_bullets_sprite",
					"#@:RubberBulletsName",
					"#@:RubberBulletsShortDesc",
					"#@:RubberBulletsLongDesc"
				);

			//tentacle rounds
			var tentacles_def = RegisterEncounterIcon("@:tentacles_icon", "tentacles.png");

			RegisterSpriteCollection(
				"@:tentacles_coll",
				tentacles_def
				);
			RegisterSpriteTemplate(
				 "@:tentacles_sprite",
				 "@:tentacles_coll",
				 "@:tentacles_icon"
				);
			RegisterItem<TentacleRounds>
				(
					"@:tentacles",
					"@:tentacles_icon",
					"@:tentacles_sprite",
					"#@:TentaclesName",
					"#@:TentaclesShortDesc",
					"#@:TentaclesLongDesc"
				);

			//velocity
			var velocity_def = RegisterEncounterIcon("@:velocity_icon", "velocity.png");

			RegisterSpriteCollection(
				"@:velocity_coll",
				velocity_def
				);
			RegisterSpriteTemplate(
				 "@:velocity_sprite",
				 "@:velocity_coll",
				 "@:velocity_icon"
				);
			RegisterItem<Velocity>
				(
					"@:velocity",
					"@:velocity_icon",
					"@:velocity_sprite",
					"#@:VelocityName",
					"#@:VelocityShortDesc",
					"#@:VelocityLongDesc"
				);

			//ygdar orus li ox
			var ygdar_def = RegisterEncounterIcon("@:ygdar_icon", "ygdar.png");

			RegisterSpriteCollection(
				"@:ygdar_coll",
				ygdar_def
				);
			RegisterSpriteTemplate(
				 "@:ygdar_sprite",
				 "@:ygdar_coll",
				 "@:ygdar_icon"
				);
			RegisterItem<Ygdar_Orus_Li_Ox>
				(
					"@:ygdar",
					"@:ygdar_icon",
					"@:ygdar_sprite",
					"#@:YgdarName",
					"#@:YgdarShortDesc",
					"#@:YgdarLongDesc"
				);
		}

		public override void InitializeContent() {
			Logger.Debug($"Initializing content.");
		
			//qualities
			Gungeon.Items.Get("@:cooler_heart", Instance.ID).quality = PickupObject.ItemQuality.A;
			Gungeon.Items.Get("@:aura", Instance.ID).quality = PickupObject.ItemQuality.C;
			Gungeon.Items.Get("@:water_ammolet", Instance.ID).quality = PickupObject.ItemQuality.D;
			Gungeon.Items.Get("@:cleansing", Instance.ID).quality = PickupObject.ItemQuality.B;
			Gungeon.Items.Get("@:fear_bullets", Instance.ID).quality = PickupObject.ItemQuality.C;
			Gungeon.Items.Get("@:jacket", Instance.ID).quality = PickupObject.ItemQuality.D;
			Gungeon.Items.Get("@:lich_bullets", Instance.ID).quality = PickupObject.ItemQuality.S;
			Gungeon.Items.Get("@:miasma", Instance.ID).quality = PickupObject.ItemQuality.B;
			Gungeon.Items.Get("@:stealthkit", Instance.ID).quality = PickupObject.ItemQuality.B;
			Gungeon.Items.Get("@:vampire", Instance.ID).quality = PickupObject.ItemQuality.A;
			Gungeon.Items.Get("@:necromancy", Instance.ID).quality = PickupObject.ItemQuality.A;
			Gungeon.Items.Get("@:rubber_bullets", Instance.ID).quality = PickupObject.ItemQuality.C;
			Gungeon.Items.Get("@:tentacles", Instance.ID).quality = PickupObject.ItemQuality.B;
			Gungeon.Items.Get("@:velocity", Instance.ID).quality = PickupObject.ItemQuality.C;
			Gungeon.Items.Get("@:ygdar", Instance.ID).quality = PickupObject.ItemQuality.A;

		}
	}
}
