using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Slam : Base_EnemySkill {

        public float Angle, Distance;

        public override void Start() {
            base.Start();
            m_name = "Slam";
        }

        public override float CheckRelevance() {
            float delta_time = GetDeltaTime();
            if (m_cooldown > 0.0f) {
                m_cooldown -= delta_time;
                return 0.0f;
            }
            m_bonus_relevance += delta_time;
            float relevance = 180.0f + (4.4f - Vector3.Distance(m_player.position, m_boss.position)) * 30.0f + m_bonus_relevance;
            relevance = relevance > 240.0f ? 240.0f : relevance;
            return CloseEnough(Angle, Distance) ? relevance : 0.0f;
        }
    }
}