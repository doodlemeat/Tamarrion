using UnityEngine;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Animator))]

	public class IKForceTransformPosition : MonoBehaviour {
		public bool ikActive = false;
		public Transform leftHandObj;
		public Transform forceTarget;

		Animator animator;

		void Start () {
			animator = GetComponent<Animator> ();
		}

		void OnAnimatorIK (int layerIndex) {
			Debug.Log ("running ik update");
			if ( animator ) {
				if ( ikActive ) {
					if ( leftHandObj != null ) {
						Debug.Log ("setting hand position");
						animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
						animator.SetIKPosition (AvatarIKGoal.RightHand, forceTarget.position);
					}
				}
				else {
					animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 0);
				}
			}
		}
	}
}