using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Grave_Desecration_Spawner : MonoBehaviour {

        public Grave_Desecration_Updater grave_desecration;
        public Vector3[] grave_locations;
        public float distane_activate = 1.0f;
        public float[] cooldown;
        private float time_since_cast = 0.0f;

        void Start() {

        }
        void Update() {
            if (time_since_cast < cooldown[(int)DifficultyManager.current]) {
                time_since_cast += Time.deltaTime;
                return;
            }
            foreach (Vector3 v in grave_locations) {
                if (Vector3.Distance(v, Player.player.transform.position) <= distane_activate) {
                    time_since_cast = 0.0f;
                    grave_desecration.m_boss = Nihteana.instance.gameObject;
                    Instantiate(grave_desecration, v, Quaternion.identity);
                    return;
                }
            }
        }
    }
}