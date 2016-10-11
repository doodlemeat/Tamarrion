using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace Tamarrion {
	public class ButtonScrollfocus : MonoBehaviour, ISelectHandler {
		public int buttonIndex = 0;

		public void OnSelect (BaseEventData data) {
			InventoryMenu.instance.scrollBar.value = 1 - ((float)buttonIndex / (InventoryMenu.instance.GetButtonCount () - 1));
		}
	}
}