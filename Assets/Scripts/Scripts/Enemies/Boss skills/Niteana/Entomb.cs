using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Entomb : Base_EnemySkill {

		public float Min_Range_to_Use;

		public override void Start () {
			base.Start ();
			m_name = "Entomb";
			m_end_with_animation = true;
		}

		public override float CheckRelevance () {
			float delta_time = GetDeltaTime ();
			if ( m_cooldown > 0.0f ) {
				m_cooldown -= delta_time;
				return 0.0f;
			}
			m_bonus_relevance += delta_time;
			float relevance = 250.0f + Vector3.Distance (m_player.position, m_boss.position) * 5.0f + m_bonus_relevance;
			relevance = Vector3.Distance (m_player.position, m_boss.position) < Min_Range_to_Use ? 0.0f : relevance;
			relevance = relevance > 800.0f ? 800.0f : relevance;
			return relevance;
		}
	}
}