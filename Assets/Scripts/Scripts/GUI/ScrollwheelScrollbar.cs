using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace Tamarrion {
	[RequireComponent (typeof (Scrollbar))]

	public class ScrollwheelScrollbar : MonoBehaviour {
		public float scrollSensitivity = 1;
		Scrollbar scrollBar;

		void Start () {
			scrollBar = GetComponent<Scrollbar> ();
		}

		public void OnMouseScrollEvent (BaseEventData p_eventData) {
			scrollBar.value += ((PointerEventData)p_eventData).scrollDelta.y * scrollSensitivity;
		}
	}
}