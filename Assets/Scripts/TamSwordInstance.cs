using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class TamSwordInstance : MonoBehaviour {
		public static GameObject instance;

		void Awake() {
			instance = gameObject;
		}
	}
}
