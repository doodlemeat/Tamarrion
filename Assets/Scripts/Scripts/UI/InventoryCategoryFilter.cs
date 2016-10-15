using System;
using UnityEngine;

namespace Tamarrion {
	public class InventoryCategoryFilter : MyMonoBehaviour {
		public void OnButtonClick(string type) {
			try {
				BaseItem.EItemType itemType = (BaseItem.EItemType)Enum.Parse (typeof (BaseItem.EItemType), type);
				ApplyFilter ((int)itemType);
			} catch(ArgumentException e) {
				Debug.Log (e.Message);
				ApplyFilter (-1);
			}
		}

		void RemoveFilter() {

		}

		void ApplyFilter (int filter) {
			Trigger (new InventoryItemFilterChangeEvent (filter));
		}
	}
}
