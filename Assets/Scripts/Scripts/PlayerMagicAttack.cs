using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class PlayerMagicAttack : StateMachineBehaviour {
		[Tooltip("The fraction (0-1) of the animation at which to actually perform the attack.")]
		public float attackFraction = 0.5f;

		/** Stores the PlayerCombat script */
		private PlayerCombat combatScript;

		/** The length of the animation currently playing */
		private float animationLength;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			combatScript = Player.player.GetComponent<PlayerCombat>();

			// Get the current animation length from the animator
			AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
			if (clipInfo.Length == 0) {
				Debug.LogErrorFormat("A state on layer [{0}] that implements {1} has no animation" +
									 " or a state transitions into this without an animation.",
									 animator.GetLayerName(layerIndex), GetType());
				return;
			}
			animationLength = animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.length;

			StartAttack();
		}

		private void StartAttack() {
			PlayerMovement.instance.AddMoveBlock("attack");

			// Perform an attack halfway through the animation
			combatScript.StartCoroutine(combatScript.AttackAfter(AttackType.Magical, animationLength * attackFraction));
		}

		private void EndAttack() {

		}

		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			// Release the move block after some time
			if (stateInfo.normalizedTime * animationLength > 0.3) {
				PlayerMovement.instance.RemoveMoveBlock("attack");
			}
		}

		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			EndAttack();
		}
	}
}
