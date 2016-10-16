using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Tamarrion {
    public class PlayerCastbar : MonoBehaviour {
        public enum CastState {
            Cast,
            Channel,
        }

        public static PlayerCastbar castbar = null;
        public float FadeOutTime = 0.5f;

        CastState m_castState = CastState.Cast;
        Image progressBar = null;
        FSSkillBase castingSkill = null;
        float FadeCurrent = 0;
        CanvasGroup canvasGroup;

        void Awake() {
            castbar = this;
        }

        void Start() {
            progressBar = GetComponentInChildren<Image>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
        }

        void Update() {
            if (castingSkill == null) {
                if (canvasGroup.alpha == 0)
                    return;

                if (FadeCurrent > 0) {
                    FadeCurrent -= Time.deltaTime;
                    if (FadeCurrent < 0)
                        FadeCurrent = 0;

                    canvasGroup.alpha = FadeCurrent / FadeOutTime;
                }
                return;
            }

            if (m_castState == CastState.Cast)
                progressBar.fillAmount = 1 - FSSkillUser.m_castingTimer.PercentComplete();
            else if (m_castState == CastState.Channel)
                progressBar.fillAmount = FSSkillUser.m_channelTimer.PercentComplete();

            if (m_castState == CastState.Cast && castingSkill.GetCurrentState() != FSSkillStates.FS_State_Casting) {
                FadeCurrent = FadeOutTime;
                castingSkill = null;
            }
            else if (m_castState == CastState.Channel && castingSkill.GetCurrentState() != FSSkillStates.FS_State_Channeling) {
                FadeCurrent = FadeOutTime;
                castingSkill = null;
            }
        }

        public void OnSpellcast(FSSkillBase p_skill, CastState p_state = CastState.Cast) {
            if (p_skill == null)
                return;

            m_castState = p_state;
            castingSkill = p_skill;

            GetComponentInChildren<Text>().text = castingSkill.skillName;
            canvasGroup.alpha = 1;
			progressBar.color = castingSkill.Element.Color;
        }
    }
}