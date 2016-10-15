using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class OnKeyPortal : MonoBehaviour {
		//public GameObject Portal = null;
		public Transform teleport_location;
		public GameObject MainCamera = null;

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {
			if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
				//print ("DevPortal Activated");
				//Portal.GetComponent<portal_to_valac> ().enabled = true;
				Player.player.transform.position = teleport_location.position;
				Player.player.transform.rotation = teleport_location.rotation;
				MainCamera.transform.rotation = teleport_location.rotation;

			}
		}
	}
}
