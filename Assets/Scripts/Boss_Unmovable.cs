using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class Boss_Unmovable : StateMachineBehaviour {
		public bool EnableOnExit = true;

		override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			Valac.instance.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
		}

		override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if ( EnableOnExit )
				Valac.instance.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		}
	}
}
