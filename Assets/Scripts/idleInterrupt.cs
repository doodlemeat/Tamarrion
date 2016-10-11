using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class idleInterrupt : StateMachineBehaviour {
		override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			animator.SetBool ("IsIdle", false);
		}

		override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			animator.SetBool ("IsIdle", false);
		}
	}
}
