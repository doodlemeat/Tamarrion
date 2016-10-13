using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class RandomAnim : StateMachineBehaviour {
		// OnStateMachineEnter is called when entering a statemachine via its Entry Node
		override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
			animator.SetInteger("idleAnimID", Random.Range(0, 50));
		}
	}
}
