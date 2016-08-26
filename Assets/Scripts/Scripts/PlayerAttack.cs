using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tamarrion;

public class PlayerAttack : MyMonoBehaviour
{
    public static PlayerAttack instance;

    //public GameObject magicAttackProjectile;
    public ParticleSystem particleSys;
    public CombatText FloatingText;
    public float SpeedModifier = 1, AttackTime, RotateTime, DefaultForceDelay = 0.8f, AttackAngleDegrees = 67.5f;

    private Animator animator;
    private PlayerStats combatStats;
    private Xft.XWeaponTrail m_trail;
    private float ForceDelayCurrent;
    private bool m_attacking = false;
    //public string CurrentAttack = "", QuedAttack = "";
    public int combo = 0;

    public delegate void AttackAction(AttackInfo attackInfo);
    public delegate void HitAction(AttackInfo attackInfo);
    public static event HitAction onHit;
    public static event AttackAction onAttack;

    public List<GameObject> _hitSounds = new List<GameObject>();

    List<string> attackBlockers = new List<string>();
    bool m_disableAttackNextFrame = false;

	void Awake() {
		instance = this;
	}

    void Start()
    {
        AttackTime *= SpeedModifier;
        RotateTime *= SpeedModifier;
        DefaultForceDelay *= SpeedModifier;
        animator = GetComponentInChildren<Animator>();
        combatStats = GetComponent<PlayerStats>();
        m_trail = Player.player.GetComponentInChildren<Xft.XWeaponTrail>();
        m_trail.Deactivate();
    }

    void Update()
    {
        if (combatStats.m_stat["health"] <= 0.0f)
        {
            animator.SetBool("Dead", true);
            return;
        }
        else if (m_disableAttackNextFrame && Input.GetButtonUp("Attack"))
        {
            m_disableAttackNextFrame = false;
        }
        else if (m_disableAttackNextFrame)
        {
            return;
        }

        if (m_attacking)
        {
            //m_time_attacked += Time.deltaTime;
            if (ForceDelayCurrent > 0)
            {
                ForceDelayCurrent -= Time.deltaTime;
                if (ForceDelayCurrent <= 0)
                {
                    if (ForcePusher.instance)
                        ForcePusher.instance.SendForceFromObject(Player.player.gameObject, new Vector3(10, 0, 0), 0.12f, ForcePusher.Shape.Box, new Vector3(1, 1.6f, 1), new Vector3(0, 1, 0), true);
                }
            }
            if (m_attacking && !animator.GetBool("Attacking") && !animator.GetBool("Attack") && !animator.GetBool("QuedAttack1") && !animator.GetBool("QuedAttack2"))
            {
                m_attacking = false;
            }
        }
        else if (AttackEnabled() && Input.GetAxis("Attack") > 0 && SceneManager.Instance.IsNotPaused())
        {
            if (GodManager.Instance)
            {
                if (GodManager.Instance.CurrentGod == null || GodManager.Instance.CurrentGod.element != FSSkillElement.FS_Elem_Magic)
                {
                    if (FSSkillUser.CurrentSkillIsActive() == false)
                    {
                        animator.SetBool("Attack", true);
                        combo = 0;
                    }
                }
                else
                {
                    animator.SetBool("MagicAttack", true);
                    animator.SetTrigger("Attacking");
                }
            }
        }
    }

    public void StartAttack(float p_forceDelay = 0, bool p_isMagicRanged = false)
    {
        m_attacking = true;
        if (p_forceDelay != 0)
            ForceDelayCurrent = p_forceDelay;
        else
            ForceDelayCurrent = DefaultForceDelay;

        if (!p_isMagicRanged)
            m_trail.Activate();
    }

    public void PerformAttack(string p_attack_type)
    {
        m_trail.Deactivate();

        Transform m_player = Player.player.gameObject.GetComponent<Transform>();
        CombatStats m_player_stats = m_player.GetComponent<CombatStats>();

        //bool attackHit = false;
        int attacks = m_player_stats.GetMultistrike() ? 2 : 1;
        if (p_attack_type == "magical")
        {
            bool crit = m_player_stats.GetCrit();
            float base_damage = m_player_stats.m_stat["damage"] + m_player_stats.m_stat[p_attack_type];
            float damage = Random.Range(base_damage, base_damage * 1.5f) * (crit ? m_player_stats.m_stat["crit_damage"] : 1.0f);
            AttackInfo attackInfo = new AttackInfo(damage, crit);

            if (onAttack != null)
                onAttack(attackInfo);
        }
        else
        {
            foreach (Enemy_Base en in Enemy_List.Enemies)
            {
                bool distance = Vector3.Distance(m_player.position, en.gameObject.transform.position) < m_player_stats.m_stat["attack_range"];
                bool angle = Vector3.Angle(m_player.forward, en.gameObject.transform.position - m_player.position) < AttackAngleDegrees;

                List<AttackInfo> attackInfo = new List<AttackInfo>();
                for (int i = 0; i < attacks; i++)
                {
                    bool crit = m_player_stats.GetCrit();
                    float base_damage = m_player_stats.m_stat["damage"] + m_player_stats.m_stat[p_attack_type];
                    float damage = Random.Range(base_damage, base_damage * 1.5f) * (crit ? m_player_stats.m_stat["crit_damage"] : 1.0f);
                    attackInfo.Add(new AttackInfo(damage, crit));

                    if (onAttack != null)
                    {
                        onAttack(attackInfo[attackInfo.Count - 1]);
                    }

                    if (distance && angle)
                    {
                        foreach (AttackInfo ai in attackInfo)
                        {
                            en.GetComponent<Enemy_Stats>().DealDamage(ai._damage, ai._crit);
                            if (onHit != null)
                                onHit(ai);
                        }

                        if (PlayerAnimationEventHandler.Instance)
                            PlayerAnimationEventHandler.Instance.OnHit();

                        if (_hitSounds.Count > 0)
                            Instantiate(_hitSounds[Random.Range(0, _hitSounds.Count - 1)], en.gameObject.transform.position, Quaternion.identity);

                        if (particleSys)
                            Instantiate(particleSys, en.gameObject.transform.position + new Vector3(0, 1, 0), particleSys.transform.rotation);
                    }
                }
            }
        }
    }

    public class AttackInfo
    {
        public float _damage;
        public bool _crit;

        public AttackInfo(float damage, bool crit)
        {
            _damage = damage;
            _crit = crit;
        }
    }

    public void AddAttackBlock(string p_sourceName)
    {
        if (!attackBlockers.Contains(p_sourceName))
            attackBlockers.Add(p_sourceName);
    }

    public void RemoveAttackBlock(string p_sourceName)
    {
        attackBlockers.Remove(p_sourceName);
    }

    public bool AttackEnabled()
    {
        return attackBlockers.Count == 0;
    }

    public void DisableAttackNextFrame()
    {
        m_disableAttackNextFrame = true;
    }
}