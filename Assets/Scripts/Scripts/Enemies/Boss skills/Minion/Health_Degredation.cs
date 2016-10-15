using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Health_Degredation : Base_EnemySkill {

        public override void Start() {
            base.Start();
            m_name = "HealthDeg";
        }

        public override float CheckRelevance() {
            float delta_time = GetDeltaTime();
            if (m_cooldown > 0.0f) {
                m_cooldown -= delta_time;
                return 0.0f;
            }
            if (!Nihteana.instance.Active) {
                return 0.0f;
            }
            return 100.0f;
        }
    }
}