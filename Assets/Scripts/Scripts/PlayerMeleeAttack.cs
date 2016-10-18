using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;

namespace Tamarrion {
	public class PlayerMeleeAttack : StateMachineBehaviour {
		[Tooltip("The audio clip to play when the sword swings.")]
		public AudioClip swingingSound;

		[Tooltip("The volume of the audio clip.")]
		public float volume = 0.25f;

		[Tooltip("The fraction (0-1) of the animation at which to actually perform the attack.")]
		public float attackFraction = 0.5f;

		[Tooltip("The fraction (0-1) of the animation where the character is moved forward.")]
		public float moveFraction = 0.3f;

		[Tooltip("The speed at which to move the character forward.")]
		public float moveSpeed = 2.0f;

		/** Stores the PlayerCombat script */
		private PlayerCombat combatScript;

		/** The length of the animation currently playing */
		private float animationLength;

		private bool transitioned;

		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			Debug.Log("BEGIN " + stateInfo.shortNameHash);
			combatScript = Player.player.GetComponent<PlayerCombat>();
			animator.SetBool("StopAttack", false);
			transitioned = false;

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
			combatScript.ShowWeaponTrail();

			combatScript.SendForceFromPlayer(new Vector3(10, 0, 0), 0.12f, new Vector3(1, 1.6f, 1), new Vector3(0, 1, 0));

			AudioManager.instance.Play(swingingSound, volume);

			// Perform an attack halfway through the animation
			combatScript.StartCoroutine(combatScript.AttackAfter(AttackType.Physical, animationLength * attackFraction));
		}

		private void EndAttack() {
			
		}

		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			// Move the character forward for a certain time
			if (stateInfo.normalizedTime < moveFraction && !Evade.instance.IsEvading()) {
				Player.player.Move(Player.player.transform.forward * moveSpeed);
			}

			// If we press attack again then queue it up for a combo,
			if (stateInfo.normalizedTime > 0.25 && stateInfo.normalizedTime < 0.9 && !transitioned) {
				combatScript.ShowComboIndicator();
				if (Input.GetMouseButtonDown(0)) {
					animator.SetInteger("RandomAttack", Random.Range(0, 2));
					animator.SetTrigger("Combo");
					transitioned = true;
					combatScript.HideComboIndicator();

					Debug.Log("Bingo");
				}
			}
			Debug.Log("Time: " + stateInfo.normalizedTime + " " + stateInfo.shortNameHash + " " + transitioned);
			if (stateInfo.normalizedTime > 1 && !transitioned) {
				animator.SetBool("StopAttack", true);
				transitioned = true;
				combatScript.HideComboIndicator();
				Debug.Log("STOPPING " + stateInfo.shortNameHash + " " + stateInfo.normalizedTime);
			}

			// Release the move block after some time
			if (stateInfo.normalizedTime * animationLength > 0.3) {
				PlayerMovement.instance.RemoveMoveBlock("attack");
			}
		}

		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			Debug.Log("END " + stateInfo.shortNameHash);
			EndAttack();
		}
	}
}
