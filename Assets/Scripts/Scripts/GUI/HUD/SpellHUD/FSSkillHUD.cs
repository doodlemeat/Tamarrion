using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Tamarrion {
    public class FSSkillHUD : MonoBehaviour {
        public FSSkillManager skillManager;
        public FSSkillUser skillUser;
        public int Slot = 0;
        public RawImage skillIconObject;
        public RawImage BorderObject;
        public Image cooldownOverlay;
        public CanvasGroup canvasGroup;
        public GameObject cdFX;
        FSSkillBase Skill;
        bool m_initSuccessful = false;

        enum SkillHUDState {
            Inactive,
            Active,
        }

        SkillHUDState m_state = SkillHUDState.Inactive;

        void Start() {
            InitiateSkill();

            if (m_initSuccessful)
                SetStateToInactive();
            else
                DeactivateSkillHUD();
        }

        void InitiateSkill() {
            if (skillUser == null) {
                Debug.LogError("no skilluser set");
                return;
            }

			Skill = SkillManager.GetSkillInSlot (Slot);
            if ( Skill == null) {
                return;
            }

            if (skillIconObject == null) {
                Debug.LogError("no icon object found");
                return;
            }

            if ( Skill.skillIcon)
                skillIconObject.texture = Skill.skillIcon;

            if (BorderObject == null) {
                Debug.LogError("no border object found");
                return;
            }

            if (cooldownOverlay == null) {
                Debug.LogError("no cooldown overlay object found");
                return;
            }

            if ( Skill.element == FSSkillElement.FS_Elem_Holy)
                BorderObject.color = skillManager.ColorHoly;
            else if ( Skill.element == FSSkillElement.FS_Elem_Magic)
                BorderObject.color = skillManager.ColorMagic;
            else if ( Skill.element == FSSkillElement.FS_Elem_Defense)
                BorderObject.color = skillManager.ColorDefense;
            else if ( Skill.element == FSSkillElement.FS_Elem_Nature)
                BorderObject.color = skillManager.ColorNature;
            else if ( Skill.element == FSSkillElement.FS_Elem_War)
                BorderObject.color = skillManager.ColorWar;

            m_initSuccessful = true;
        }

        void DeactivateSkillHUD() {
            if (canvasGroup)
                canvasGroup.alpha = 0.2f;
        }

        void Update() {
            if (!m_initSuccessful)
                return;

            CheckStateChange();
            UpdateCooldownVisual();
        }

        void UpdateCooldownVisual() {
            if ( Skill && cooldownOverlay && !Skill.cooldownTimer.IsComplete) {
                float Fill = Skill.cooldownTimer.PercentComplete();
                cooldownOverlay.fillAmount = Fill;
                cdFX.SetActive(false);
            }
        }

        void CheckStateChange() {
            if (skillUser.GetCurrentSkill() != Skill && m_state != SkillHUDState.Inactive)
                SetStateToInactive();
            else if (skillUser.GetCurrentSkill() == Skill && m_state != SkillHUDState.Active)
                SetStateToActive();
            cdFX.SetActive(true);
        }

        void SetStateToInactive() {
            m_state = SkillHUDState.Inactive;
            BorderObject.color = new Color(BorderObject.color.r, BorderObject.color.g, BorderObject.color.b, 0);
        }

        void SetStateToActive() {
            m_state = SkillHUDState.Active;
            BorderObject.color = new Color(BorderObject.color.r, BorderObject.color.g, BorderObject.color.b, 255);
        }
    }
}