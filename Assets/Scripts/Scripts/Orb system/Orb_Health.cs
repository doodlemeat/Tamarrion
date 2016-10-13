using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Orb_Health : Orb {
        public GameObject particleSys;
        public float health = 45.0f;
        protected override void OnTriggerEnter(Collider other) {
            base.OnTriggerEnter(other);
            if (other.gameObject != Player.player.gameObject)
                return;
            if (PlayerStats.instance.GetPercentageHP() < 1.0f) {
                base.OnTriggerEnter(other);

                if (_triggered && _playerStats.GetPercentageHP() < 1.0f) {

                    _playerStats.HealPercentage(health);
                    if (particleSys)
                        Instantiate(particleSys, other.gameObject.transform.position, particleSys.gameObject.transform.rotation);
                    //Debug.Log("Player healed by orb");
                }

                Destroy(gameObject);
                OrbSystem.Instance.OrbDestroyed();
            }
        }
    }
}