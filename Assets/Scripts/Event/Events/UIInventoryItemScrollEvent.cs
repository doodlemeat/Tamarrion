using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIInventoryItemScrollEvent : BaseEvent {
		public PointerEventData eventData;

		public UIInventoryItemScrollEvent (PointerEventData eventData) {
			this.eventData = eventData;
		}
	}
}
