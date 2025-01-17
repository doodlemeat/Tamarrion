﻿using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class Death_dissolve : StateMachineBehaviour {

		public SkinnedMeshRenderer[] materials;
		public float dissolve_time_sec = 0;
		private float time_dissolved = 0;

		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if ( time_dissolved < dissolve_time_sec ) {
				time_dissolved += Time.deltaTime;
				foreach ( SkinnedMeshRenderer m in materials ) {
					m.material.SetFloat ("Dissolve", time_dissolved / dissolve_time_sec);
				}
			}
		}

		// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
		//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
		//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
		//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}
	}
}
