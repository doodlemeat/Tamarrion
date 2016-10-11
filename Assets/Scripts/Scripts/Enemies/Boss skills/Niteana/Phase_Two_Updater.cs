using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class Phase_Two_Updater : Base_EnemySkill_Update {

		protected override void Update () {
			base.Update ();
			Nihteana.instance.transform.position -= new Vector3 (0, 2.83854f * (Time.deltaTime * (1 / Casting_time)), 0);
		}

		protected override void OnHitEffect () {
			if ( Nihteana.instance.Phase == 1 ) {
				Nihteana.instance.Phase = 2;
				Nihteana.instance.GetComponent<Enemy_SkillManager> ().NewPhase (2);
				Nihteana.instance.GetComponent<NavMeshAgent> ().enabled = true;
				Nihteana.instance.destination = Nihteana.instance.transform.position;
				Nihteana.instance.gameObject.GetComponentInChildren<Animator> ().SetBool ("TurnPhase", false);
				Nihteana.instance.gameObject.GetComponentInChildren<Animator> ().SetBool ("Recoup", false);
				Nihteana.instance.gameObject.GetComponentInChildren<Animator> ().SetBool ("Spawn", false);
				Nihteana.instance.GetComponent<Enemy_Stats> ().Remove_Modifier ("invulnerable");
				foreach ( Minion_Altar Altar in Nihteana.instance.altars ) {
					Altar.GetComponent<Enemy_Stats> ().Kill ();
				}
			}
			else if ( Nihteana.instance.Phase == 2 ) {
				Nihteana.instance.Phase = 3;
				Nihteana.instance.GetComponent<Enemy_SkillManager> ().NewPhase (3);
				Nihteana.instance.gameObject.GetComponentInChildren<Animator> ().SetBool ("TurnPhase", false);
				foreach ( Minion_Altar Altar in Nihteana.instance.altars ) {
					Altar.Reactivate ();
				}
			}
		}
	}
}