using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class FSObjectArea : MonoBehaviour {
        public bool timed = false;
        TopgunTimer durationTimer = new TopgunTimer();
        protected List<GameObject> m_enemiesWithinBounds = new List<GameObject>();
        protected bool m_PlayerIsWithinBounds = false;
        public float MagicDamagePercentage = 1f;
        public float PhysicalDamagePercentage = 1f;

        virtual public void Start() {

        }

        virtual public void Update() {
            if (timed) {
                durationTimer.Update();
                if (durationTimer.IsComplete)
                    DestroyThis();
            }
        }

        public void SetDuration(float p_dur) {
            timed = true;
            durationTimer.StartTimerBySeconds(p_dur);
        }

        public virtual void SetSphereCollisionRadius(float p_radius) {
            SphereCollider col = gameObject.GetComponent<SphereCollider>();
            col.radius = p_radius;
        }

        public virtual void SetBoxCollisionSize(float p_height, float p_width) {
            BoxCollider col = gameObject.GetComponent<BoxCollider>();
            col.size = new Vector3(p_height, col.size.y, p_width);
        }

        void DestroyThis() {
            foreach (Transform child in transform) {
                if (child.GetComponent<ParticleSystem>() && child.GetComponent<AutoDestroyParticleSystem>())
                    child.SetParent(null);
            }
            Destroy(gameObject);
        }

        virtual protected void OnTriggerEnter(Collider other) {
            if (Player.GameObjectIsPlayer(other.gameObject)) {
                m_PlayerIsWithinBounds = true;
            }

            if (other.CompareTag("Force"))
                return;

            if (other.gameObject.transform.parent) {
                if (Enemy_List.GameObjectIsEnemy(other.gameObject.transform.parent.gameObject) && !m_enemiesWithinBounds.Contains(other.gameObject.transform.parent.gameObject)) {
                    m_enemiesWithinBounds.Add(other.gameObject.transform.parent.gameObject);
                }
            }
        }

        protected virtual void OnTriggerExit(Collider other) {
            if (Player.GameObjectIsPlayer(other.gameObject)) {
                m_PlayerIsWithinBounds = false;
            }

            if (other.CompareTag("Force"))
                return;

            if (other.gameObject.transform.parent) {
                if (Enemy_List.GameObjectIsEnemy(other.gameObject.transform.parent.gameObject) && m_enemiesWithinBounds.Contains(other.gameObject.transform.parent.gameObject)) {
                    m_enemiesWithinBounds.Remove(other.gameObject.transform.parent.gameObject);
                }
            }
        }
    }
}