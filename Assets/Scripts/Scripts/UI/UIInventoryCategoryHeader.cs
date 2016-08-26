using UnityEngine.UI;

namespace Tamarrion {
	public class UIInventoryCategoryHeader : MyMonoBehaviour {
		Text text;

		void Awake() {
			text = GetComponent<Text> ();

			AddListener<InventoryItemFilterChangeEvent> (OnInventoryItemFilterChange);
		}

		void OnDestroy() {
			RemoveListener<InventoryItemFilterChangeEvent> (OnInventoryItemFilterChange);
		}

		void OnInventoryItemFilterChange(InventoryItemFilterChangeEvent e) {
			text.text = InventoryManager.inventoryManager.GetItemCategoryName ((BaseItem.EItemType)e.filter);
			if(text.text == "") {
				text.text = "All";
			}
		}
	}
}
