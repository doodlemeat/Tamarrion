using UnityEngine;
using System.Collections.Generic;
namespace Tamarrion {
	public class ItemFiltersManager : MonoBehaviour {
		public static ItemFiltersManager instance;
		public Menu Menu;
		public Color ActiveColor = new Color ();
		public Color InactiveColor = new Color ();
		public Color ActiveTextColor = new Color ();
		public Color InactiveTextColor = new Color ();
		public string LeftButton;
		public string RightButton;
		public GameObject selectButton;
		public List<GameObject> FilterObjects = new List<GameObject> ();

		private bool Valid = false;
		private int CurrentObject = 0;

		void Awake () {
			instance = this;
		}

		void Start () {
			if ( FilterObjects.Count == 0 )
				return;

			Valid = true;
		}

		void Update () {
			if ( !Valid )
				return;

			if ( Menu && MenuManager.instance.CurrentMenu == Menu ) {
				if ( Input.GetButtonDown (LeftButton) )
					SelectLeft ();
				else if ( Input.GetButtonDown (RightButton) )
					SelectRight ();
			}
		}

		public void SelectLeft (bool p_selectFirstItem = true) {
			if ( CurrentObject == 0 )
				return;

			if ( selectButton )
				selectButton.GetComponent<UnityEngine.UI.Button> ().Select ();
			FilterObjects[CurrentObject].GetComponent<InventoryFilterButton> ().DeSelect ();
			FilterObjects[--CurrentObject].GetComponent<InventoryFilterButton> ().Select ();

			if ( p_selectFirstItem && InventoryMenu.instance )
				InventoryMenu.instance.SelectFirstItemButton ();
		}

		public void SetItemCathegoryByType (BaseItem.EItemType p_type) {
			for ( int i = 0; i < FilterObjects.Count; ++i ) {
				InventoryFilterButton invFilterButton = FilterObjects[i].GetComponent<InventoryFilterButton> ();

				if ( invFilterButton.Slot == p_type ) {
					FilterObjects[CurrentObject].GetComponent<InventoryFilterButton> ().DeSelect ();
					CurrentObject = i;
					invFilterButton.Select ();
				}
			}
		}

		public void SetItemCathegoryObject (GameObject p_targetObject) {
			for ( int i = 0; i < FilterObjects.Count; ++i ) {
				InventoryFilterButton invFilterButton = FilterObjects[i].GetComponent<InventoryFilterButton> ();

				if ( FilterObjects[i] == p_targetObject ) {
					FilterObjects[CurrentObject].GetComponent<InventoryFilterButton> ().DeSelect ();
					CurrentObject = i;
					invFilterButton.Select ();
				}
			}
		}

		public void SelectRight (bool p_selectFirstItem = true) {
			if ( CurrentObject == FilterObjects.Count - 1 )
				return;

			if ( selectButton )
				selectButton.GetComponent<UnityEngine.UI.Button> ().Select ();
			FilterObjects[CurrentObject].GetComponent<InventoryFilterButton> ().DeSelect ();
			FilterObjects[++CurrentObject].GetComponent<InventoryFilterButton> ().Select ();

			if ( p_selectFirstItem && InventoryMenu.instance )
				InventoryMenu.instance.SelectFirstItemButton ();
		}
	}
}