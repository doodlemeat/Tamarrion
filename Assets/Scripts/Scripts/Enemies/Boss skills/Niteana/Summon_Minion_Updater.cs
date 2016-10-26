using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class Summon_Minion_Updater : Base_EnemySkill_Update {

        public int[] Minions_spawning;
        private bool interrupted = false;
        public int phase_active;

        protected override void OnHitEffect() {
            int[] spawn = { Minions_spawning[(int)DifficultyManager.current] };
            if (phase_active == Nihteana.instance.Phase)
                Minion_Spawner.niteana.Spawn_minions(spawn);
            //m_boss.GetComponent<Enemy_Stats>().HealPercentage(Damage[(int)Difficulty.Current_difficulty]);
            //Debug.Log("Boos healed 10%");
            Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Summon", false);
            Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Spawn", false);
        }
        protected override void OnExit() {
            m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
            m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
            Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Interrupted", false);
        }
        protected override void OnInterrupt() {
            if (!interrupted) {
                //Debug.Log("Heal interrupted!");
                m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
                m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
                //m_particleinstance.enableEmission = false;
                Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Interrupted", true);
                Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Summon", false);
                Nihteana.instance.GetComponentInChildren<Animator>().SetBool("Spawn", false);

                interrupted = true;
            }
        }
    }
}