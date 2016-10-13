using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Charge_updater : Base_EnemySkill_Telegraph {

        private bool m_hit = false, m_player_hit = false;
        public float min_charge_distance = 10.0f;

        public float stun_self_duration = 0.0f, stun_tam_duration = 0.0f;
        public Texture stunned_texture;

        protected override void Update_telegrapher_charger() {
            //Debug.Log("Update charge (" + m_boss.transform.rotation + ") / (" + transform.rotation + ")");
            if (m_time_casted / Casting_time <= 1.0f) {
                m_boss.transform.position = transform.position;
                m_boss.transform.position -= transform.up * (m_current_size / 2.0f);
                m_boss.transform.position += transform.up * (m_time_casted / Casting_time) * (m_current_size - 0.9f);
                //m_boss.transform.rotation = transform.rotation;
            }
            if (!m_hit && Vector3.Distance(m_player.transform.position, m_boss.transform.position) < 2.5f) {
                m_hit = true;
                m_player.GetComponent<CombatStats>().DealDamage(Damage[(int)Difficulty.Current_difficulty]);
                m_time_casted = Casting_time;
            }
        }
        protected override void ActivatedSkill() {
            //Debug.Log("Activate (" + m_boss.transform.rotation + ") / (" + transform.rotation + ")");
            //m_boss.transform.rotation = transform.rotation;
            //m_boss.GetComponent<NavMeshAgent>().enabled = false;
        }

        protected override void OnHitEffect() {
            Debug.Log("Player stunned");
            m_player.GetComponent<CombatStats>().Add_Modifier(Buff_Debuff + "_stunned", "stun", 5.0f, 1.0f);
            //BuffManager.player_buffs.AddBuff(Buff_Debuff + "_stunned", Valac.instance.gameObject, stun_tam_duration, stunned_texture);
            m_player_hit = true;
        }

        protected override void OnExit() {
            Debug.Log("Valac stunned");
            //Debug.Log("Before (" + m_boss.transform.rotation + ") / (" + transform.rotation + ")");
            //m_boss.GetComponent<NavMeshAgent>().enabled = true;
            Valac.instance.GetComponentInChildren<Animator>().SetBool("Charge", false);
            m_hit = false;
            if (!m_player_hit) {
                m_Enemy_Stats.Add_Modifier(Buff_Debuff + "_stunned", "stun", 5.0f, 1.0f);
                BuffManager.boss_buffs.AddBuff(Buff_Debuff + "_stunned", Valac.instance.gameObject, stun_self_duration, stunned_texture);
            }
            //m_boss.transform.rotation *= new Vector4(0, 0, 0, -1);
            //Debug.Log("Exit charge (" + m_boss.transform.rotation + ") / (" + transform.rotation + ")");
        }
        protected override float GetSpecificSize(float p_size) {
            return p_size < min_charge_distance ? min_charge_distance : p_size;
        }
    }
}