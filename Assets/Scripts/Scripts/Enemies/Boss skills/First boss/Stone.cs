using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Stone : MonoBehaviour {

        private Vector3 m_boss;

        public Base_EnemySkill_Telegraph Telegrapher;
        public float[] Stones = new float[3], FallRadius = new float[3];
        public float spawning_time = 0.0f;
        private float m_time_spawned = 0.0f;
        private float[] m_spawns;

        void Start() {
            m_boss = Valac.instance.transform.position;
            m_time_spawned = 0.0f;

            m_spawns = new float[(int)Stones[(int)DifficultyManager.current]];

            for (int i = 0; i < m_spawns.Length; i++) {
                m_spawns[i] = Random.Range(0.0f, spawning_time);
            }
        }
        void Update() {
            if (m_time_spawned > spawning_time) {
                Destroy(gameObject);
            }
            m_time_spawned += Time.deltaTime;
            m_time_spawned = m_time_spawned > spawning_time ? spawning_time : m_time_spawned;
            for (int i = 0; i < m_spawns.Length; i++) {
                if (m_spawns[i] != 0 && m_spawns[i] < m_time_spawned) {
                    Vector3 position = Random.insideUnitSphere * FallRadius[(int)DifficultyManager.current];
                    Telegrapher.m_boss = Valac.instance.gameObject;
                    Instantiate(Telegrapher, new Vector3(m_boss.x + position.x, m_boss.y, m_boss.z + position.z), Quaternion.identity);
                    m_spawns[i] = 0;
                }
            }
        }
    }
}