using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class IgnoreCameraCollision : MonoBehaviour {
		static public void IgnoreCameraCollisionWithObject (GameObject p_object) {
			if ( ObjectIgnoresCameraCollision (p_object) == false )
				p_object.AddComponent<IgnoreCameraCollision> ();
		}

		static public void UnignoreCameraCollisionWithObject (GameObject p_object) {
			if ( ObjectIgnoresCameraCollision (p_object) )
				Destroy (p_object.GetComponent<IgnoreCameraCollision> ());
		}

		static public bool ObjectIgnoresCameraCollision (GameObject p_object) {
			return p_object.GetComponent<IgnoreCameraCollision> () != null;
		}
	}
}