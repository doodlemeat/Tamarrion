using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class portal_to_valac : MonoBehaviour {

		public Transform teleport_location;
		public GameObject MainCamera = null;

		void Update() {
			if (Vector3.Distance(Player.player.transform.position, transform.position) < 2) {
				Player.player.transform.position = teleport_location.position;
				Player.player.transform.rotation = teleport_location.rotation;
				MainCamera.transform.rotation = teleport_location.rotation;
			}
		}
	}
}
