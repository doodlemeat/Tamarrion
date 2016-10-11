using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class CollisionIgnoranceManager : MonoBehaviour {
		static public void SetCollisionBetweenPlayerAndChosenCollider (Collider p_chosenCollider, bool p_collisionActive) {
			if ( p_chosenCollider.enabled ) {
				Physics.IgnoreCollision (Player.player.GetComponent<CharacterController> (), p_chosenCollider, !p_collisionActive);
			}
		}
	}
}