using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Entomb_Updater : Base_EnemySkill_Update {
		public Entomb_Effect Entomb_effect;

		protected override void Start () {
			base.Start ();
		}

		protected override void OnHitEffect () {
			Entomb_effect.transform.position = Player.player.transform.position;
			//Entomb_effect.transform.position -= new Vector3(0, 4, 0);
			Entomb_effect.transform.rotation = Player.player.transform.rotation;
			Entomb_effect.transform.Rotate (new Vector3 (0, 135, 0));
			//Entomb_effect.Life_time = Active_time[(int)Difficulty.Current_difficulty];
			Instantiate (Entomb_effect);
		}
	}
}