using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class Enemy_Stats : CombatStats {

        [Header("Enemy Difficulty Stats")]
        public float[] Diff_Health = new float[3], Diff_Shield = new float[3], Diff_DamageReduction = new float[3];
        public float[] Diff_MovementSpeed = new float[3], Diff_RotationSpeed = new float[3];

        public bool DamageTaken = false, Stunned = false;

        private bool Initialized = false;

        public override void InitializeSpecificStats() {
            if (!Initialized) {
                m_base.Add("rotation_speed", Diff_RotationSpeed[(int)Difficulty.Current_difficulty]);

                m_stat.Add("rotation_speed", m_base["rotation_speed"]);
            }
            m_base["max_health"] = Diff_Health[(int)Difficulty.Current_difficulty];
            m_base["health"] = Diff_Health[(int)Difficulty.Current_difficulty];
            m_base["shield"] = Diff_Shield[(int)Difficulty.Current_difficulty];
            m_base["damage_reduction"] = Diff_DamageReduction[(int)Difficulty.Current_difficulty];
            m_base["movement_speed"] = Diff_MovementSpeed[(int)Difficulty.Current_difficulty];
            m_base["rotation_speed"] = Diff_RotationSpeed[(int)Difficulty.Current_difficulty];

            m_stat["max_health"] = m_base["max_health"];
            m_stat["health"] = m_base["max_health"];
            m_stat["shield"] = m_base["shield"];
            m_stat["damage_reduction"] = m_base["damage_reduction"];
            m_stat["movement_speed"] = m_base["movement_speed"];
            m_stat["rotation_speed"] = m_base["rotation_speed"];

            UpdateStat("movement_speed");
            UpdateStat("rotation_speed");

            Initialized = true;
        }
        public override void ResetToBase() {
            m_stat["max_health"] = m_base["max_health"];
            m_stat["health"] = m_base["max_health"];
            m_stat["shield"] = m_base["shield"];
            m_stat["damage_reduction"] = m_base["damage_reduction"];
            m_stat["movement_speed"] = m_base["movement_speed"];
            m_stat["rotation_speed"] = m_base["rotation_speed"];
        }

        public override float DealDamage(float damage, bool crit = false) {
            if (m_stat["invulnerable"] > 0.0f)
                return 0.0f;

            float diff = m_stat["health"] + m_stat["shield"];
            damage = damage * (1.0f - m_stat["damage_reduction"]) < 0.0f ? 0.0f : damage * (1.0f - m_stat["damage_reduction"]);
            //Debug.Log(p_amount + ", " + m_stat["shield"]);
            if (m_stat["shield"] > 0) {
                m_stat["shield"] -= damage;
                damage = 0;
                if (m_stat["shield"] < 0) {
                    damage = -m_stat["shield"];
                    m_stat["shield"] = 0;
                }
            }
            m_stat["health"] -= damage;
            diff -= m_stat["health"] + m_stat["shield"];
            DamageTaken = damage > 0.0f;
            if (diff > 0) {
                FightStats.DamageDealt += diff;
                if (targetAnimator)
                    targetAnimator.SetBool(hurtAnimatorString, true);
            }
            m_stat["health"] = m_stat["health"] < 0.0f ? 0.0f : m_stat["health"];

            InstansiateFloatingText(diff, crit, crit ? Crit_color : Dmg_color);

            return damage;
        }

        public float DealDamage(float p_amount, bool p_crit = false, bool p_text = true) {
            if (m_stat["invulnerable"] > 0.0f)
                return 0.0f;

            if (!gameObject.GetComponent<Enemy_Base>().Active)
                gameObject.GetComponent<Enemy_Base>().Active = true;

            float diff = m_stat["health"] + m_stat["shield"];
            p_amount = p_amount * (1.0f - m_stat["damage_reduction"]) < 0.0f ? 0.0f : p_amount * (1.0f - m_stat["damage_reduction"]);
            //Debug.Log(p_amount + ", " + m_stat["shield"]);
            if (m_stat["shield"] > 0) {
                m_stat["shield"] -= p_amount;
                p_amount = 0;
                if (m_stat["shield"] < 0) {
                    p_amount = -m_stat["shield"];
                    m_stat["shield"] = 0;
                }
            }
            m_stat["health"] -= p_amount;
            diff -= m_stat["health"] + m_stat["shield"];
            DamageTaken = p_amount > 0.0f;
            if (diff > 0) {
                FightStats.DamageDealt += diff;
                if (targetAnimator)
                    targetAnimator.SetBool(hurtAnimatorString, true);
            }
            m_stat["health"] = m_stat["health"] < 0.0f ? 0.0f : m_stat["health"];

            if (p_text)
                InstansiateFloatingText(diff, p_crit, p_crit ? Crit_color : Dmg_color);

            return p_amount;
        }

        public virtual void ShieldFlat(float p_amount) {
            m_stat["shield"] += p_amount;
            m_stat["shield"] = m_stat["shield"] > m_stat["max_health"] ? m_stat["max_health"] : m_stat["shield"];
        }
        public float GetShield() {
            return m_stat["shield"];
        }

        protected override void UpdateStat(string p_stat) {
            base.UpdateStat(p_stat);
            if (p_stat == "movement_speed") {
                gameObject.GetComponent<NavMeshAgent>().speed = m_stat["movement_speed"];
            }
            else if (p_stat == "rotation_speed") {
                gameObject.GetComponent<NavMeshAgent>().angularSpeed = m_stat["rotation_speed"];
            }
            else if (p_stat == "stun") {
                Stunned = m_stat["stun"] != 0.0f;
                //Debug.Log("Finish stats, stun at " + m_stat["stun"]);
            }
            //Debug.Log("Finish stats, stun at " + m_stat["stun"]);
        }
        public void Kill() {
            m_stat["health"] = 0;
        }
    }
}