using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Pool : Base_EnemySkill {

        public float Min_Range_to_Use;

        public override void Start() {
            base.Start();
            m_name = "Pool";
        }

        public override float CheckRelevance() {
            if (m_boss == null || m_player == null)
                return 0.0f;
            float delta_time = GetDeltaTime();
            if (m_cooldown > 0.0f) {
                m_cooldown -= delta_time;
                return 0.0f;
            }
            m_bonus_relevance += delta_time;
            float relevance = 250.0f + Vector3.Distance(m_player.position, m_boss.position) * 1.5f + m_bonus_relevance;
            relevance = Vector3.Distance(m_player.position, m_boss.position) < Min_Range_to_Use ? 0.0f : relevance;
            relevance = relevance > 500.0f ? 500.0f : relevance;
            return relevance;
        }
        protected override void StartUsingSkill() {
            base.StartUsingSkill();
            /*if (m_boss.GetComponent<Enemy_Base>().Phase >= 2) {
                m_player.GetComponent<PlayerStats>().MovementSpeed = 3.0f;
            }*/
        }
        protected override void EndUsingSkill() {
            /*if (m_boss.GetComponent<Enemy_Base>().Phase >= 2) {
                m_player.GetComponent<PlayerStats>().MovementSpeed = 6.0f;
            }*/
        }
    }
}