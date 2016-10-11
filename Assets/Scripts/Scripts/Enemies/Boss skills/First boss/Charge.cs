using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Charge : Base_EnemySkill {

		public float Min_Range_to_Use;

		public override void Start () {
			base.Start ();
			m_name = "Charge";
			m_end_with_animation = false;
		}

		public override float CheckRelevance () {
			float delta_time = GetDeltaTime ();
			m_bonus_relevance += delta_time;
			if ( m_cooldown > 0.0f ) {
				m_cooldown -= delta_time;
				return 0.0f;
			}
			if ( Vector3.Distance (Player.player.transform.position, Valac.instance.transform.position) < Min_Range_to_Use ) {
				return 0.0f;
			}
			RaycastHit hit;
			if ( Physics.Raycast (m_boss.position, m_boss.forward, out hit) ) {
				//if (hit.transform.gameObject.name != "HitCapsule") {
				//    return 0.0f;
				//}
			}
			float relevance = Vector3.Distance (m_player.position, m_boss.position) + m_bonus_relevance + 200.0f;
			relevance = relevance > 240.0f ? 240.0f : relevance;
			return relevance;
		}
	}
}