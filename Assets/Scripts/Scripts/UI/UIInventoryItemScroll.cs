using UnityEngine.UI;

namespace Tamarrion {
	public class UIInventoryItemScroll : MyMonoBehaviour {
		ScrollRect scrollRect;

		void Awake() {
			scrollRect = GetComponent<ScrollRect> ();

			AddListener<UIInventoryItemScrollEvent> (OnScroll);
			AddListener<InventoryItemFilterChangeEvent> (OnItemFilterChange);
		}

		void OnDestroy() {
			RemoveListener<UIInventoryItemScrollEvent> (OnScroll);
			RemoveListener<InventoryItemFilterChangeEvent> (OnItemFilterChange);
		}

		void OnScroll(UIInventoryItemScrollEvent e) {
			scrollRect.OnScroll (e.eventData);
		}

		void OnItemFilterChange(InventoryItemFilterChangeEvent e) {
			scrollRect.verticalNormalizedPosition = 1;
		}
	}
}
