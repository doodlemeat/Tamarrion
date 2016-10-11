using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Whirlwind : Base_EnemySkill {

		public float Distance;

		public override void Start () {
			base.Start ();
			m_name = "Whirl";
			m_end_with_animation = false;
		}

		public override float CheckRelevance () {
			if ( m_boss == null || m_player == null )
				return 0.0f;
			float delta_time = GetDeltaTime ();
			if ( m_cooldown > 0.0f ) {
				m_cooldown -= delta_time;
				return 0.0f;
			}
			m_bonus_relevance += delta_time;
			float relevance = (3.5f - Vector3.Distance (m_player.position, m_boss.position)) * 30.0f + m_bonus_relevance;
			relevance = relevance > 200.0f ? 200.0f : relevance;
			return Canhit () ? relevance : 0.0f;
		}
		private bool Canhit () {
			return Vector3.Distance (m_player.position, m_boss.position) <= Distance;
		}
		//protected override void StartUsingSkill() {
		//    Valac.instance.Whirling = true;
		//}
		protected override void EndUsingSkill () {
			Valac.instance.Whirling = false;
		}
	}
}