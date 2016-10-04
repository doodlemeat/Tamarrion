using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tamarrion;
using System;

public class Nihteana : Enemy_Base
{
    public static Nihteana instance;

    public int altarsAlive = 4;

    public Minion_Altar[] altars;

    public List<Vector3> minion_deaths = new List<Vector3>();

    void Awake()
    {
        instance = this;
        wp_prob = new float[Waypoints.Count];
        for (int i = 0; i < wp_prob.Length; i++) {
            wp_prob[i] = 500;
        }
        //Nihteana.instance.GetComponent<Enemy_Stats>().Add_Modifier("invurnuable", "damage_reduction", 1, 1);
    }

	float phase3TextureLerpTime = 1;
	

    public float[] PhasesPercent = new float[1];

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

    public List<Vector3> Waypoints = new List<Vector3>();
    private float[] wp_prob;
    public float Radius;
    private float player_distance;
    public float move_cooldown;
    private float m_move_cooldown;
    public bool moving = false;
    public Vector3 destination;

    protected override void Observe_Specific() {
        player_distance = Vector3.Distance(transform.position, m_playerTransform.position);
        /*if (Phase != PhasesPercent.Length)
        {
            if (gameObject.GetComponent<CombatStats>().GetPercentageHP() < PhasesPercent[Phase - 1])
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
        //Debug.Log((!m_skill_manager.UsingSkill()).ToString() + ", " + (!moving).ToString() + ", " + (m_move_cooldown <= 0.0f).ToString() + ", " + (player_distance <= 4.0f).ToString());
        if (Phase >= 2) {
            if (!m_skill_manager.UsingSkill() && !moving && m_move_cooldown <= 0.0f && player_distance <= 4.0f) {
                //Debug.Log("------------------------------- Move ------------------------------");
                moving = true;

                float total_prob = 0.0f;
                
                for (int i = 0; i < Waypoints.Count; i++) {
                    float distance_prob = Vector3.Distance(Waypoints[i], transform.position) - 10;
                    distance_prob *= 100;
                    wp_prob[i] += distance_prob;
                    total_prob += wp_prob[i];
                }

                float rand_wp = UnityEngine.Random.Range(0, total_prob);
                int dest_wp = 0;

                for (int i = 0; i < Waypoints.Count; i++) {
                    if (rand_wp < wp_prob[i])
                        break;
                    rand_wp -= wp_prob[i];
                    dest_wp++;
                }

                wp_prob[dest_wp] -= 500;
                destination = Waypoints[dest_wp];
                m_agent.enabled = true;
            }
            if (moving) {
                m_skill_relevance = 0;
                if (Vector3.Distance(transform.position, destination) <= 3.0f) {
                    moving = false;
                    m_move_cooldown = move_cooldown;
                }
            }
            else {
                m_move_cooldown -= (Time.deltaTime + m_time_to_update);
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
    public Encounter encounter;
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

    private bool died = false;
    private float time_dead;
    public float despawn_time = 0, decompose_time = 0;
    public SkinnedMeshRenderer[] materials;

    protected override void Update() {
        base.Update();

		if ( Phase == 3) {
			foreach ( SkinnedMeshRenderer material in materials ) {
				material.material.SetFloat ("_Phase2", timeInCurrentPhase / phase3TextureLerpTime);
				if(material.material.GetFloat("_Phase2") > 1) {
					material.material.SetFloat ("_Phase2", 1);
				}
			}
		}

		if (!Alive && !died) {
            died = true;
            time_dead = 0;
            Nihteana.instance.minion_deaths.Add(transform.position);
        }
        if (died) {
            time_dead += Time.deltaTime;
            if (time_dead > despawn_time) {
                foreach (SkinnedMeshRenderer m in materials) {
                    m.material.SetFloat("_Dissolve", time_dead / decompose_time);
                }
            }
            if (time_dead > despawn_time + decompose_time) {
                Destroy(gameObject);
            }
        }
    }

	protected override void OnBossPhaseSwitch (BossPhaseSwitchEvent e) {
		Debug.Log ("In phase 3");
		Debug.Log ("timeInCurrentPhase: " + timeInCurrentPhase);
		Debug.Log ("phase3TextureLerpTime: " + phase3TextureLerpTime);
	}
}