using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace Tamarrion {
	public class ItemButton : MonoBehaviour, ISelectHandler {
		public GameObject Item;

		void Start () {
			GetComponent<UnityEngine.UI.Button> ().onClick.AddListener (() => { OnClick (); });
		}

		public void UpdateToItem () {
			Texture Tex = Item.GetComponent<BaseItem> ().itemIcon;
			if ( Tex )
				GetComponentInChildren<UnityEngine.UI.RawImage> ().texture = Tex;

			UnityEngine.UI.Text infoText = GetComponentInChildren<UnityEngine.UI.Text> ();
			if ( infoText ) {
				infoText.text = Item.GetComponent<BaseItem> ().itemName;
			}
		}

		public void OnSelect (BaseEventData data) {
			for ( int i = 0; i < InventoryManager.inventoryManager.AvailableItems.Count; ++i ) {
				if ( InventoryManager.inventoryManager.AvailableItems[i] == Item )
					InventoryManager.inventoryManager.SelectedItem = i;
			}
		}

		void OnClick () {
			SlotButton slotButton = SlotButton.slotButtons[(int)Item.GetComponent<BaseItem> ().type];
			slotButton.EquipSelectedItem ();
			slotButton.SelectItemInSlot ();
		}
	}
}