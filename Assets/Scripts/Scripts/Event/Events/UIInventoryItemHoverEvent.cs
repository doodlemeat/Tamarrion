using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIInventoryItemHoverEvent : BaseEvent {
		public InventoryItemUI item;

		public UIInventoryItemHoverEvent (InventoryItemUI item) {
			this.item = item;
		}
	}
}
