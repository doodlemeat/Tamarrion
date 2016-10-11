using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class PlaySoundOnCollision : MonoBehaviour {
		void OnCollisionEnter (Collision collision) {
			GetComponent<AudioSource> ().Play ();
		}
	}
}