using UnityEngine;
using System.Collections;

public class FSSkillHUD : MonoBehaviour
{
    public FSSkillManager skillManager;
    public FSSkillUser skillUser;
    public int skillSlot = 0;
    public UnityEngine.UI.RawImage skillIconObject;
    public UnityEngine.UI.RawImage BorderObject;
    public UnityEngine.UI.Image cooldownOverlay;
    public UnityEngine.CanvasGroup canvasGroup;
	public GameObject cdFX;
    FSSkillBase m_connectedSkill;
    bool m_initSuccessful = false;

    enum SkillHUDState
    {
        Inactive,
        Active,
    }

    SkillHUDState m_state = SkillHUDState.Inactive;

    void Start()
    {
        InitiateSkill();

        if (m_initSuccessful)
            SetStateToInactive();
        else
            DeactivateSkillHUD();
    }

    void InitiateSkill()
    {
        if (skillManager == null)
        {
            Debug.LogError("no skillmanager set");
            return;
        }
        
        if (skillUser == null)
        {
            Debug.LogError("no skilluser set");
            return;
        }

        m_connectedSkill = skillManager.GetSkillInSlot(skillSlot);
        if (m_connectedSkill == null)
        {
            return;
        }

        if (skillIconObject == null)
        {
            Debug.LogError("no icon object found");
            return;
        }

        if (m_connectedSkill.skillIcon)
            skillIconObject.texture = m_connectedSkill.skillIcon;

        if (BorderObject == null)
        {
            Debug.LogError("no border object found");
            return;
        }

        if (cooldownOverlay == null)
        {
            Debug.LogError("no cooldown overlay object found");
            return;
        }

        if (m_connectedSkill.element == FSSkillElement.FS_Elem_Holy)
            BorderObject.color = skillManager.ColorHoly;
        else if (m_connectedSkill.element == FSSkillElement.FS_Elem_Magic)
            BorderObject.color = skillManager.ColorMagic;
        else if (m_connectedSkill.element == FSSkillElement.FS_Elem_Defense)
            BorderObject.color = skillManager.ColorDefense;
        else if (m_connectedSkill.element == FSSkillElement.FS_Elem_Nature)
            BorderObject.color = skillManager.ColorNature;
        else if (m_connectedSkill.element == FSSkillElement.FS_Elem_War)
            BorderObject.color = skillManager.ColorWar;

        m_initSuccessful = true;
    }

    void DeactivateSkillHUD()
    {
        if (canvasGroup)
            canvasGroup.alpha = 0.2f;
    }

    void Update()
    {
        if (!m_initSuccessful)
            return;

        CheckStateChange();
        UpdateCooldownVisual();
    }

    void UpdateCooldownVisual()
    {
        if (m_connectedSkill && cooldownOverlay && !m_connectedSkill.cooldownTimer.IsComplete)
        {
            float Fill = m_connectedSkill.cooldownTimer.PercentComplete();
            cooldownOverlay.fillAmount = Fill;
			cdFX.SetActive(false);
            //cooldownOverlay.color = Color.Lerp(StartColor, EndColor, Fill);
        }
    }

    void CheckStateChange()
    {
        if (skillUser.GetCurrentSkill() != m_connectedSkill && m_state != SkillHUDState.Inactive)
            SetStateToInactive();
        else if (skillUser.GetCurrentSkill() == m_connectedSkill && m_state != SkillHUDState.Active)
            SetStateToActive();
		cdFX.SetActive(true);
    }

    void SetStateToInactive()
    {
        m_state = SkillHUDState.Inactive;
        BorderObject.color = new Color(BorderObject.color.r, BorderObject.color.g, BorderObject.color.b, 0);
    }

    void SetStateToActive()
    {
        m_state = SkillHUDState.Active;
        BorderObject.color = new Color(BorderObject.color.r, BorderObject.color.g, BorderObject.color.b, 255);
    }
}
