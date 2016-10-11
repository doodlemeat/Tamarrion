using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class OrbSystem : MonoBehaviour {
		public static OrbSystem Instance;
		public bool active = false;
		public List<GameObject> _orbs = new List<GameObject> ();
		public float _spawnCooldown = 10.0f;
		public bool _spawnOrb = true;
		public int _maxOrbs = 1;

		public int _orbsAlive = 0;
		float _timer = 0.0f;
		List<OrbSpawn> _spawns = new List<OrbSpawn> ();

		void Awake () {
			Instance = this;
		}

		void Start () {
			OrbSpawn[] spawns = GetComponentsInChildren<OrbSpawn> ();
			foreach ( OrbSpawn spawn in spawns ) {
				_spawns.Add (spawn);
			}
		}

		void Update () {
			if ( active && _orbsAlive < _maxOrbs ) {
				_timer += Time.deltaTime;

				if ( _timer >= _spawnCooldown ) {
					_spawnOrb = true;
				}

				if ( _spawnOrb ) {
					SpawnOrb ();
				}
			}
		}

		void SpawnOrb () {
			int randomSpawnIndex = Random.Range (0, _spawns.Count - 1);
			OrbSpawn orbSpawn = _spawns[randomSpawnIndex];

			GameObject orbObject = (GameObject)Instantiate (_orbs[0], orbSpawn.transform.position, orbSpawn.transform.rotation);
			orbObject.transform.SetParent (orbSpawn.transform);

			orbSpawn.SetOrb (orbObject);

			++_orbsAlive;
			_spawnOrb = false;
			_timer = 0.0f;
		}

		public void OrbDestroyed () {
			--_orbsAlive;
		}

		public void SetActive (bool p_active = true) {
			active = p_active;
		}

		public void DestroyAllOrbs () {
			foreach ( Orb_Health orb in GameObject.FindObjectsOfType<Orb_Health> () ) {
				Destroy (orb.gameObject);
			}
		}
	}
}