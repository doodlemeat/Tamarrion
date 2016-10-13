using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Reactivate_Altar_Updater : Base_EnemySkill_Update {
        protected override void OnHitEffect() {
            Minion_Altar altar = Nihteana.instance.altars[0];
            Vector3 nit_pos = Nihteana.instance.transform.position, altar_pos = altar.transform.position;
            for (int i = 1; i < Nihteana.instance.altars.Length; i++) {
                if (Vector3.Distance(nit_pos, Nihteana.instance.altars[i].transform.position) < Vector3.Distance(nit_pos, altar_pos)) {
                    altar = Nihteana.instance.altars[i];
                    altar_pos = altar.transform.position;
                }
            }
            altar.Reactivate();
            Nihteana.instance.GetComponentInChildren<Animator>().SetBool("ReAltar", false);
        }
    }
}