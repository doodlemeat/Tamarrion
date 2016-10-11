using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class God_of_Immunity : God_Base {
		public float Damage_reduction = 0.6f;
		public GameObject Shield;
		private GameObject cur_shield;

		protected override void Start () {
			base.Start ();
			Base_EnemySkill_Update.onHitEffect += OnHitEffect;

			cur_shield = (GameObject)Instantiate (Shield);
			cur_shield.transform.SetParent (Player.player.transform);
			cur_shield.transform.localPosition = new Vector3 (0, 1, 0.75f);
			cur_shield.transform.localRotation = Quaternion.Euler (new Vector3 (-90.0f, 0, 0));
		}

		public override void Deactivate () {
			base.Deactivate ();
			Base_EnemySkill_Update.onHitEffect -= OnHitEffect;

			Destroy (cur_shield);
		}

		void OnHitEffect (bool isDirectional, ref float damage) {
			if ( isDirectional ) {
				Vector3 player = Player.player.transform.forward;
				Vector3 boss = Valac.instance.transform.position - Player.player.transform.position;
				bool isFacingBoss = Vector3.Angle (player, boss) < 90.0f;
				if ( isFacingBoss ) {
					damage *= (1.0f - Damage_reduction);
				}
			}
		}
		public override string ThreeWordDescription () {
			return "Reduced frontal damage";
		}
		public override string GodName () {
			return "Eir";
		}
		public override string ActiveEffectName () {
			return "Shield of Eir";
		}
	}
}