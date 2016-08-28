using UnityEngine;

// Cheat system enables you to teleport to boss locations
// Only works when playing from editor
// Extend this class further when neccessary 

namespace Tamarrion {
	public class Cheat : MyMonoBehaviour {
		[SerializeField]
		string valacTeleportKey = "f1";

		[SerializeField]
		string valacTeleportKeyBeforeActivate = "f2";

		[SerializeField]
		string nithTeleportKey = "f3";

		[SerializeField]
		string nithTeleportKeyBeforeActive = "f4";

		[SerializeField]
		Transform valacTeleportPosition;

		[SerializeField]
		Transform valacTeleportPositionBeforeActivate;

		[SerializeField]
		Transform nithTeleportPosition;

		[SerializeField]
		Transform nithTeleportPositionBeforeActive;

		void Update() {
			if ( Application.isEditor ) {
				if ( Input.GetKeyDown (valacTeleportKey.ToLower()) ) {
					Player.player.transform.position = valacTeleportPosition.position;
				}

				if ( Input.GetKeyDown (nithTeleportKey.ToLower()) ) {
					Player.player.transform.position = nithTeleportPosition.position;
				}

				if ( Input.GetKeyDown (valacTeleportKeyBeforeActivate.ToLower ()) ) {
					Player.player.transform.position = valacTeleportPositionBeforeActivate.position;
				}

				if ( Input.GetKeyDown (nithTeleportKeyBeforeActive.ToLower ()) ) {
					Player.player.transform.position = nithTeleportPositionBeforeActive.position;
				}
			}
		}
	}
}