﻿using UnityEngine;
using System.Collections;
using System;
using Tamarrion;
namespace Tamarrion {
	public class Minion_Trash : Enemy_Base {
		private bool died = false;
		private float time_dead = 0.0f;
		public float despawnTime = 5.0f;
		public float decomposeTime = 4.0f;
		public bool Activate_by_distance = true;

		protected override void Death () {
			base.Death ();
			if ( UnityEngine.Random.Range (0, 2) == 1 )
				m_animator.SetBool ("Death2", true);
		}

		protected override void Update () {
			if ( !Active ) {
				if ( Activate_by_distance && Vector3.Distance (transform.position, Player.player.transform.position) <= Distance_activate ) {
					Active = true;
				}
				return;
			}
			base.Update ();
			if ( !Alive && !died ) {
				died = true;
				time_dead = 0;
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