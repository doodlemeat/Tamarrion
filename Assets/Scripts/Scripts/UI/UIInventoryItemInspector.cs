using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIInventoryItemInspector : MyMonoBehaviour {
		public Color diffPlusColor;
		public Color diffLessColor;
		public Texture2D emptyIcon;

		RawImage itemIcon;
		Text itemName;
		Text itemDescription;

		Text itemCompareStatDamageReduction;
		Text itemCompareStatArmor;
		Text itemCompareStatPhysicalDamage;
		Text itemCompareStatMagicDamage;
		Text itemCompareStatCritChance;
		Text itemCompareStatCritDamage;
		Text itemCompareStatMultistrike;
		Text itemCompareStatCooldownReduction;
		Text itemCompareStatMovementSpeed;

		Text itemStatDamageReduction;
		Text itemStatArmor;
		Text itemStatPhysicalDamage;
		Text itemStatMagicDamage;
		Text itemStatCritChance;
		Text itemStatCritDamage;
		Text itemStatMultistrike;
		Text itemStatCooldownReduction;
		Text itemStatMovementSpeed;

		void Awake() {
			itemIcon = transform.Find ("ItemHeader/ItemIcon").GetComponent<RawImage>();
			itemName = transform.Find ("ItemHeader/Panel/ItemName").GetComponent<Text> ();
			itemDescription = transform.Find ("ItemHeader/Panel/ItemDescription").GetComponent<Text> ();

			itemCompareStatDamageReduction = transform.Find ("ItemStats/ItemStatDiff/DamageReduction").GetComponent<Text> ();
			itemCompareStatArmor = transform.Find ("ItemStats/ItemStatDiff/Armor").GetComponent<Text> ();
			itemCompareStatPhysicalDamage = transform.Find ("ItemStats/ItemStatDiff/PhysicalDamage").GetComponent<Text> ();
			itemCompareStatMagicDamage = transform.Find ("ItemStats/ItemStatDiff/MagicDamage").GetComponent<Text> ();
			itemCompareStatCritChance = transform.Find ("ItemStats/ItemStatDiff/CritChance").GetComponent<Text> ();
			itemCompareStatCritDamage = transform.Find ("ItemStats/ItemStatDiff/CritDamage").GetComponent<Text> ();
			itemCompareStatMultistrike = transform.Find ("ItemStats/ItemStatDiff/Multistrike").GetComponent<Text> ();
			itemCompareStatCooldownReduction = transform.Find ("ItemStats/ItemStatDiff/CooldownReduction").GetComponent<Text> ();
			itemCompareStatMovementSpeed = transform.Find ("ItemStats/ItemStatDiff/MovementSpeed").GetComponent<Text> ();

			itemStatDamageReduction = transform.Find ("ItemStats/ItemStatValue/DamageReduction").GetComponent<Text> ();
			itemStatArmor = transform.Find ("ItemStats/ItemStatValue/Armor").GetComponent<Text> ();
			itemStatPhysicalDamage = transform.Find ("ItemStats/ItemStatValue/PhysicalDamage").GetComponent<Text> ();
			itemStatMagicDamage = transform.Find ("ItemStats/ItemStatValue/MagicDamage").GetComponent<Text> ();
			itemStatCritChance = transform.Find ("ItemStats/ItemStatValue/CritChance").GetComponent<Text> ();
			itemStatCritDamage = transform.Find ("ItemStats/ItemStatValue/CritDamage").GetComponent<Text> ();
			itemStatMultistrike = transform.Find ("ItemStats/ItemStatValue/Multistrike").GetComponent<Text> ();
			itemStatCooldownReduction = transform.Find ("ItemStats/ItemStatValue/CooldownReduction").GetComponent<Text> ();
			itemStatMovementSpeed = transform.Find ("ItemStats/ItemStatValue/MovementSpeed").GetComponent<Text> ();

			AddListener<UIInventoryItemHoverEvent> (OnItemHover);
			AddListener<UIInventoryItemHoverExitEvent> (OnItemHoverExit);
		}

		void OnDestroy() {
			RemoveListener<UIInventoryItemHoverEvent> (OnItemHover);
			RemoveListener<UIInventoryItemHoverExitEvent> (OnItemHoverExit);
		}

		void OnItemHover (UIInventoryItemHoverEvent e) {
			StatsItem statsItem = (StatsItem)e.item.item;
			itemIcon.texture = statsItem.itemIcon;
			itemName.text = statsItem.itemName;
			itemDescription.text = statsItem.itemDescription;
			itemStatDamageReduction.text = statsItem.stats[(int)StatsItem.EStatType.DamageReduction].value.ToString ();
			itemStatArmor.text = statsItem.stats[(int)StatsItem.EStatType.Armor].value.ToString ();
			itemStatPhysicalDamage.text = statsItem.stats[(int)StatsItem.EStatType.Physical].value.ToString ();
			itemStatMagicDamage.text = statsItem.stats[(int)StatsItem.EStatType.Magical].value.ToString ();
			itemStatCritChance.text = statsItem.stats[(int)StatsItem.EStatType.CritChance].value.ToString ();
			itemStatCritDamage.text = statsItem.stats[(int)StatsItem.EStatType.CritDamage].value.ToString ();
			itemStatMultistrike.text = statsItem.stats[(int)StatsItem.EStatType.MultiStrike].value.ToString ();
			itemStatCooldownReduction.text = statsItem.stats[(int)StatsItem.EStatType.Cooldown].value.ToString ();
			itemStatMovementSpeed.text = statsItem.stats[(int)StatsItem.EStatType.MovementSpeed].value.ToString ();

			StatsItem slotItem = (StatsItem)InventoryManager.inventoryManager.GetItemInEquippedSlot (statsItem.type);
			if(slotItem != null) {
				itemCompareStatDamageReduction.text = (statsItem.stats[(int)StatsItem.EStatType.DamageReduction].value - slotItem.stats[(int)StatsItem.EStatType.DamageReduction].value).ToString ();
				itemCompareStatArmor.text = (statsItem.stats[(int)StatsItem.EStatType.Armor].value - slotItem.stats[(int)StatsItem.EStatType.Armor].value).ToString ();
				itemCompareStatPhysicalDamage.text = (statsItem.stats[(int)StatsItem.EStatType.Physical].value - slotItem.stats[(int)StatsItem.EStatType.Physical].value).ToString ();
				itemCompareStatMagicDamage.text = (statsItem.stats[(int)StatsItem.EStatType.Magical].value - slotItem.stats[(int)StatsItem.EStatType.Magical].value).ToString ();
				itemCompareStatCritChance.text = (statsItem.stats[(int)StatsItem.EStatType.CritChance].value - slotItem.stats[(int)StatsItem.EStatType.CritChance].value).ToString ();
				itemCompareStatCritDamage.text = (statsItem.stats[(int)StatsItem.EStatType.CritDamage].value - slotItem.stats[(int)StatsItem.EStatType.CritDamage].value).ToString ();
				itemCompareStatMultistrike.text = (statsItem.stats[(int)StatsItem.EStatType.MultiStrike].value - slotItem.stats[(int)StatsItem.EStatType.MultiStrike].value).ToString ();
				itemCompareStatCooldownReduction.text = (statsItem.stats[(int)StatsItem.EStatType.Cooldown].value - slotItem.stats[(int)StatsItem.EStatType.Cooldown].value).ToString ();
				itemCompareStatMovementSpeed.text = (statsItem.stats[(int)StatsItem.EStatType.MovementSpeed].value - slotItem.stats[(int)StatsItem.EStatType.MovementSpeed].value).ToString ();

				itemCompareStatDamageReduction.color = float.Parse (itemCompareStatDamageReduction.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatArmor.color = float.Parse (itemCompareStatArmor.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatPhysicalDamage.color = float.Parse (itemCompareStatPhysicalDamage.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatMagicDamage.color = float.Parse (itemCompareStatMagicDamage.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatCritChance.color = float.Parse (itemCompareStatCritChance.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatCritDamage.color = float.Parse (itemCompareStatCritDamage.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatMultistrike.color = float.Parse (itemCompareStatMultistrike.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatCooldownReduction.color = float.Parse (itemCompareStatCooldownReduction.text) < 0 ? diffLessColor : diffPlusColor;
				itemCompareStatMovementSpeed.color = float.Parse (itemCompareStatMovementSpeed.text) < 0 ? diffLessColor : diffPlusColor;

				itemCompareStatDamageReduction.text = itemCompareStatDamageReduction.text == "0" ? "" : itemCompareStatDamageReduction.text;
				itemCompareStatArmor.text = itemCompareStatArmor.text == "0" ? "" : itemCompareStatArmor.text;
				itemCompareStatPhysicalDamage.text = itemCompareStatPhysicalDamage.text == "0" ? "" : itemCompareStatPhysicalDamage.text;
				itemCompareStatMagicDamage.text = itemCompareStatMagicDamage.text == "0" ? "" : itemCompareStatMagicDamage.text;
				itemCompareStatCritChance.text = itemCompareStatCritChance.text == "0" ? "" : itemCompareStatCritChance.text;
				itemCompareStatCritDamage.text = itemCompareStatCritDamage.text == "0" ? "" : itemCompareStatCritDamage.text;
				itemCompareStatMultistrike.text = itemCompareStatMultistrike.text == "0" ? "" : itemCompareStatMultistrike.text;
				itemCompareStatCooldownReduction.text = itemCompareStatCooldownReduction.text == "0" ? "" : itemCompareStatCooldownReduction.text;
				itemCompareStatMovementSpeed.text = itemCompareStatMovementSpeed.text == "0" ? "" : itemCompareStatMovementSpeed.text;
			}
		}

		void OnItemHoverExit (UIInventoryItemHoverExitEvent e) {
			itemIcon.texture = emptyIcon;
			itemName.text = "";
			itemDescription.text = "";
			itemStatDamageReduction.text = "";
			itemStatArmor.text = "";
			itemStatPhysicalDamage.text = "";
			itemStatMagicDamage.text = "";
			itemStatCritChance.text = "";
			itemStatCritDamage.text = "";
			itemStatMultistrike.text = "";
			itemStatCooldownReduction.text = "";
			itemStatMovementSpeed.text = "";

			itemCompareStatDamageReduction.text = "";
			itemCompareStatArmor.text = "";
			itemCompareStatPhysicalDamage.text = "";
			itemCompareStatMagicDamage.text = "";
			itemCompareStatCritChance.text = "";
			itemCompareStatCritDamage.text = "";
			itemCompareStatMultistrike.text = "";
			itemCompareStatCooldownReduction.text = "";
			itemCompareStatMovementSpeed.text = "";
		}
	}
}
