using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class FixedRotation : MonoBehaviour {
		Quaternion rotation;

		void Awake () {
			rotation = transform.rotation;
		}

		void LateUpdate () {
			transform.rotation = rotation;
		}
	}
}