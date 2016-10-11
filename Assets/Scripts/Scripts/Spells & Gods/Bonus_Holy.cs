using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Bonus_Holy : Bonus_Base {
		float HPTimer = 1.0f;

		protected override void Update () {
			base.Update ();

			HPTimer -= Time.deltaTime;

			if ( HPTimer <= 0.0f ) {
				HPTimer = 1.0f;

				if ( this.playerStats != null ) {
					this.playerStats.HealPercentage (1.0f * this.Power);
				}
			}
		}

		public override void Activate (int Power, float TimerTime) {
			base.Activate (Power, TimerTime);
		}

		public override void DeActivate () {
			base.DeActivate ();
		}
	}
}