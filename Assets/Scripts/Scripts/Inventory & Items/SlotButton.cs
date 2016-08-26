using UnityEngine;
using System.Collections;

public class SlotButton : MonoBehaviour
{
    public static SlotButton[] slotButtons = null;
    public BaseItem.EItemType Slot;
    private InventoryManager InvManager = null;
    private Texture BaseIcon;

    private bool Loaded = false;

    void Awake()
    {
        if (slotButtons == null)
        {
            slotButtons = new SlotButton[(int)BaseItem.EItemType.Count];
        }
        slotButtons[(int)Slot] = this;
    }

    void Start()
    {
        InvManager = Player.player.gameObject.GetComponentInChildren<InventoryManager>();
        BaseIcon = GetComponent<UnityEngine.UI.RawImage>().texture;
        gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = Slot.ToString();

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            EquipSelectedItem();
            SelectItemInSlot();
        });
    }

    void OnDisable()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.RemoveListener(() =>
        {
            EquipSelectedItem();
            SelectItemInSlot();
        });
    }

    void Update()
    {
        if (!Loaded)
        {
            if (InventoryManager.inventoryManager.GetLoaded())
            {
                UpdateTexture();
            }
        }
    }

    public void EquipSelectedItem()
    {
        InvManager.EquipSelectedItemInSlot(Slot);
        //InvManager.SelectedItem = -1;
    }

    public void SelectItemInSlot()
    {
        InvManager.SelectedItem = InvManager.equipped[(int)Slot];
        ItemInfo.itemInfo.UpdateToSelected();
        for (int i = 0; i < (int)BaseItem.EItemType.Count; ++i)
        {
            if (slotButtons[i])
                slotButtons[i].UpdateTexture();
        }
    }

    public void UpdateTexture()
    {
        if (InvManager.equipped[(int)Slot] != -1)
        {
            BaseItem ItemScript = InvManager.AvailableItems[InvManager.equipped[(int)Slot]].GetComponent<BaseItem>();
            if (ItemScript.itemIcon)
            {
                GetComponent<UnityEngine.UI.RawImage>().texture = ItemScript.itemIcon;
            }
        }
        else
            GetComponent<UnityEngine.UI.RawImage>().texture = BaseIcon;
    }
}