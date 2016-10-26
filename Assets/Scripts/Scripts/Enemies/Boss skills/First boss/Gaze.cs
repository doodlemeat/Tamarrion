using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Gaze : Base_EnemySkill {

        public int[] Minions_spawning;
        private float m_cd = 20.0f;

        public override void Start() {
            base.Start();
            m_name = "Gaze";
            m_max_cooldown = m_cd--;
            m_cd = m_cd < 10 ? 10 : m_cd;
            m_end_with_animation = false;
        }

        public override float CheckRelevance() {
            float delta_time = GetDeltaTime();
            if (m_cooldown > 0.0f) {
                m_cooldown -= delta_time;
                return 0.0f;
            }
            return 1000.0f;
        }
        protected override void StartUsingSkill() {
            base.StartUsingSkill();
            GameObject.Find("HUD").gameObject.transform.Find("Hide").GetComponent<RectTransform>().gameObject.SetActive(true);

            int[] spawn = { Minions_spawning[(int)DifficultyManager.current] };
            Minion_Spawner.valac.Spawn_minions(spawn);
        }
    }
}