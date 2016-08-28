using UnityEngine;

// Cheat system enables you to teleport to boss locations
// Only works when playing from editor
// Extend this class further when neccessary 

namespace Tamarrion {
	public class Cheat : MyMonoBehaviour {
		[SerializeField]
		string valacTeleportKey = "F1";

		[SerializeField]
		Transform valacTeleportPosition;

		void Update() {
			if(Input.GetKeyDown(KeyCode.F1)) {
				Player.player.transform.position = valacTeleportPosition.position;
			}
		}
	}
}