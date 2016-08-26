using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellSlotButton : MonoBehaviour
{
    public int Slot = 0;
    public static SpellSlotButton[] spellSlotButton = new SpellSlotButton[4];

    private SpellManager Manager;
    private Texture EmptyTexture;
    private bool SlotEquipped = false;

    void Start()
    {
        EmptyTexture = transform.FindChild("Icon").GetComponent<RawImage>().texture;
        
        if (Slot >= 0 && Slot <= spellSlotButton.Length - 1)
        {
            spellSlotButton[Slot] = this;
        }
    }

    void Update()
    {
        if (!SlotEquipped)
        {
            Manager = Player.player.gameObject.GetComponentInChildren<SpellManager>();
            if (!Manager.GetLoaded())
                return;

            if (Manager.GetSpellIndexInSlot(Slot) != -1)
            {
                if (Manager.GetSpellInSlot(Slot).GetComponent<SpellBase>()._spellIconIngame)
                    transform.FindChild("Icon").GetComponent<RawImage>().texture = Manager.GetSpellInSlot(Slot).GetComponent<SpellBase>()._spellIconIngame;
                SlotEquipped = true;
            }
        }

        if (SlotEquipped && Manager.GetSpellIndexInSlot(Slot) == -1)
        {
            SlotEquipped = false;
            transform.FindChild("Icon").GetComponent<RawImage>().texture = EmptyTexture;
        }
    }

    public void PlaceSelectedSpellInSlot()
    {
        SpellSelector Selector = GameObject.Find("SelectedSkill").GetComponent<SpellSelector>();

        if (!Selector.GetSelected())
        {
            return;
        }
        Manager.selectSpellByName(Selector.GetSelected().name, Slot);
        transform.FindChild("Icon").GetComponent<RawImage>().texture = Selector.GetSelected().GetComponent<SpellBase>()._spellIconIngame;
        SlotEquipped = true;

        // Update file with selected spell information

    }
}