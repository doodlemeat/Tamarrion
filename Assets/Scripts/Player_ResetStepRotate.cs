using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class Player_ResetStepRotate : StateMachineBehaviour {
		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			animator.SetBool("RotateStepLeft", false);
			animator.SetBool("RotateStepRight", false);
		}
	}
}
