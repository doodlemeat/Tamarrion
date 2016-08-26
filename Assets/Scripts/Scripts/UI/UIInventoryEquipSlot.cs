using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Tamarrion {
	public class UIInventoryEquipSlot : MyMonoBehaviour, IPointerDownHandler {
		void Start () {

		}

		void Update () {

		}

		public void OnPointerDown(PointerEventData e) {
			Trigger (new UIInventoryItemEquipEvent());
		}
	}
}