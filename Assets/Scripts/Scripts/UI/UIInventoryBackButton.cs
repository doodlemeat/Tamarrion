using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIInventoryBackButton : MyMonoBehaviour, IPointerDownHandler {
		public void OnPointerDown (PointerEventData eventData) {
			if(eventData.button == PointerEventData.InputButton.Left) {
				ContextPanel myContextPanel = GetComponentInParent<ContextPanel> ();
				Trigger(new CloseContextPanelEvent(myContextPanel));
			}
		}
	}
}
