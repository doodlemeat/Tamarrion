using UnityEngine;
using System.Collections.Generic;
using Tamarrion;

public abstract class Enemy_Base : MyMonoBehaviour {
    // Boss things
    protected NavMeshAgent m_agent;
    protected Animator m_animator;
    protected Enemy_SkillManager m_skill_manager;

    public bool Alive = true;
    public bool Active = false;
    private bool Activated = false;
    public float Distance_activate = 0.0f;
    public int Phase = 1;
    protected float m_time_to_update = 0.1f, m_update_time = 0.0f;
    public bool is_boss = false;

    public GameObject DeathParticleObjPrefab;
	//[SerializeField]
	public Transform deathParticleObjectTransform;

	//[SerializeField]
	public Vector3 deathParticleObjectOffsetAngles = Vector3.zero;

    public GameObject DeathCameraTarget;
    public List<Renderer> bossRenderers;
    public Encounter encounterCompleteOnDeath;

    public string enemyName;
    public string deathDescription;

    // Player things
    protected GameObject m_player = null;
    protected Transform m_playerTransform;

	protected float timeInCurrentPhase = 0;

    void Awake()
    {
        GetComponent<Renderer>();

		AddListener<BossPhaseSwitchEvent> (_OnBossPhaseSwitch);
    }

	void OnDestroy () {
		Enemy_List.RemoveEnemyFromList (this);
		RemoveListener<BossPhaseSwitchEvent> (_OnBossPhaseSwitch);
	}

	protected abstract void OnBossPhaseSwitch (BossPhaseSwitchEvent e);
	void _OnBossPhaseSwitch (BossPhaseSwitchEvent e) {
		timeInCurrentPhase = 0;
		Phase = e.newPhase;

		OnBossPhaseSwitch (e);
	}

	// Use this for initialization
	protected virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponentInChildren<Animator>();
        m_skill_manager = GetComponent<Enemy_SkillManager>();

        m_player = Player.player.gameObject;
        m_playerTransform = m_player.transform;

        m_update_time = m_time_to_update;

        //Debug.Log("Added " + transform.name + " to the list");
        Enemy_List.AddEnemyToList(this);

        TurnInvisible();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
		timeInCurrentPhase += Time.deltaTime;

        if (Active && !Activated)
            Activate();
        if (Alive && m_player.GetComponent<CombatStats>().m_stat["health"] > 0.0f)
        {
            Observe();
            m_update_time += Time.deltaTime;
            if (m_update_time >= m_time_to_update && !m_animator.GetBool("Stunned"))
            {
                m_update_time = 0.0f;
                //Observe();
                if (Active)
                {
                    Plan();
                }
            }
            if (Active)
            {
                Act();
            }
        }
    }

    // Observe variables
    protected float m_skill_relevance = 0.0f;

    // AI Observe
    protected virtual void Observe()
    {
        if (!Active)
        {
            if (Vector3.Distance(m_playerTransform.position, transform.position) < Distance_activate)
            {
                ActivateBoss();
            }
        }
        //else if (Alive && gameObject.GetComponent<CombatStats>().m_stat["health"] <= 0.0f)
        /*else if (Alive && gameObject.GetComponent<CombatStats>().m_stat["health"] <= 0.0f)
        {
            PlayerStats.instance.Add_Modifier("game_over_invul", "invulnerable", 1.0f, 0.0f);
            Alive = false;
            m_animator.SetBool("Alive", false);
            HUDController.hudController.ShowStatsScreen(true);
        }*/
        else
        {
            //Debug.Log("Check " + gameObject.name + " skill relevance");
            //if (!m_skill_manager.UsingSkill())
                m_skill_relevance = m_skill_manager.GetRelevance();
            Observe_Specific();
        }

        if (Alive && gameObject.GetComponent<CombatStats>().m_stat["health"] <= 0.0f)
        {
            Death();
        }
    }

    protected virtual void Death() {
		Trigger (new EnemyDeathEvent(this));

        //Debug.Log(name + " deded");
        Alive = false;

        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().speed = 0;

        foreach (Collider col in GetComponentsInChildren<Collider>())
        {
            col.enabled = false;
        }
        //Debug.Log("Removed " + transform.name + " to the list");
        Enemy_List.RemoveEnemyFromList(this);
        if (is_boss)
        {
            HudPopupManager.PopupInfo info = new HudPopupManager.PopupInfo();
            info.Title = enemyName + " defeated";
            info.Content = deathDescription;
            info.Time = 5;
            if (HudPopupManager.instance)
                HudPopupManager.instance.AddPopupToQueue(info);
        }
        m_animator.SetBool("Alive", false);

		if (DeathParticleObjPrefab && deathParticleObjectTransform)
        {
			GameObject go = Instantiate(DeathParticleObjPrefab);
			go.transform.SetParent (transform);

			Trigger (new BossDeathEffectActivateEvent(deathParticleObjectTransform, deathParticleObjectOffsetAngles));
        }

        if (encounterCompleteOnDeath)
            encounterCompleteOnDeath.SetEncounterAsCompelte();
    }

    protected virtual void Observe_Specific()
    {
    }

    // Plan variables
    protected bool m_rotate;

    // AI Plan
    protected virtual void Plan()
    {
        if (m_skill_relevance >= 50.0f && !m_skill_manager.UsingSkill())
        {
            m_skill_manager.UseSkill();
        }
        m_rotate = Vector3.Angle(transform.forward, transform.position - m_playerTransform.position) < 150;
    }

    // AI Act
    protected virtual void Act()
    {
        if (m_skill_manager.UsingSkill())
            m_skill_manager.UpdateSkills();

        if (m_rotate && m_agent.enabled) {
            Vector3 direction = (m_playerTransform.position - transform.position).normalized;
            float speed = 3.0f * (gameObject.GetComponent<NavMeshAgent>().angularSpeed / 100.0f) * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, speed, 0.0f));
            m_animator.SetBool("Rotating", m_rotate);
        }

        if (m_agent.enabled)
            m_agent.SetDestination(m_playerTransform.position);

        m_animator.SetFloat("Speed", Vector3.Magnitude(m_agent.velocity) * m_agent.speed);
        m_animator.SetBool("Rotating", m_rotate && m_agent.angularSpeed > 0.0f);
    }

    public virtual void ActivateBoss()
    {
        Active = true;
        TurnVisible();
    }

    public bool IsActive()
    {
        return Active;
    }

    void TurnInvisible()
    {
        foreach (Renderer rend in bossRenderers)
        {
            if (rend != null)
                rend.enabled = false;
        }
    }
    void TurnVisible()
    {
        foreach (Renderer rend in bossRenderers)
        {
            if (rend != null)
                rend.enabled = true;
        }
    }

    
    protected virtual void Activate() {
        Activated = true;
        TurnVisible();

        foreach (Collider col in GetComponentsInChildren<Collider>()) {
            col.enabled = true;
        }
    }
}
