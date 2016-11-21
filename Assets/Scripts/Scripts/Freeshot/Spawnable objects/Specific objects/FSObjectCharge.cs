using UnityEngine;
using System.Collections.Generic;

namespace Tamarrion {
    public class FSObjectCharge : MonoBehaviour {
        public float ChargeHitDamage = 200f;
        List<GameObject> enemiesHit = new List<GameObject>();
        public float PhysicalDamagePercentage = 1f;

        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Force"))
                return;

            if (other.gameObject.transform.parent) {
                if (Enemy_List.GameObjectIsEnemy(other.gameObject.transform.parent.gameObject) && !enemiesHit.Contains(other.gameObject.transform.parent.gameObject)) {
                    float totalDamage = ChargeHitDamage;
                    bool crit = (PlayerStats.instance ? PlayerStats.instance.GetCrit() : false);
                    if (PlayerStats.instance) {
                        totalDamage += PlayerStats.instance.GetStatValue(Property.PhysicalDamage) * PhysicalDamagePercentage;
                        totalDamage *= (crit ? PlayerStats.instance.GetStatValue(Property.CriticalDamage) : 1.0f);
                    }

                    other.gameObject.transform.parent.GetComponent<Enemy_Stats>().DealDamage(totalDamage, crit);
                    enemiesHit.Add(other.gameObject.transform.parent.gameObject);
                    if (PlayerAnimationEventHandler.Instance)
                        PlayerAnimationEventHandler.Instance.OnHit(0.5f);
                }
            }
        }
    }
}