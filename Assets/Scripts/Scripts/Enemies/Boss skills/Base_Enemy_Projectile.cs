using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Base_Enemy_Projectile : MonoBehaviour {
        public Vector3 Origin, Target;
        public float Speed, Acceleration, AccelerateAcceleration, LifeTime;
        private float traveled = 0;
        public float HitRadius;
        public float Damage;
        //private Vector3 m_direction;

        protected virtual void Start() {
            transform.position = Origin;
            //m_direction = Vector3.Normalize(Origin - Target);
            transform.LookAt(Target);
            traveled = 0;
        }
        void Update() {
            Acceleration += AccelerateAcceleration * Time.deltaTime;
            Speed += Acceleration * Time.deltaTime;
            transform.position += transform.forward * Time.deltaTime * Speed;
            if (Vector3.Distance(transform.position, Player.player.transform.position) <= HitRadius)
                OnHitEffect();
            traveled += Time.deltaTime;
            if (traveled >= LifeTime)
                Destroy(gameObject);
        }
        protected virtual void OnHitEffect() {
            Destroy(gameObject);
        }
    }
}