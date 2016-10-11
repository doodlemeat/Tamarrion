using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class PlayerMagicAttack : StateMachineBehaviour {
		public float force_delay = 0.8f;
		private PlayerAttack m_player_attack;
		private float m_time_attacked;
		private bool m_attacked, m_stopped, m_qued;

		override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			m_player_attack = PlayerAttack.instance;
			m_time_attacked = 0.0f;
			m_attacked = false;
			m_stopped = true;
			m_qued = false;

			animator.SetTrigger ("Attacking");
			animator.SetBool ("MagicAttack", false);
			m_player_attack.StartAttack (force_delay, true);
		}

		override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			m_time_attacked += Time.deltaTime;
			if ( m_time_attacked > 0.25f * m_player_attack.SpeedModifier && PlayerAttack.instance.AttackEnabled () && Input.GetAxis ("Attack") > 0 && !m_qued ) {
				m_qued = true;
			}
			if ( m_stopped && m_time_attacked >= m_player_attack.AttackTime - m_player_attack.RotateTime ) {
				m_stopped = false;
				Player.player.GetComponent<PlayerMovement> ().RemoveMoveBlock ("attack");
			}
			if ( !m_attacked && m_time_attacked >= m_player_attack.AttackTime ) {
				m_attacked = true;
				m_player_attack.PerformAttack ("magical");
			}
		}
	}
}