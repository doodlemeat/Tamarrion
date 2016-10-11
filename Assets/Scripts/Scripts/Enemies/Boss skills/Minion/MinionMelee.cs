using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class MinionMelee : Base_EnemySkill {

		public override void Start () {
			base.Start ();
			m_name = "MinionMelee";
		}

		protected override void InitializeSkill () {
			m_animator.SetBool (m_name + Random.Range (1, 3), true);
			m_animator.SetTrigger (m_name + "ing");
			m_animator.SetTrigger ("que");
			m_started = false;
		}

		public override bool UpdateSkill () {
			//UnityEngine.Debug.Log(m_name + " update: " + !m_started + ", " + m_animator.GetBool(m_name) + ", " + !m_animator.GetBool("que"));
			// Check if the attack has started
			if ( !m_started && (m_animator.GetBool (m_name + "1") || m_animator.GetBool (m_name + "2")) && !m_animator.GetBool ("que") ) {
				//Debug.Log("End? " + m_end_with_animation);
				//UnityEngine.Debug.Log("Started: " + m_name);
				m_started = true;
				m_animator.SetBool (m_name + "1", !m_end_with_animation);
				m_animator.SetBool (m_name + "2", !m_end_with_animation);
				StartUsingSkill ();
			}
			// Check if the attack has ended
			if ( !m_animator.GetBool (m_name + "ing") ) {
				//UnityEngine.Debug.Log("Ended: " + m_name);
				m_bonus_relevance = 0.0f;
				m_cooldown = m_max_cooldown;
				EndUsingSkill ();
				return true;
			}
			return false;
		}

		protected override void EndUsingSkill () {
			m_animator.SetBool (m_name + "1", false);
			m_animator.SetBool (m_name + "2", false);
		}

		public override float CheckRelevance () {
			return CloseEnough () ? 100.0f : 0.0f;
		}
		private bool CloseEnough () {
			//Debug.Log(m_boss.position);
			return Vector3.Angle (m_boss.forward, m_boss.position - m_player.position) >= 150.0f && Vector3.Distance (m_player.position, m_boss.position) <= 2.4f;
		}
	}
}