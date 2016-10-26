using UnityEngine;
using System.Collections;
using System;
using Tamarrion;
namespace Tamarrion {
	public class Minion_DeathNova : Enemy_Base {
		private bool died = false;
		private float time_dead = 0;
		public float despawnTime, decomposeTime;
		public float[] Degredation;
		public float Niht_Shield_Percent;
		public bool Activate_by_distance = false;

		protected override void Death () {
			base.Death ();
			if ( UnityEngine.Random.Range (0, 2) == 1 )
				m_animator.SetBool ("Death2", true);
		}

		protected override void Update () {
			if ( !Active ) {
				//Debug.Log(Vector3.Distance(transform.position, Player.player.transform.position));
				if ( Activate_by_distance && Vector3.Distance (transform.position, Player.player.transform.position) <= Distance_activate ) {
					Active = true;
					//Debug.Log("Activate");
				}
				return;
			}
			if ( Alive ) {
				if ( Nihteana.instance ) {
					GetComponent<Enemy_Stats> ().DealDamage (Degredation[(int)DifficultyManager.current] * Time.deltaTime, false, false);
					Nihteana.instance.GetComponent<Enemy_Stats> ().ShieldFlat (Degredation[(int)DifficultyManager.current] * Niht_Shield_Percent * Time.deltaTime);
				}
			}
			base.Update ();
			if ( !Alive && !died ) {
				died = true;
				time_dead = 0;
				Nihteana.instance.minionDeaths.Add (transform.position);
			}
			if ( died ) {
				time_dead += Time.deltaTime;
				if ( time_dead > despawnTime ) {
					transform.position -= new Vector3 (0, 2.0f * Time.deltaTime * (1 / decomposeTime), 0);
				}
				if ( time_dead > despawnTime + decomposeTime ) {
					Destroy (gameObject);
				}
			}
		}

		protected override void OnBossPhaseSwitch (BossPhaseSwitchEvent e) {

		}
	}
}