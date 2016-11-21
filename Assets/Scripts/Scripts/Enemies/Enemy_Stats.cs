using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class Enemy_Stats : CombatStats {

        [Header("Enemy Difficulty Stats")]
        public float[] Diff_Health = new float[3], Diff_Shield = new float[3], Diff_DamageReduction = new float[3];
        public float[] Diff_MovementSpeed = new float[3], Diff_RotationSpeed = new float[3];

        public bool DamageTaken = false;

        private bool Initialized = false;

        public override void InitializeSpecificStats() {
            if (!Initialized) {
                m_base.Add(Property.RotationSpeed, Diff_RotationSpeed[(int)DifficultyManager.current]);

                m_stat.Add(Property.RotationSpeed, m_base[Property.RotationSpeed]);
            }
            m_base[Property.MaxHealth] = Diff_Health[(int)DifficultyManager.current];
            m_base[Property.Health] = Diff_Health[(int)DifficultyManager.current];
            m_base[Property.Shield] = Diff_Shield[(int)DifficultyManager.current];
            m_base[Property.DamageReduction] = Diff_DamageReduction[(int)DifficultyManager.current];
            m_base[Property.MovementSpeed] = Diff_MovementSpeed[(int)DifficultyManager.current];
            m_base[Property.RotationSpeed] = Diff_RotationSpeed[(int)DifficultyManager.current];

            m_stat[Property.MaxHealth] = m_base[Property.MaxHealth];
            m_stat[Property.Health] = m_base[Property.MaxHealth];
            m_stat[Property.Shield] = m_base[Property.Shield];
            m_stat[Property.DamageReduction] = m_base[Property.DamageReduction];
            m_stat[Property.MovementSpeed] = m_base[Property.MovementSpeed];
            m_stat[Property.RotationSpeed] = m_base[Property.RotationSpeed];

            UpdateStat(Property.MovementSpeed);
            UpdateStat(Property.RotationSpeed);

            Initialized = true;
        }
        public override void ResetToBase() {
            m_stat[Property.MaxHealth] = m_base[Property.MaxHealth];
            m_stat[Property.Health] = m_base[Property.MaxHealth];
            m_stat[Property.Shield] = m_base[Property.Shield];
            m_stat[Property.DamageReduction] = m_base[Property.DamageReduction];
            m_stat[Property.MovementSpeed] = m_base[Property.MovementSpeed];
            m_stat[Property.RotationSpeed] = m_base[Property.RotationSpeed];
        }

        public override float DealDamage(float damage, bool crit = false) {
            if (inStatusEffect(StatusEffectType.Invulnerability))
                return 0.0f;
            
            float diff = m_stat[Property.Health] + m_stat[Property.Shield];
            damage = damage * (1.0f - m_stat[Property.DamageReduction]) < 0.0f ? 0.0f : damage * (1.0f - m_stat[Property.DamageReduction]);
            //Debug.Log(p_amount + ", " + m_stat["shield"]);
            if (m_stat[Property.Shield] > 0) {
                m_stat[Property.Shield] -= damage;
                damage = 0;
                if (m_stat[Property.Shield] < 0) {
                    damage = -m_stat[Property.Shield];
                    m_stat[Property.Shield] = 0;
                }
            }
            m_stat[Property.Health] -= damage;
            diff -= m_stat[Property.Health] + m_stat[Property.Shield];
            DamageTaken = damage > 0.0f;
            if (diff > 0) {
                FightStats.DamageDealt += diff;
                if (targetAnimator)
                    targetAnimator.SetBool(hurtAnimatorString, true);
            }
            m_stat[Property.Health] = m_stat[Property.Health] < 0.0f ? 0.0f : m_stat[Property.Health];
            
            InstansiateFloatingText(diff, crit, crit ? Crit_color : Dmg_color);
            
            return damage;
        }
        
        public float DealDamage(float p_amount, bool p_crit = false, bool p_text = true) {
            if (inStatusEffect(StatusEffectType.Invulnerability))
                return 0.0f;

            if (!gameObject.GetComponent<Enemy_Base>().Active)
                gameObject.GetComponent<Enemy_Base>().Active = true;

            float diff = m_stat[Property.Health] + m_stat[Property.Shield];
            p_amount = p_amount * (1.0f - m_stat[Property.DamageReduction]) < 0.0f ? 0.0f : p_amount * (1.0f - m_stat[Property.DamageReduction]);
            //Debug.Log(p_amount + ", " + m_stat["shield"]);
            if (m_stat[Property.Shield] > 0) {
                m_stat[Property.Shield] -= p_amount;
                p_amount = 0;
                if (m_stat[Property.Shield] < 0) {
                    p_amount = -m_stat[Property.Shield];
                    m_stat[Property.Shield] = 0;
                }
            }
            m_stat[Property.Health] -= p_amount;
            diff -= m_stat[Property.Health] + m_stat[Property.Shield];
            DamageTaken = p_amount > 0.0f;
            if (diff > 0) {
                FightStats.DamageDealt += diff;
                if (targetAnimator)
                    targetAnimator.SetBool(hurtAnimatorString, true);
            }
            m_stat[Property.Health] = m_stat[Property.Health] < 0.0f ? 0.0f : m_stat[Property.Health];

            if (p_text)
                InstansiateFloatingText(diff, p_crit, p_crit ? Crit_color : Dmg_color);

            return p_amount;
        }

        public virtual void ShieldFlat(float p_amount) {
            m_stat[Property.Shield] += p_amount;
            m_stat[Property.Shield] = m_stat[Property.Shield] > m_stat[Property.MaxHealth] ? m_stat[Property.MaxHealth] : m_stat[Property.Shield];
        }
        public float GetShield() {
            return m_stat[Property.Shield];
        }

        protected override void UpdateStat(Property p_stat) {
            base.UpdateStat(p_stat);
            if (p_stat == Property.MovementSpeed) {
                gameObject.GetComponent<NavMeshAgent>().speed = m_stat[Property.MovementSpeed];
            }
            else if (p_stat == Property.RotationSpeed) {
                gameObject.GetComponent<NavMeshAgent>().angularSpeed = m_stat[Property.RotationSpeed];
            }
            //Debug.Log("Finish stats, stun at " + m_stat["stun"]);
        }

        public void Kill() {
            m_stat[Property.Health] = 0;
        }
    }
}