using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Base_EnemySkill_Update : MonoBehaviour {
        public GameObject m_boss;
        protected GameObject m_player;
        protected Enemy_Stats m_Enemy_Stats;

        public ParticleSystem Particle;
        protected ParticleSystem m_particleinstance;
        public string particle_parent = "none/telegrapher/enemy";
        public Vector3 particle_position = Vector3.zero, particle_rotation = Vector3.zero;
        public float particle_delay;
        protected float particle_time = 0;
        protected bool particle_played = false;
        public bool particle_end_on_hit = false;
        public Transform particle_parent_transform;

        public bool _useCastbar = true;
        public bool _isDirectional = false;
        public float[] Damage = new float[3];
        public string Target = "boss/player/position", Buff_Debuff = "name";
        public Vector3 Target_position = Vector3.zero;
        public float[] Movement_modifier = new float[3], Rotation_modifier = new float[3];
        public bool Modifiers_persist_after_activate = false;
        public bool HitInterruptable = false, StunInterruptable = false, ActiveInterruptable = false;
        public float Casting_time = 0.0f;
        public float[] Active_time = new float[3], Dot_time = new float[3];
        protected float m_time_casted = 0.0f, m_time_active = 0.0f, m_time_since_dot = 0.0f;

        private bool m_skill_activated = false;

        public delegate void HitEffect(bool isDirectional, ref float damage);
        public static event HitEffect onHitEffect;

        protected virtual void Start() {
            //Debug.Log(Buff_Debuff);
            //m_boss = gameObject;

            //Simoncode: Will only update with skills that use the castbar
            if (_useCastbar)
                m_boss.GetComponent<Enemy_SkillManager>().SetUpdater(this);

            //Debug.Log(BossCastbar.castbar);
            if (_useCastbar)
                BossCastbar.castbar.OnSpellcast(Buff_Debuff);

            m_player = Player.player.gameObject;
            m_Enemy_Stats = m_boss.GetComponent<Enemy_Stats>();



            m_Enemy_Stats.Add_Modifier(Buff_Debuff + "_movement", "movement_speed", 0.0f, Movement_modifier[(int)DifficultyManager.current]);
            m_Enemy_Stats.Add_Modifier(Buff_Debuff + "_rotation", "rotation_speed", 0.0f, Rotation_modifier[(int)DifficultyManager.current]);

            m_skill_activated = false;
            m_Enemy_Stats.DamageTaken = false;
        }
        protected virtual void Update() {
            if (m_Enemy_Stats.GetPercentageHP() <= 0.0f)
                EndSkill();
            if (HitInterruptable && m_Enemy_Stats.DamageTaken)
                EndSkill();
            if (StunInterruptable && m_Enemy_Stats.Stunned && (m_time_casted < Casting_time || ActiveInterruptable))
                EndSkill();

            particle_time += Time.deltaTime;
            if (Particle && !particle_played && particle_time >= particle_delay) {
                particle_played = true;
                //Debug.Log("Spawn particle");
                Vector3 position = Target == "boss" ? m_boss.transform.position : Target == "player" ? m_player.transform.position : transform.position + Target_position;
                if (particle_parent_transform != null)
                    m_particleinstance.transform.parent = particle_parent_transform;
                m_particleinstance = (ParticleSystem)Instantiate(Particle, position + Particle.transform.position + particle_position, Particle.transform.rotation);
                m_particleinstance.transform.rotation *= Quaternion.Euler(particle_rotation);
                if (particle_parent.CompareTo("telegrapher") == 0) {
                    //Debug.Log("it should wotknfing");
                    m_particleinstance.transform.parent = transform;
                    /*m_particleinstance.transform.rotation = Quaternion.Euler(Vector3.zero);
                    m_particleinstance.transform.rotation = Quaternion.Euler(particle_rotation);
                    m_particleinstance.transform.position = Vector3.zero;
                    m_particleinstance.transform.position += particle_position;*/
                }
                if (particle_parent.CompareTo("enemy") == 0) {
                    m_particleinstance.transform.parent = m_boss.transform;
                    m_particleinstance.transform.localRotation = Quaternion.Euler(particle_rotation);
                    m_particleinstance.transform.localPosition = particle_position;
                }
            }

            m_time_casted += Time.deltaTime;
            if (m_time_casted >= Casting_time) {
                if (!m_skill_activated) {
                    ActivatedSkill();
                    if (!Modifiers_persist_after_activate) {
                        m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
                        m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
                    }
                    m_skill_activated = true;
                }

                m_time_active += Time.deltaTime;
                m_time_since_dot += Time.deltaTime;
                if (m_time_since_dot >= Dot_time[(int)DifficultyManager.current]) {
                    m_time_since_dot -= Dot_time[(int)DifficultyManager.current];
                    CheckHit();
                    if (m_time_active >= Active_time[(int)DifficultyManager.current]) {
                        OnExit();
                        //m_trail.Deactivate();
                        m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
                        m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
                        Destroy(gameObject);
                    }
                }
            }
            else {
                Update_telegrapher_charger();
            }
            Update_telegrapher_movement();
        }
        protected virtual void ActivatedSkill() { }

        protected virtual void CheckHit() {
            OnHitEffect();
        }
        protected virtual void OnHitEffect() {
            float damage = Damage[(int)DifficultyManager.current];

            if (onHitEffect != null) {
                onHitEffect(_isDirectional, ref damage);
            }

            m_player.GetComponent<CombatStats>().DealDamage(damage);

            if (particle_end_on_hit) {
                Destroy(m_particleinstance);
            }
        }

        protected virtual void Update_telegrapher_movement() { }
        protected virtual void Update_telegrapher_charger() { }

        protected virtual void OnExit() { }
        protected virtual void OnInterrupt() { }

        public float GetProgress() {
            return m_time_casted / Casting_time;
        }
        private void EndSkill() {
            m_Enemy_Stats.DamageTaken = false;
            OnInterrupt();
            OnExit();
            m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_movement");
            m_Enemy_Stats.Remove_Modifier(Buff_Debuff + "_rotation");
            Destroy(gameObject);
        }
    }
}