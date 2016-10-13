using UnityEngine;
using System.Collections;
using System.Diagnostics;

namespace Tamarrion {
    public class Base_EnemySkill : MonoBehaviour {

        public Transform m_boss;
        protected Transform m_player;
        public Animator m_animator;
        private Stopwatch m_time;

        public string m_name;
        public float[] Cooldown = new float[3];
        protected float m_max_cooldown = 0.0f, m_cooldown = 0.0f;
        protected float m_bonus_relevance = 0.0f;
        protected bool m_started = false;
        protected bool m_end_with_animation = true;
        public int PhaseActivate = 0, PhaseDeactivated = 0;
        public bool _isDirectional = false;
        public float CameraEffectSize = 50;

        public virtual void Start() {
            //UnityEngine.Debug.Log("Start Base_EnemySkill: " + m_name);
            //m_boss = gameObject.GetComponentInParent<Enemy_Base>().transform;
            //m_boss = transform;
            m_player = Player.player.transform;
            //m_animator = gameObject.GetComponentInParent<Animator>();
            //m_animator = m_boss.GetComponentInChildren<Animator>();

            m_max_cooldown = Cooldown[(int)Difficulty.Current_difficulty];

            m_time = new Stopwatch();
            m_time.Start();
        }
        public virtual void Initialize() {
            //UnityEngine.Debug.Log("Initialize: " + m_name);
            m_animator.SetBool(m_name, true);
            m_animator.SetTrigger(m_name + "ing");
            m_animator.SetTrigger("que");
            m_started = false;
            InitializeSkill();
        }
        public virtual bool UpdateSkill() {
            //UnityEngine.Debug.Log(m_name + " update: " + !m_started + ", " + m_animator.GetBool(m_name) + ", " + !m_animator.GetBool("que"));
            // Check if the attack has started
            if (!m_started && m_animator.GetBool(m_name) && !m_animator.GetBool("que")) {
                //Debug.Log("End? " + m_end_with_animation);
                //UnityEngine.Debug.Log("Started: " + m_name);
                m_started = true;
                m_animator.SetBool(m_name, !m_end_with_animation);
                StartUsingSkill();
            }
            // Check if the attack has ended
            if (!m_animator.GetBool(m_name + "ing")) {
                //UnityEngine.Debug.Log("Ended: " + m_name);
                m_bonus_relevance = 0.0f;
                m_cooldown = m_max_cooldown;
                EndUsingSkill();
                return true;
            }
            return false;
        }
        public virtual float CheckRelevance() {
            float delta_time = GetDeltaTime();
            if (m_cooldown > 0.0f) {
                m_cooldown -= delta_time;
                return 0.0f;
            }
            m_bonus_relevance += delta_time;
            float relevance = 0.0f;
            return relevance;
        }

        protected float GetDeltaTime() {
            /*if (m_time != null) {
                float delta_time = m_time.ElapsedMilliseconds / 1000.0f;
                m_time.Reset();
                m_time.Start();
                return delta_time;
            }*/
            return Time.deltaTime;
        }

        protected virtual void StartUsingSkill() {
            Rumble._damageSize = CameraEffectSize;
            //UnityEngine.Debug.Log("setting damage rumble effect: " + Rumble._damageSize);
        }
        protected virtual void EndUsingSkill() {
        }
        protected virtual void InitializeSkill() {
        }
        protected bool CloseEnough(float angle, float p_distance) {
            return Vector3.Angle(m_boss.forward, m_boss.position - m_player.position) >= angle && Vector3.Distance(m_player.position, m_boss.position) <= p_distance;
        }
    }
}