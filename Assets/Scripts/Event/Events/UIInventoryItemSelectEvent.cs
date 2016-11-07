using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIInventoryItemSelectEvent : BaseEvent {
		public InventoryItemUI item;
		public bool equip;
		public PointerEventData.InputButton button;

		public UIInventoryItemSelectEvent (InventoryItemUI item, bool equip, PointerEventData.InputButton button) {
			this.item = item;
			this.equip = equip;
			this.button = button;
		}
	}
}
