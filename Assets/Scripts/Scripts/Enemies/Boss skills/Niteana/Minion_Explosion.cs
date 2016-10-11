using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Minion_Explosion : Base_EnemySkill {

		//public Vector3[] Minions_death_positions;
		private float max_cd = 20.0f, min_cd = 10.0f;

		public override void Start () {
			base.Start ();
			m_name = "Minion Explosion";
			m_max_cooldown = max_cd--;
			max_cd = max_cd < min_cd ? min_cd : max_cd;
			m_end_with_animation = false;
		}

		public override float CheckRelevance () {
			float delta_time = GetDeltaTime ();
			if ( m_cooldown > 0.0f ) {
				m_cooldown -= delta_time;
				return 0.0f;
			}
			return 1000.0f;
		}
		//protected override void StartUsingSkill() {
		/*base.StartUsingSkill();
        GameObject.Find("HUD").gameObject.transform.Find("Hide").GetComponent<RectTransform>().gameObject.SetActive(true);

        int[] spawn = { Minions_spawning[(int)Difficulty.Current_difficulty] };
        Minion_Spawner.valac.Spawn_minions(spawn);*/
		//}
	}
}