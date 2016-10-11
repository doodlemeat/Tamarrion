using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Phase_Two : Base_EnemySkill {

		public override void Start () {
			base.Start ();
			m_name = "TurnPhase";
			m_end_with_animation = false;
		}

		public override float CheckRelevance () {
			float delta_time = GetDeltaTime ();
			if ( m_cooldown > 0.0f ) {
				m_cooldown -= delta_time;
				return 0.0f;
			}
			if ( Nihteana.instance.altarsAlive > 0 && Nihteana.instance.GetComponent<Enemy_Stats> ().GetShield () < Nihteana.instance.GetComponent<Enemy_Stats> ().Diff_Health[(int)Difficulty.Current_difficulty] ) {
				return 0.0f;
			}
			//Debug.Log("Start");
			return 1000.0f;
		}
	}
}