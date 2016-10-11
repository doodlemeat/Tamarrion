using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Phase_Three : Base_EnemySkill {

		public override void Start () {
			base.Start ();
			m_name = "TurnPhase";
			m_end_with_animation = false;
		}

		protected override void InitializeSkill () {
			m_animator.SetBool (m_name, false);
			Nihteana.instance.destination = new Vector3 (62.0f, -13.5f, 76.0f);
			Nihteana.instance.moving = true;
		}
		public override bool UpdateSkill () {
			if ( Vector3.Distance (Nihteana.instance.transform.position, Nihteana.instance.destination) < 1.0f ) {
				m_animator.SetBool (m_name, true);
			}
			return base.UpdateSkill ();
		}

		public override float CheckRelevance () {
			float delta_time = GetDeltaTime ();
			if ( m_cooldown > 0.0f ) {
				m_cooldown -= delta_time;
				return 0.0f;
			}
			//Debug.Log(Nihteana.instance.GetComponent<Enemy_Stats>().GetShield());
			if ( Nihteana.instance.GetComponent<Enemy_Stats> ().GetShield () > 0.05f ) {
				return 0.0f;
			}
			return 1000.0f;
		}
	}
}