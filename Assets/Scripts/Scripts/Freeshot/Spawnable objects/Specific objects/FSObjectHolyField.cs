using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class FSObjectHolyField : FSObjectArea {
		public float HealAmount = 10;
		public float DamageAmount = 10;
		public float TickTime = 1;
		public GameObject healParticleEffect;
		public GameObject damageParticleEffect;
		public GameObject healEffectChild;
		public GameObject damageEffectChild;
		GameObject playerHealingInstance;
		TopgunTimer tickTimer = new TopgunTimer ();
		bool m_friendlyParticles = false;

		public override void Start () {
			base.Start ();
			tickTimer.StartTimerBySeconds (TickTime);
			ActivateDamageEffect ();
		}

		public override void Update () {
			tickTimer.Update ();
			if ( tickTimer.IsComplete ) {
				tickTimer.StartTimerBySeconds (TickTime);
				ApplyEffect ();
			}
			base.Update ();

			UpdateParticlesColor ();
		}

		void UpdateParticlesColor () {
			if ( m_PlayerIsWithinBounds && !m_friendlyParticles ) {
				m_friendlyParticles = true;
				ActivateHealEffect ();
			}
			else if ( !m_PlayerIsWithinBounds && m_friendlyParticles ) {
				m_friendlyParticles = false;
				ActivateDamageEffect ();
			}
		}

		void ActivateHealEffect () {
			if ( healEffectChild )
				healEffectChild.SetActive (true);

			if ( damageEffectChild )
				damageEffectChild.SetActive (false);

			SetPlayerHealEffectActive ();
		}

		void ActivateDamageEffect () {
			if ( healEffectChild )
				healEffectChild.SetActive (false);

			if ( damageEffectChild )
				damageEffectChild.SetActive (true);

			SetPlayerHealEffectActive (false);
		}

		void SetPlayerHealEffectActive (bool p_state = true) {
			if ( p_state == true ) {
				if ( playerHealingInstance )
					return;

				if ( healParticleEffect ) {
					playerHealingInstance = (GameObject)Instantiate (healParticleEffect, Player.player.transform.position, healParticleEffect.transform.rotation);
					playerHealingInstance.transform.SetParent (Player.player.transform);
					playerHealingInstance.gameObject.transform.localPosition = healParticleEffect.transform.position;
				}
			}
			else if ( playerHealingInstance ) {
				playerHealingInstance.transform.SetParent (null);
				playerHealingInstance = null;
			}
		}

		void OnDisable () {
			SetPlayerHealEffectActive (false);
		}

		void ApplyEffect () {
			if ( m_PlayerIsWithinBounds )
				HealPlayer ();
			else if ( m_enemiesWithinBounds.Count > 0 )
				DamageEnemiesWithinBounds ();
		}

		void HealPlayer () {
			Player.player.playerStats.HealFlat (HealAmount);
			//if (healParticleEffect)
			//{
			//    /*GameObject particleObj = (GameObject)*/
			//    Instantiate(healParticleEffect, Player.player.transform.position, healParticleEffect.transform.rotation);
			//}
		}

		void DamageEnemiesWithinBounds () {
			foreach ( GameObject go in m_enemiesWithinBounds ) {
				float totalDamage = DamageAmount;
				bool crit = (PlayerStats.instance ? PlayerStats.instance.GetCrit () : false);
				if ( PlayerStats.instance ) {
					totalDamage += PlayerStats.instance.GetStatValue ("magical") * MagicDamagePercentage;
					totalDamage *= (crit ? PlayerStats.instance.GetStatValue ("crit_damage") : 1.0f);
				}
				if ( !go )
					return;
				go.GetComponent<Enemy_Stats> ().DealDamage (totalDamage, crit);
				if ( damageParticleEffect ) {
					/*GameObject particleObj = (GameObject)*/
					Instantiate (damageParticleEffect, go.transform.position + new Vector3 (0, 1, 0), damageParticleEffect.transform.rotation);
				}
			}
		}
	}
}