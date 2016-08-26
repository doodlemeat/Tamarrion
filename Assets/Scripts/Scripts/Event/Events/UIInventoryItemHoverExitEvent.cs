using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIInventoryItemHoverExitEvent : BaseEvent {
		public InventoryItemUI item;

		public UIInventoryItemHoverExitEvent (InventoryItemUI item) {
			this.item = item;
		}
	}
}
