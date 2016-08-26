using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Tamarrion {
	public class UIInventoryEquipment : MyMonoBehaviour {
		List<RawImage> slotIcons;

		public Texture2D emptySlot;

		void Awake() {
			slotIcons = new List<RawImage> ();

			RawImage[] slotIconsComponents = GetComponentsInChildren<RawImage> ();
			foreach(RawImage slotIconsComponent in slotIconsComponents) {
				if ( slotIconsComponent.GetComponent<Button> () != null ) {
					slotIcons.Add (slotIconsComponent);
				} else {
					slotIconsComponent.gameObject.SetActive (false);
				}
			}

			AddListener<UIInventoryItemSelectEvent> (OnInventoryItemSelect);
			AddListener<ItemEquipEvent> (OnItemEquip);
		}

		void OnDestroy() {
			RemoveListener<UIInventoryItemSelectEvent> (OnInventoryItemSelect);
			RemoveListener<ItemEquipEvent> (OnItemEquip);
		}

		void OnInventoryItemSelect(UIInventoryItemSelectEvent e) {
			if (e.equip) {
				InventoryManager.inventoryManager.EquipItemInSlot (e.item.item.type, InventoryManager.inventoryManager.GetAvailableItemIndexByName (e.item.item.itemName));
			}
		}

		void OnItemEquip(ItemEquipEvent e) {
			LoadEquippedItems ();
		}

		void Start() {
			LoadEquippedItems ();
		}

		void LoadEquippedItems() {
			BaseItem weaponItem = InventoryManager.inventoryManager.GetItemInEquippedSlot (BaseItem.EItemType.Weapon);
			BaseItem ringItem = InventoryManager.inventoryManager.GetItemInEquippedSlot (BaseItem.EItemType.Ring);
			BaseItem amuletItem = InventoryManager.inventoryManager.GetItemInEquippedSlot (BaseItem.EItemType.Amulet);
			BaseItem tokenItem = InventoryManager.inventoryManager.GetItemInEquippedSlot (BaseItem.EItemType.Token);

			if ( weaponItem ) {
				slotIcons[0].texture = weaponItem.itemIcon;
			} else {
				slotIcons[0].texture = emptySlot;
			}

			if ( ringItem ) {
				slotIcons[1].texture = ringItem.itemIcon;
			} else {
				slotIcons[1].texture = emptySlot;
			}

			if ( amuletItem ) {
				slotIcons[2].texture = amuletItem.itemIcon;
			} else {
				slotIcons[2].texture = emptySlot;
			}

			if ( tokenItem ) {
				slotIcons[3].texture = tokenItem.itemIcon;
			} else {
				slotIcons[3].texture = emptySlot;
			}

		}
	}
}
