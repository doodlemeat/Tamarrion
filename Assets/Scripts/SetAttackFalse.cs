using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class SetAttackFalse : StateMachineBehaviour {
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			PlayerMovement.instance.RemoveMoveBlock("attack");
			animator.SetBool("Attack", false);
			animator.SetBool("MagicAttack", false);
		}
	}
}
