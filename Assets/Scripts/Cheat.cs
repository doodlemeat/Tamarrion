using UnityEngine;

// Cheat system enables you to teleport to boss locations
// Only works when playing from editor
// Extend this class further when neccessary 

namespace Tamarrion {
	public class Cheat : MyMonoBehaviour {
		[SerializeField]
		string valacTeleportKey = "F1";

		[SerializeField]
		string nithTeleportKey = "F2";

		[SerializeField]
		Transform valacTeleportPosition;

		[SerializeField]
		Transform nithTeleportPosition;

		void Update() {
			if ( Application.isEditor ) {
				if ( Input.GetKeyDown (valacTeleportKey) ) {
					Player.player.transform.position = valacTeleportPosition.position;
				}

				if ( Input.GetKeyDown (nithTeleportKey) ) {
					Player.player.transform.position = nithTeleportPosition.position;
				}
			}
		}
	}
}