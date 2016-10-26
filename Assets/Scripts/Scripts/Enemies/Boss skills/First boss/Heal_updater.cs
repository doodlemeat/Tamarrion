using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class Heal_updater : Base_EnemySkill_Update {

        public float stun_on_interrupt_duration = 0.0f;
        public Texture stunned_texture;
        private bool interrupted = false;

        protected override void OnHitEffect() {
            m_boss.GetComponent<Enemy_Stats>().HealPercentage(Damage[(int)DifficultyManager.current]);
            //Debug.Log("Boos healed 10%");
        }
        protected override void OnExit() {
            m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
            m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
            Valac.instance.GetComponentInChildren<Animator>().SetBool("Interrupted", false);
            Valac.instance.GetComponentInChildren<Animator>().SetBool("Heal", false);
        }
        protected override void OnInterrupt() {
            if (!interrupted) {
                //Debug.Log("Heal interrupted!");
                m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
                m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
                m_particleinstance.enableEmission = false;
                Valac.instance.GetComponentInChildren<Animator>().SetBool("Interrupted", true);
                Valac.instance.GetComponentInChildren<Animator>().SetBool("Heal", false);

                m_Enemy_Stats.Add_Modifier(Buff_Debuff + "_stunned", "stun", 5.0f, 1.0f);
                BuffManager.boss_buffs.AddBuff(Buff_Debuff + "_stunned", Valac.instance.gameObject, stun_on_interrupt_duration, stunned_texture);
                interrupted = true;
            }
        }
    }
}