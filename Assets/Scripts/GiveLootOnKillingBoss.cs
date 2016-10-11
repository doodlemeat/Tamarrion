using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	public class GiveLootOnKillingBoss : MonoBehaviour {
		public void GiveLoot (int p_item) {
			if ( p_item < 0 )
				return;
			//Debug.Log(InventoryManager.inventoryManager.AvailableItems.Count + " / " + p_item);
			if ( InventoryManager.inventoryManager.AvailableItems.Count > p_item ) {
				InventoryManager.inventoryManager.inventoryItems.Add (p_item);
				GetComponent<RawImage> ().texture = InventoryManager.inventoryManager.AvailableItems[p_item].GetComponent<StatsItem> ().itemIcon;
				GetComponent<RawImage> ().color = Color.white;
			}
		}
	}
}