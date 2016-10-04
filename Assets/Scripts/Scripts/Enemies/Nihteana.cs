using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tamarrion;
using System;

public class Nihteana : Enemy_Base
{
    private const int DEFAULT_WAYPOINT_PROBABILITY = 500;
    private const float PHASE_3_TEXTURE_LERP_TIME = 1;

    public static Nihteana instance;

    // General
    private bool died = false;
    private float timeDead;

    public List<Vector3> minionDeaths = new List<Vector3>();
    public float despawnTime = 0;
    public float decomposeTime = 0;
    public SkinnedMeshRenderer[] materials;

    // Movement
    public bool moving = false;
    public float moveCooldown;
    public List<Vector3> waypoints = new List<Vector3>();
    public Vector3 destination;

    private float[] waypointProb;
    private float distanceToPlayer;
    private float currentMoveCooldown;

    // Phases
    public float[] phasesPercent = new float[1];
    public Encounter encounter;

    // Altars
    public Minion_Altar[] altars;
    public int altarsAlive = 4;

    void Awake()
    {
        instance = this;
        waypointProb = new float[waypoints.Count];
        for (int i = 0; i < waypointProb.Length; i++) {
            waypointProb[i] = DEFAULT_WAYPOINT_PROBABILITY;
        }
        //Nihteana.instance.GetComponent<Enemy_Stats>().Add_Modifier("invurnuable", "damage_reduction", 1, 1);
    }

    /*protected override void Update() {
        if (Alive && m_player.GetComponent<CombatStats>().m_stat["health"] > 0.0f) {
            Observe();
            m_update_time += Time.deltaTime;
            if (m_update_time >= m_time_to_update && !m_animator.GetBool("Stunned")) {
                m_update_time = 0.0f;
                Observe();
                if (Active) {
                    Plan();
                }
            }
            if (Active) {
                Act();
            }
        }
    }*/

    protected override void Observe_Specific() {
        distanceToPlayer = Vector3.Distance(transform.position, m_playerTransform.position);
        /*if (Phase != phasesPercent.Length)
        {
            if (gameObject.GetComponent<CombatStats>().GetPercentageHP() < phasesPercent[Phase - 1])
            {
                Phase++;
                gameObject.GetComponent<Enemy_SkillManager>().NewPhase(Phase);
            }
        }
        if (Phase == 1 && altarsAlive <= 0) {
            Phase = 2;
        }
        if (Phase == 2 && Nihteana.instance.GetComponent<Enemy_Stats>().GetShield() <= 0) {
            Phase = 3;
        }*/
    }

    protected override void Plan() {
        //Debug.Log((!m_skill_manager.UsingSkill()).ToString() + ", " + (!moving).ToString() + ", " + (currentMoveCooldown <= 0.0f).ToString() + ", " + (distanceToPlayer <= 4.0f).ToString());
        if (Phase >= 2) {
            if (!m_skill_manager.UsingSkill() && !moving && currentMoveCooldown <= 0.0f && distanceToPlayer <= 4.0f) {
                //Debug.Log("------------------------------- Move ------------------------------");
                moving = true;

                float totalProbability = 0.0f;
                for (int i = 0; i < waypoints.Count; i++) {
                    float distProbability = Vector3.Distance(waypoints[i], transform.position) - 10;
                    distProbability *= 100;
                    waypointProb[i] += distProbability;
                    totalProbability += waypointProb[i];
                }

                float randomProbability = UnityEngine.Random.Range(0, totalProbability);
                int destinationWaypoint = 0;

                for (int i = 0; i < waypoints.Count; i++) {
                    if (randomProbability < waypointProb[i])
                        break;
                    randomProbability -= waypointProb[i];
                    destinationWaypoint++;
                }

                waypointProb[destinationWaypoint] -= DEFAULT_WAYPOINT_PROBABILITY;
                destination = waypoints[destinationWaypoint];
                m_agent.enabled = true;
            }
            if (moving) {
                m_skill_relevance = 0;
                if (Vector3.Distance(transform.position, destination) <= 3.0f) {
                    moving = false;
                    currentMoveCooldown = moveCooldown;
                }
            }
            else {
                currentMoveCooldown -= (Time.deltaTime + m_time_to_update);
            }
			Nihteana.instance.GetComponent<Enemy_Stats>().Remove_Modifier("invurnuable");
        }
        base.Plan();
        m_rotate = Vector3.Angle(transform.forward, transform.position - m_playerTransform.position) < 178;
    }

    protected override void Act() {
        //Debug.Log(m_rotate);
        if (m_skill_manager.UsingSkill())
            m_skill_manager.UpdateSkills();

        if (m_rotate && m_agent.enabled) {
            Vector3 direction = (m_playerTransform.position - transform.position).normalized;
            float speed = 3.0f * (gameObject.GetComponent<NavMeshAgent>().angularSpeed / 100.0f) * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, speed, 0.0f));
            m_animator.SetBool("Rotating", m_rotate);
        }

        if (m_agent.enabled)
            m_agent.SetDestination(destination);

        m_animator.SetFloat("Speed", Vector3.Magnitude(m_agent.velocity) * m_agent.speed);
        m_animator.SetBool("Rotating", m_rotate && m_agent.angularSpeed > 0.0f);

        //Debug.Log(Vector3.Angle(Player.player.transform.eulerAngles, transform.eulerAngles));

        m_animator.SetBool("Move Forward", false);
        m_animator.SetBool("Move Left", false);
        m_animator.SetBool("Move Right", false);
    }

    protected override void Death() {
        base.Death();
        foreach (Enemy_Base en in Enemy_List.Enemies) {
            //if (!en.is_boss)
            //Instead of killing all non-bosses, we kill the relevant bossfight minions.
            if(en is Minion_DeathNova || en is Minion_Altar)
                en.GetComponent<Enemy_Stats>().Kill();
        }
        encounter.SetEncounterAsCompelte();
    }

    protected override void Update() {
        base.Update();

		if ( Phase == 3) {
			foreach ( SkinnedMeshRenderer material in materials ) {
				material.material.SetFloat ("_Phase2", timeInCurrentPhase / PHASE_3_TEXTURE_LERP_TIME);
				if(material.material.GetFloat("_Phase2") > 1) {
					material.material.SetFloat ("_Phase2", 1);
				}
			}
		}

		if (!Alive && !died) {
            died = true;
            timeDead = 0;
            Nihteana.instance.minionDeaths.Add(transform.position);
        }
        if (died) {
            timeDead += Time.deltaTime;
            if (timeDead > despawnTime) {
                foreach (SkinnedMeshRenderer m in materials) {
                    m.material.SetFloat("_Dissolve", timeDead / decomposeTime);
                }
            }
            if (timeDead > despawnTime + decomposeTime) {
                Destroy(gameObject);
            }
        }
    }

	protected override void OnBossPhaseSwitch (BossPhaseSwitchEvent e) {
		Debug.Log ("In phase 3");
		Debug.Log ("timeInCurrentPhase: " + timeInCurrentPhase);
		Debug.Log ("Phase 3 Texture Lerp Time: " + PHASE_3_TEXTURE_LERP_TIME);
	}
}