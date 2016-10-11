using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Tamarrion {
	public class InventoryFilterButton : MonoBehaviour {
		public bool FiltersOn = true;
		public BaseItem.EItemType Slot = BaseItem.EItemType.Generic;
		public string ScrollbarName = "InventoryScrollbar";

		private Scrollbar scrollbar;

		void Start () {
			scrollbar = GameObject.Find (ScrollbarName).GetComponent<Scrollbar> ();
		}

		public void DeSelect () {
			gameObject.GetComponent<RawImage> ().color = ItemFiltersManager.instance.InactiveColor;
			gameObject.GetComponentInChildren<Text> ().color = ItemFiltersManager.instance.InactiveTextColor;
		}

		public void Select () {
			gameObject.GetComponent<RawImage> ().color = ItemFiltersManager.instance.ActiveColor;
			gameObject.GetComponentInChildren<Text> ().color = ItemFiltersManager.instance.ActiveTextColor;
			if ( FiltersOn )
				InventoryMenu.instance.ApplyFilters (Slot);
			else
				InventoryMenu.instance.GetComponent<InventoryMenu> ().RemoveFilters ();

			StartCoroutine ("ResetScrollbar");
		}

		IEnumerator ResetScrollbar () {
			if ( scrollbar ) {
				yield return scrollbar.value = 0;
				yield return scrollbar.value = 1;
			}
			else {
				yield return GameObject.Find (ScrollbarName).GetComponent<Scrollbar> ().value = 0;
				yield return GameObject.Find (ScrollbarName).GetComponent<Scrollbar> ().value = 1;
			}
		}
	}
}