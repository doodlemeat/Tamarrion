using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Heal : Base_EnemySkill {

        public float Min_Range_to_Use;
        private Enemy_Stats m_Enemy_Stats;

        public override void Start() {
            base.Start();
            m_name = "Heal";
            m_end_with_animation = false;

            m_Enemy_Stats = Valac.instance.GetComponent<Enemy_Stats>();
            m_Enemy_Stats.DamageTaken = false;
        }

        public override float CheckRelevance() {
            float delta_time = GetDeltaTime();
            if (m_cooldown > 0.0f) {
                m_cooldown -= delta_time;
                return 0.0f;
            }
            else if (m_Enemy_Stats.GetPercentageHP() > 0.5f) {
                return 0.0f;
            }
            return Vector3.Distance(m_player.position, m_boss.position) < Min_Range_to_Use ? 0.0f : 750.0f;
        }
    }
}