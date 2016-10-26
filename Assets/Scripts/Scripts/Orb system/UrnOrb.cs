using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class UrnOrb : MonoBehaviour {
        public GameObject particleSys;
        protected PlayerStats _playerStats;
        protected bool _triggered = false;

        public float[] health = new float[3];

        float _baseHeight;

        protected void OnTriggerEnter(Collider other) {
            if (other.gameObject != Player.player.gameObject)
                return;

            _playerStats = other.GetComponent<PlayerStats>();
            if (_playerStats)
                _triggered = true;
            else
                _triggered = false;

            if (_triggered && _playerStats.GetPercentageHP() < 1.0f) {
                _playerStats.HealPercentage(health[(int)DifficultyManager.current]);
                //Debug.Log("Player healed by orb");
                Destroy(gameObject);
                if (particleSys)
                    Instantiate(particleSys, other.gameObject.transform.position, particleSys.gameObject.transform.rotation);
            }

        }
    }
}