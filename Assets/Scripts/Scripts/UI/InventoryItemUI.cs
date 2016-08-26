using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Tamarrion {
	public class InventoryItemUI : MyMonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {
		public BaseItem item = null;
		Text nameText;
		float catchTime = 0.4f;
		float lastClickTime;

		void Start() {
			nameText = GetComponentInChildren<Text> ();
			nameText.color = InventoryManager.inventoryManager.GetItemColor (item);
		}

		public void OnPointerEnter (PointerEventData e) {
			Trigger (new UIInventoryItemHoverEvent (this));
		}

		public void OnPointerExit(PointerEventData e) {
			Trigger (new UIInventoryItemHoverExitEvent(this));
		}

		public void OnPointerDown(PointerEventData e) {
			if(Time.unscaledTime - lastClickTime < catchTime) {
				Trigger (new UIInventoryItemSelectEvent (this, true, e.button));
			} else {
				Trigger (new UIInventoryItemSelectEvent (this, false, e.button));
			}
			lastClickTime = Time.unscaledTime;
		}
	}
}