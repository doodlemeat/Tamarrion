using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Tamarrion {
	public class InventoryItemPanel : MyMonoBehaviour {
		List<InventoryItemUI> inventoryItems;
		public GameObject menuItemButtonPrefab;

		void Awake() {
			inventoryItems = new List<InventoryItemUI> ();

			AddListener<InventoryItemFilterChangeEvent> (OnInventoryItemFilterChange);
		}

		void OnDestroy() {
			AddListener<InventoryItemFilterChangeEvent> (OnInventoryItemFilterChange);
		}

		void OnInventoryItemFilterChange(InventoryItemFilterChangeEvent e) {
			if ( e.filter == -1 ) {
				foreach ( InventoryItemUI item in inventoryItems ) {
					item.gameObject.SetActive (true);
				}
			}
			else {
				foreach ( InventoryItemUI item in inventoryItems ) {
					if ( item.item.type != (BaseItem.EItemType)e.filter ) {
						item.gameObject.SetActive (false);
					}
					else {
						item.gameObject.SetActive (true);
					}
				}
			}
		}

		void Start() {
			LoadItems ();
		}

		void LoadItems () {
			if(InventoryManager.inventoryManager) {
				List<BaseItem> items = InventoryManager.GetItems ();
				items.Sort ();
				foreach (BaseItem item in items) {
					if ( menuItemButtonPrefab != null ) {
						GameObject menuItemButton = Instantiate (menuItemButtonPrefab);
						menuItemButton.transform.SetParent (transform,false);

						menuItemButton.GetComponent<InventoryItemUI> ().item = item;
						menuItemButton.GetComponentInChildren<Text> ().text = item.itemName;
						menuItemButton.GetComponentsInChildren<RawImage> ()[1].texture = item.itemIcon;

						inventoryItems.Add (menuItemButton.GetComponent<InventoryItemUI>());
					}
				}
			}
		}
	}
}
