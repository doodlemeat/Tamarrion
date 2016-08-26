using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SpellButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public string SpellName = "";

    private List<string> SpellButtonNames = new List<string>();
    private int SpellIndex = -1;
    private GameObject m_spell = null;
    //private bool Selected = false;

    void Start()
    {
        SpellManager SpellMngr = SpellManager.Instance;

        SpellButtonNames.Add("Spell A");
        SpellButtonNames.Add("Spell B");
        SpellButtonNames.Add("Spell X");
        SpellButtonNames.Add("Spell Y");

        for (int i = 0; i < SpellMngr.spells.Count; ++i)
        {
            if (!SpellMngr.spells[i].GetComponent<SpellBase>())
                continue;

            if (SpellMngr.spells[i].GetComponent<SpellBase>()._Name == SpellName)
            {
                SpellIndex = i;
                m_spell = SpellMngr.spells[SpellIndex].gameObject;
            }
        }

        if (SpellIndex == -1)
            return;

        transform.FindChild("Icon").GetComponent<RawImage>().texture = SpellMngr.spells[SpellIndex].GetComponent<SpellBase>()._spellIconMenu;
    }

    void Update()
    {
        for (int i = 0; i < SpellButtonNames.Count; ++i )
        {
            if (Input.GetButtonDown(SpellButtonNames[i]) && SpellSlotButton.spellSlotButton[i])
                SpellSlotButton.spellSlotButton[i].PlaceSelectedSpellInSlot();
        }
    }

    public void OnSelect(UnityEngine.EventSystems.BaseEventData data)
    {
        SelectSpell();
        //Selected = true;
    }

    public void OnDeselect(UnityEngine.EventSystems.BaseEventData data)
    {
        //Selected = false;
    }

    private void SelectSpell()
    {
        if (m_spell)
            GameObject.Find("SelectedSkill").GetComponent<SpellSelector>().SelectSpell(m_spell);
    }
}