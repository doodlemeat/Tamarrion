using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minion_Spawner : MonoBehaviour {

    public static Minion_Spawner valac, niteana;
    public bool this_is_valac, this_is_niteana;

    public bool disable_minion_spawning = false;

    public List<GameObject> Minions = new List<GameObject>();
    public List<Vector3> Spawn_points = new List<Vector3>();
    private List<Vector3> m_spawn = new List<Vector3>();

    void Awake() {
        if (this_is_valac)
            valac = this;
        if (this_is_niteana)
            niteana = this;
    }

    public void Spawn_minions(int[] numbers) {
        if (disable_minion_spawning)
            return;
        Reset_spawns();
        for (int i = 0; i < numbers.Length; i++) {
            for (int j = 0; j < numbers[i]; j++) {
                Vector3 position = Get_spawn_position();

                GameObject minion = Instantiate(Minions[i]);
                minion.GetComponent<NavMeshAgent>().Warp(position);
                //minion.transform.position = position;
            }
        }
    }
    private Vector3 Get_spawn_position() {
        int random = Random.Range(0, m_spawn.Count - 1);
        Vector3 position = m_spawn[random];

        m_spawn.RemoveAt(random);
        if (m_spawn.Count <= 0)
            Reset_spawns();

        return position;
    }
    private void Reset_spawns() {
        m_spawn = new List<Vector3>();
        foreach (Vector3 v in Spawn_points) {
            m_spawn.Add(v);
        }
    }
}