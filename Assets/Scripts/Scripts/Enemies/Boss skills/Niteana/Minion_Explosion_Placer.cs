﻿using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Minion_Explosion_Placer : MonoBehaviour {
        //private Vector3 m_boss;

        public Base_EnemySkill_Telegraph Telegrapher;
        //public float[] Stones = new float[3], FallRadius = new float[3];
        public float[] spawning_time;
        private float m_time_spawned = 0.0f;
        private float[] m_spawns;

        void Start() {
            //m_boss = Valac.instance.transform.position;
            m_time_spawned = 0.0f;

            m_spawns = new float[Nihteana.instance.minionDeaths.Count];

            for (int i = 0; i < m_spawns.Length; i++) {
                m_spawns[i] = Random.Range(0.0f, spawning_time[(int)DifficultyManager.current]);
            }
            Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Minion Explosion", false);
        }
        void Update() {
            if (m_time_spawned >= spawning_time[(int)DifficultyManager.current] || !Nihteana.instance) {
                //Debug.Log("Before clear: " + Nihteana.instance.minionDeaths.Count);
                Nihteana.instance.minionDeaths.Clear();
                //Debug.Log("Clear minions deaths: " + Nihteana.instance.minionDeaths.Count);
                Destroy(gameObject);
            }
            m_time_spawned += Time.deltaTime;
            m_time_spawned = m_time_spawned > spawning_time[(int)DifficultyManager.current] ? spawning_time[(int)DifficultyManager.current] : m_time_spawned;
            for (int i = 0; i < m_spawns.Length; i++) {
                if (m_spawns[i] != 0 && m_spawns[i] < m_time_spawned) {
                    //Vector3 position = Random.insideUnitSphere * FallRadius[(int)Difficulty.Current_difficulty];
                    Telegrapher.m_boss = Nihteana.instance.gameObject;
                    Instantiate(Telegrapher, Nihteana.instance.minionDeaths[i], Quaternion.identity);
                    m_spawns[i] = 0;
                }
            }
        }
    }
}