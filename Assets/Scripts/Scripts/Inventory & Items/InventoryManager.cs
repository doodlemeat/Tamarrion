using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using Tamarrion;
namespace Tamarrion {
	public class InventoryManager : MyMonoBehaviour {
		public static InventoryManager inventoryManager = null;

		[Serializable]
		class InventoryData {
			public int version;
			public int[] equipped = new int[(int)BaseItem.EItemType.Count];
			public List<int> inventoryItems;
			public List<bool> lockedState;
		}

		[Serializable]
		public struct ItemRarityColor {
			public BaseItem.EItemRarity rarity;
			public Color color;
		}

		[Serializable]
		public struct ItemCategory {
			public BaseItem.EItemType type;
			public string name;
		}

		[SerializeField]
		List<ItemRarityColor> itemColors = new List<ItemRarityColor> ();

		[SerializeField]
		List<ItemCategory> itemCategories = new List<ItemCategory> ();

		public bool fillEmptyEquipment = false;
		public List<GameObject> AvailableItems = new List<GameObject> ();
		public List<bool> lockedStates = new List<bool> ();

		List<bool> defaultLocked = new List<bool> ();

		List<BaseItem> items = new List<BaseItem> ();
		public int SelectedItem = -1;

		public int[] equipped = new int[(int)BaseItem.EItemType.Count];
		public List<int> inventoryItems;
		private bool Loaded = false;
		private int version = 8;

		void Awake () {
			equipped = new int[(int)BaseItem.EItemType.Count];
			inventoryManager = this;
			GameObject ItemsInventory = new GameObject ();
			ItemsInventory.name = "ItemsInventory";

			defaultLocked.AddRange (lockedStates);

			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				items.Add (AvailableItems[i].GetComponent<BaseItem> ());
				AvailableItems[i] = Instantiate (AvailableItems[i]);
				AvailableItems[i].transform.SetParent (ItemsInventory.transform);
			}

			AddListener<LootEvent> (OnLoot);
		}

		void OnDestroy () {
			RemoveListener<LootEvent> (OnLoot);
		}

		void OnLoot (LootEvent e) {
			UnlockItem (e.item);
		}

		void Start () {
			Load ();
			if ( !InventoryValid () ) {
				Debug.Log ("invalid inventory");
				ResetAllItemSettings ();
			}

			SortItems ();
			LockItems ();
			Loaded = true;
			if ( InventoryMenu.instance )
				InventoryMenu.instance.RemoveFilters ();

			if ( fillEmptyEquipment )
				CheckAndPerhapsFillEmptyEquipment ();
		}

		void CheckAndPerhapsFillEmptyEquipment () {
			bool equipmentEmpty = true;

			foreach ( int itemId in equipped ) {
				if ( itemId != -1 )
					equipmentEmpty = false;
			}

			if ( !equipmentEmpty )
				return;

			Debug.Log ("filling empty equipment");
			FillEmptyEquipment ();
		}

		void FillEmptyEquipment () {
			EquipItemInSlot (BaseItem.EItemType.Amulet, GetAvailableItemIndexByName ("Pendant"));
			EquipItemInSlot (BaseItem.EItemType.Ring, GetAvailableItemIndexByName ("The Turtle Ring"));
			EquipItemInSlot (BaseItem.EItemType.Weapon, GetAvailableItemIndexByName ("Claiomh Arach"));
			EquipItemInSlot (BaseItem.EItemType.Token, GetAvailableItemIndexByName ("Liquid Love"));
		}

		void OnDisable () {
			Save ();
		}

		void Update () {
			if ( Application.isEditor ) {
				if ( (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && Input.GetKeyDown (KeyCode.P) ) {
					if ( File.Exists (Application.persistentDataPath + "/inventory.dat") )
						File.Delete (Application.persistentDataPath + "/inventory.dat");

					ResetAllItemSettings ();
					Save ();
				}
			}

			// TODO: Remove
			if ( Input.GetKeyDown (KeyCode.F12) ) {
				lockedStates = defaultLocked;
				FillEmptyEquipment ();
				Save ();
			}
		}

		public void AddItemByIndex (int p_itemIndex) {
			inventoryItems.Add (p_itemIndex);
		}

		public void EquipSelectedItemInSlot (BaseItem.EItemType p_slot) {
			EquipItemInSlot (p_slot, SelectedItem);
		}

		public void EquipItemInSlot (BaseItem.EItemType p_slot, int p_itemIndex) {
			if ( p_itemIndex == -1 || AvailableItems.Count - 1 < p_itemIndex )
				return;

			StatsItem itemScript = AvailableItems[p_itemIndex].GetComponent<StatsItem> ();

			//slot correct check
			if ( p_slot != itemScript.type ) {
				Debug.Log (AvailableItems[p_itemIndex].name + ": wrong slot.");
				return;
			}

			//if item already equipped in other slot
			for ( int i = 0; i < (int)BaseItem.EItemType.Count; ++i ) {
				if ( equipped[i] == p_itemIndex ) {
					UnequipSlot ((BaseItem.EItemType)i);
				}
			}

			//place item in slot and make item unavailable
			equipped[(int)p_slot] = p_itemIndex;
			itemScript.Available = false;

			Trigger (new ItemEquipEvent (AvailableItems[p_itemIndex].GetComponent<BaseItem> ()));
		}

		public void UnequipItem (GameObject p_item) {
			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				if ( p_item == AvailableItems[i] ) {
					AvailableItems[i].GetComponent<StatsItem> ().Available = true;
					for ( int slot = 0; slot < (int)BaseItem.EItemType.Count; ++slot ) {
						if ( equipped[slot] == i )
							equipped[slot] = -1;
					}
				}
			}
		}

