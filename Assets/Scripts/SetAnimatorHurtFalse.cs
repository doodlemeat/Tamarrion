using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class SetAnimatorHurtFalse : StateMachineBehaviour {
		override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			animator.SetBool ("Hurt", false);
		}
	}
}