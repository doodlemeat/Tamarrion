using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
    public class InventoryMenu : MonoBehaviour {
        public static InventoryMenu instance;
        public GameObject ItemButton;
        public Scrollbar scrollBar;

        private Vector2 OriginalSize;
        private bool FiltersOn = false;
        private BaseItem.EItemType FiltersType = BaseItem.EItemType.Ring;
        private int buttonCount = 0;
        private Button FirstItemButton;

        void Awake() {
            instance = this;
        }

        void BuildInventoryButtons() {
            if (OriginalSize.y == 0)
                OriginalSize = GetComponent<RectTransform>().sizeDelta;

            buttonCount = 0;
            FirstItemButton = null;

            //remove existing buttons
            foreach (Transform child in gameObject.transform) {
                GetComponent<RectTransform>().localPosition += new Vector3(0, +OriginalSize.y / 2, 0);
                Destroy(child.gameObject);
            }

            //build new buttons
            GetComponent<RectTransform>().sizeDelta = OriginalSize;
            bool FirstItem = true;

            for (int i = 0; i < InventoryManager.inventoryManager.inventoryItems.Count; ++i) {
                GameObject TempItem = InventoryManager.inventoryManager.AvailableItems[InventoryManager.inventoryManager.inventoryItems[i]];
                if (FiltersOn && TempItem.GetComponent<BaseItem>().type != FiltersType)
                    continue;

                if (!FirstItem) {
                    RectTransform Trans = GetComponent<RectTransform>();
                    Trans.sizeDelta = Trans.sizeDelta + new Vector2(0, OriginalSize.y);
                    Trans.localPosition = Trans.localPosition - new Vector3(0, OriginalSize.y / 2, 0);
                }

                ++buttonCount;

                GameObject NewButton = GameObject.Instantiate(ItemButton);
                NewButton.transform.SetParent(gameObject.transform);

                if (NewButton.GetComponent<ButtonScrollfocus>())
                    NewButton.GetComponent<ButtonScrollfocus>().buttonIndex = i;

                ItemButton ItemButtonScript = NewButton.GetComponent<ItemButton>();
                ItemButtonScript.Item = TempItem;
                ItemButtonScript.UpdateToItem();

                if (FirstItem) {
                    FirstItemButton = NewButton.GetComponent<Button>();
                    FirstItem = false;
                }
            }

            UnityEngine.UI.Scrollbar scrollBar = GameObject.Find("InventoryScrollbar").GetComponent<UnityEngine.UI.Scrollbar>();
            scrollBar.value = 1;
        }

        public void RemoveFilters() {
            FiltersOn = false;
            BuildInventoryButtons();
        }

        public void ApplyFilters(BaseItem.EItemType p_filtersType) {
            FiltersOn = true;
            FiltersType = p_filtersType;
            BuildInventoryButtons();
        }

        public void SelectFirstItemButton() {
            if (FirstItemButton)
                FirstItemButton.Select();
        }

        public int GetButtonCount() {
            return buttonCount;
        }
    }
}