		public void UnequipSlot (BaseItem.EItemType p_slot) {
			if ( p_slot < 0 || p_slot > BaseItem.EItemType.Count )
				return;

			equipped[(int)p_slot] = -1;
		}

		public void LockItems () {
			PlayerStats.instance.ResetToBase ();

			for ( int i = 0; i < (int)BaseItem.EItemType.Count; ++i ) {
				if ( equipped[i] != -1 ) {
					StatsItem itemScript = AvailableItems[equipped[i]].GetComponent<StatsItem> ();

					if ( itemScript.stats[(int)StatsItem.EStatType.Health].value > 0 ) {
						float health_percent = PlayerStats.instance.GetPercentageHP ();
						//Debug.Log("health: " + playerStats.m_stat["health"] + " max health: " + playerStats.m_stat["max_health"] + " percentage: " + health_percent);
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_maxhealth", "max_health", itemScript.stats[(int)StatsItem.EStatType.Health].value);
						PlayerStats.instance.m_stat["health"] = PlayerStats.instance.m_stat["max_health"] * health_percent;
					}
					if ( itemScript.stats[(int)StatsItem.EStatType.DamageReduction].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_damagereduction", "damage_reduction", itemScript.stats[(int)StatsItem.EStatType.DamageReduction].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.Armor].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_armor", "armor", itemScript.stats[(int)StatsItem.EStatType.Armor].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.Damage].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_damage", "damage", itemScript.stats[(int)StatsItem.EStatType.Damage].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.Physical].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_physical", "physical", itemScript.stats[(int)StatsItem.EStatType.Physical].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.Magical].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_magical", "magical", itemScript.stats[(int)StatsItem.EStatType.Magical].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.CritChance].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_critchance", "crit_chance", itemScript.stats[(int)StatsItem.EStatType.CritChance].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.CritDamage].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_critdamage", "crit_damage", itemScript.stats[(int)StatsItem.EStatType.CritDamage].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.MultiStrike].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_multistrike", "multistrike", itemScript.stats[(int)StatsItem.EStatType.MultiStrike].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.Cooldown].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_cooldownreduction", "cooldown_reduction", itemScript.stats[(int)StatsItem.EStatType.Cooldown].value);
					if ( itemScript.stats[(int)StatsItem.EStatType.MovementSpeed].value > 0 )
						PlayerStats.instance.Add_Modifier (itemScript.itemName + "_movementspeed", "movement_speed", itemScript.stats[(int)StatsItem.EStatType.MovementSpeed].value);
				}
			}
			//PlayerStats.instance.PrintModifiers();
		}

		public void SortItems () {
			// AvailableItems = AvailableItems.OrderByDescending(x => x.GetComponent<BaseItem>().rarity).ToList();
		}

		void Save () {
			BinaryFormatter bff = new BinaryFormatter ();
			FileStream ffs = File.Create (Application.persistentDataPath + "/inventory.dat");

			InventoryData invTest = new InventoryData ();
			invTest.version = version;
			invTest.equipped = equipped;
			invTest.inventoryItems = inventoryItems;
			invTest.lockedState = lockedStates;

			bff.Serialize (ffs, invTest);
			ffs.Close ();
		}

		void Load () {
			if ( !File.Exists (Application.persistentDataPath + "/inventory.dat") )
				return;

			BinaryFormatter bff = new BinaryFormatter ();
			FileStream ffs = File.Open (Application.persistentDataPath + "/inventory.dat", FileMode.Open);

			InventoryData invTest = (InventoryData)bff.Deserialize (ffs);
			ffs.Close ();

			if ( version == invTest.version ) {
				equipped = invTest.equipped;
				inventoryItems = invTest.inventoryItems;
				lockedStates = invTest.lockedState;
			}
			else {
				Debug.Log ("wrong version of savefile");
				ResetAllItemSettings ();
				Save ();
			}
		}

		public bool GetLoaded () {
			return Loaded;
		}

		public void ResetAllItemSettings () {
			SelectedItem = -1;
			equipped = new int[(int)BaseItem.EItemType.Count];
			for ( int i = 0; i < (int)BaseItem.EItemType.Count; ++i ) {
				equipped[i] = -1;
			}

			//adding one of each item type
			GameObject ItemsAvailable = new GameObject ();
			ItemsAvailable.name = "ItemsAvailable";
			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				AvailableItems[i] = GameObject.Instantiate (AvailableItems[i]);
				AvailableItems[i].transform.SetParent (ItemsAvailable.transform);
			}
			//filling inventory with 1 of each item
			inventoryItems.Clear ();
			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				if ( AvailableItems[i].GetComponent<BaseItem> ().itemName == "Lord Valac’s Ring"
					|| AvailableItems[i].GetComponent<BaseItem> ().itemName == "Lord Valac’s Greatsword"
					|| AvailableItems[i].GetComponent<BaseItem> ().itemName == "Silver Ring" ) {
					Debug.Log ("skipping: " + i);
					continue;
				}

				Debug.Log ("adding: " + i);
				inventoryItems.Add (i);
			}
		}

		bool InventoryValid () {
			foreach ( int itemIndex in inventoryItems ) {
				if ( itemIndex >= AvailableItems.Count ) {
					Debug.Log ("oops index: " + itemIndex + ", count: " + AvailableItems.Count);
					return false;
				}
			}

			if ( lockedStates.Count != items.Count ) {
				return false;
			}
			return true;
		}

		public BaseItem GetItemInInventory (int p_index) {
			if ( p_index > inventoryItems.Count - 1 )
				return null;

			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				if ( inventoryItems[p_index] == i ) {
					return AvailableItems[i].GetComponent<BaseItem> ();
				}
			}

			return null;
		}

		public BaseItem GetItemInEquippedSlot (BaseItem.EItemType p_itemType) {
			if ( (int)p_itemType > equipped.Length - 1 || p_itemType == BaseItem.EItemType.Generic )
				return null;

			if ( equipped[(int)p_itemType] == -1 )
				return null;

			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				if ( equipped[(int)p_itemType] == i ) {
					return AvailableItems[i].GetComponent<BaseItem> ();
				}
			}

			return null;
		}

		public int GetAvailableItemIndexByName (string p_name) {
			for ( int i = 0; i < AvailableItems.Count; ++i ) {
				if ( AvailableItems[i].GetComponent<BaseItem> ().itemName == p_name )
					return i;
			}

			return -1;
		}

		public void EquipItem (BaseItem item) {
			int index = -1;

			for ( int i = 0; i < items.Count; ++i ) {
				if ( items[i].GetInstanceID () == item.GetInstanceID () ) {
					index = i;
				}
			}

			EquipItemInSlot (item.type, index);
		}

		List<BaseItem> GetItemsPrivate (bool includeLocked = false) {
			return AvailableItems.Where ((e, i) => lockedStates[i] == true || lockedStates[i] == !includeLocked).Select (e => e.GetComponent<BaseItem> ()).ToList ();
		}

		bool IsItemLockedPrivate (BaseItem item) {
			for ( int i = 0; i < items.Count; ++i ) {
				if ( items[i] == item ) {
					return !lockedStates[i];
				}
			}

			Debug.LogError ("No item found");
			return false;
		}

		public Dictionary<BaseItem.EItemType, BaseItem> GetEquippedItems () {
			Dictionary<BaseItem.EItemType, BaseItem> equippedItems = new Dictionary<BaseItem.EItemType, BaseItem> ();

			for ( int i = 0; i < equipped.Length; ++i ) {
				equippedItems.Add ((BaseItem.EItemType)i, AvailableItems[i].GetComponent<BaseItem> ());
			}

			return equippedItems;
		}

		public Color GetItemColor (BaseItem item) {
			foreach ( ItemRarityColor irc in itemColors ) {
				if ( irc.rarity == item.rarity ) {
					return irc.color;
				}
			}

			return Color.white;
		}

		public string GetItemCategoryName (BaseItem.EItemType type) {
			foreach ( ItemCategory ic in itemCategories ) {
				if ( ic.type == type ) {
					return ic.name;
				}
			}

			return "";
		}

		void UnlockItem (BaseItem item) {
			for ( int i = 0; i < items.Count; ++i ) {
				if ( items[i] == item ) {
					lockedStates[i] = true;
				}
			}
		}

		// PUBLIC

		public static List<BaseItem> GetItems (bool includeLocked = false) {
			return inventoryManager.GetItemsPrivate (includeLocked);
		}

		public static bool IsItemLocked (BaseItem item) {
			return inventoryManager.IsItemLockedPrivate (item);
		}
	}
}