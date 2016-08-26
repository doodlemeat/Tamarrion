using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class UIInventory : MyMonoBehaviour {
		GameObject itemsPanel;

		void Awake() {
			AddListener<InventoryManagerLoadedEvent> (OnInventoryManagerLoaded);
		}

		void OnDestroy() {
			RemoveListener<InventoryManagerLoadedEvent> (OnInventoryManagerLoaded);
		}

		void OnInventoryManagerLoaded(InventoryManagerLoadedEvent e) {

		}
	}
}