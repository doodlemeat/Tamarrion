using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class ZombieAnimationEventHandler : MonoBehaviour {
		// Attack
		AudioSource _zombieattackSource;
		public GameObject _zombieattackSourceObject;



		void Start() {
			_zombieattackSource = _zombieattackSourceObject.GetComponent<AudioSource>();

		}

		/*public void OnStep()
	{
		_footstepSource.pitch = Random.Range(0.7f, 1.3f);
		_footstepSource.Play();
		if (_footstepDustParticles)
		{
			GameObject tmp = Instantiate(_footstepDustParticles);
			tmp.transform.SetParent(gameObject.transform);
			tmp.transform.localPosition = Vector3.zero;
		}
		else
			Debug.LogError("no particle effect @ boss step");
	}
	*/
		public void OnZombieAttack() {
			_zombieattackSource.pitch = Random.Range(0.4f, 1.6f);
			_zombieattackSource.volume = 2.0f;
			_zombieattackSource.rolloffMode = AudioRolloffMode.Linear;
			_zombieattackSource.Play();
		}
	}
}
