using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class FixedScale : MonoBehaviour {
		public Vector3 scale = new Vector3 ();

		void LateUpdate () {
			transform.localScale = scale;
		}
	}
}