using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class desecration_lookatthis : MonoBehaviour {
		public static Transform instance;

		void Awake () {
			instance = this.transform;
		}
	}
}
