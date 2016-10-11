using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Raven_projectile : Base_Enemy_Projectile {
		private bool hitted = false;

		public ParticleSystem OnHitParticle;

		protected override void OnHitEffect () {
			if ( !hitted ) {
				Player.player.playerStats.DealDamage (Damage);
				hitted = true;
				Instantiate (OnHitParticle, Player.player.transform.position + new Vector3 (0, 1.5f, 0), Player.player.transform.rotation);
			}
		}
	}
}