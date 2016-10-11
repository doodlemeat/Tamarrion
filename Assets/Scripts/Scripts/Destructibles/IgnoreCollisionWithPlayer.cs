using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class IgnoreCollisionWithPlayer : MonoBehaviour {
		void Start () {
			CollisionIgnoranceManager.SetCollisionBetweenPlayerAndChosenCollider (gameObject.GetComponent<Collider> (), false);
		}
	}
}