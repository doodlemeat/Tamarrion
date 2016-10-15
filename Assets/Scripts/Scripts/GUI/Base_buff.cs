using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Base_buff : MonoBehaviour {
        public float active_time = 0.0f;
        private float time_active = 0.0f;
        public string buff_name = "";
        public GameObject target;

        public float GetTimeLeft() {
            if (active_time != 0.0f) {
                time_active += Time.deltaTime;
                return 1.0f - (time_active / active_time);
            }
            return 0.0f;
        }

        public void Update_buff(float p_time) {
            active_time = p_time;
            time_active = 0.0f;
        }

        public void BuffEnded() {
            if (target)
                target.GetComponent<CombatStats>().Remove_Modifier(buff_name);
            //Debug.Log("Buff " + buff_name + " ended");
            Destroy(gameObject);
        }
    }
}