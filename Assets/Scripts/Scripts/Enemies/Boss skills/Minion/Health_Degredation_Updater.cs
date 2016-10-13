using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Health_Degredation_Updater : Base_EnemySkill_Update {

        public float Shield_Niht_Percent;

        protected override void OnHitEffect() {
            Nihteana.instance.GetComponent<Enemy_Stats>().ShieldFlat(Damage[(int)Difficulty.Current_difficulty] * Shield_Niht_Percent);
            m_boss.GetComponent<Enemy_Stats>().DealDamage(Damage[(int)Difficulty.Current_difficulty]);
        }
    }
}