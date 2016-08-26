using UnityEngine;
using System.Collections;

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

        m_spawns = new float[Nihteana.instance.minion_deaths.Count];

        for (int i = 0; i < m_spawns.Length; i++) {
            m_spawns[i] = Random.Range(0.0f, spawning_time[(int)Difficulty.Current_difficulty]);
        }
        Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Minion Explosion", false);
    }
    void Update() {
        if (m_time_spawned >= spawning_time[(int)Difficulty.Current_difficulty] || !Nihteana.instance) {
            //Debug.Log("Before clear: " + Nihteana.instance.minion_deaths.Count);
            Nihteana.instance.minion_deaths.Clear();
            //Debug.Log("Clear minions deaths: " + Nihteana.instance.minion_deaths.Count);
            Destroy(gameObject);
        }
        m_time_spawned += Time.deltaTime;
        m_time_spawned = m_time_spawned > spawning_time[(int)Difficulty.Current_difficulty] ? spawning_time[(int)Difficulty.Current_difficulty] : m_time_spawned;
        for (int i = 0; i < m_spawns.Length; i++) {
            if (m_spawns[i] != 0 && m_spawns[i] < m_time_spawned) {
                //Vector3 position = Random.insideUnitSphere * FallRadius[(int)Difficulty.Current_difficulty];
                Telegrapher.m_boss = Nihteana.instance.gameObject;
                Instantiate(Telegrapher, Nihteana.instance.minion_deaths[i], Quaternion.identity);
                m_spawns[i] = 0;
            }
        }
    }
}
