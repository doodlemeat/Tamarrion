using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellIconHUD : MonoBehaviour
{
    public int Slot = 0;
    public Color StartColor = new Color(0, 0, 0, 1);
    public Color EndColor = new Color(1, 1, 1, 1);

    private Texture m_textureEmpty = null;
    GameObject m_player = null;
    SpellManager Manager;
    SpellBase Spell;
    private Image CooldownOverlay;
    private bool ButtonLoaded = false;

    void Start()
    {
        m_player = Player.player.gameObject;
        m_textureEmpty = GetComponent<RawImage>().texture;
        CooldownOverlay = transform.FindChild("CooldownOverlay").gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (!ButtonLoaded)
        {
            Manager = Player.player.gameObject.GetComponentInChildren<SpellManager>();
            if (!Manager.GetLoaded())
                return;

            if (Manager.GetSpellIndexInSlot(Slot) != -1)
                CheckTexture();

            ButtonLoaded = true;
        }

        if (Spell && !Spell.isCool())
        {
            float Fill = Spell.GetComponent<SpellBase>().CooldownRemainingPercent();
            CooldownOverlay.fillAmount = Fill;
            CooldownOverlay.color = Color.Lerp(StartColor, EndColor, Fill);
        }
    }

    void CheckTexture()
    {
        SpellManager Manager = m_player.GetComponent<SpellManager>();
        if (Manager.GetSpellIndexInSlot(Slot) != -1)
        {
            Spell = Manager.GetSpellInSlot(Slot).GetComponent<SpellBase>();
            if (Spell._spellIconIngame)
                GetComponent<RawImage>().texture = Spell._spellIconIngame;
            if (Spell._spellIconCooldown)
                GetComponentInChildren<Image>().sprite = Spell._spellIconCooldown;
        }
        else
        {
            Spell = null;
            GetComponent<RawImage>().texture = m_textureEmpty;
        }
    }
}