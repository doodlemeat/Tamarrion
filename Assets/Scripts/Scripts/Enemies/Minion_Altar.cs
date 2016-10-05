using UnityEngine;
using System.Collections;
using System;
using Tamarrion;

public class Minion_Altar : Enemy_Base {
    
    public GameObject[] active_enables, death_disables;
    public ParticleSystem death_part;
    public ParticleSystem active_part;

    public float Activate_time, Death_time;
    private float m_time_updated = 0.0f;

    public float[] Reactivated_Health;
    public GameObject LineFollow = null;

    protected override void Start() {
        transform.position -= new Vector3(0, 2, 0);
        active_part.Stop();
        base.Start();
    }

    protected override void Update() {
        base.Update();
        if (Active && Alive && m_time_updated < Activate_time) {
            transform.position += new Vector3(0, 2.0f * (Time.deltaTime * Activate_time), 0);
            m_time_updated += Time.deltaTime;
        }
        else if (!Alive && m_time_updated < Death_time) {
            transform.position -= new Vector3(0, 2.0f * (Time.deltaTime * Death_time), 0);
            m_time_updated += Time.deltaTime;
        }
    }

    protected override void Activate() {
        m_time_updated = 0.0f;
        foreach (GameObject g in active_enables) {
            g.SetActive(true);
        }
        active_part.Play();
        base.Activate();
    }

    protected override void Death() {
        LineFollow.SetActive(false);
        //GetComponentInChildren<LineFollow>().gameObject.SetActive(false);
        m_time_updated = 0.0f;
        Nihteana.instance.altarsAlive -= 1;

        foreach (GameObject g in death_disables) {
            g.SetActive(false);
        }

        if (death_part) {
            Instantiate(death_part, transform.position + new Vector3(0, 0.6f, 0), transform.rotation);
        }

        base.Death();
    }

    public void Reactivate() {
        LineFollow.SetActive(true);
        //Debug.Log(GetComponentInChildren<LineFollow>());
        //GetComponentInChildren<LineFollow>().gameObject.SetActive(true);
        //Debug.Log("Reactivate: Set alive");
        Alive = true;
        //Debug.Log("Reactivate: Heal 200%");
        gameObject.GetComponent<CombatStats>().Ressurect(Reactivated_Health[(int)Difficulty.Current_difficulty]);
        //Debug.Log("Reactivate: Restart");
        Start();
        //Debug.Log("Reactivate: Move up");
        transform.position += new Vector3(0, 2, 0);
        //Debug.Log("Reactivate");
        Activate();
        gameObject.GetComponent<Animator>().SetBool("Alive", true);
        Nihteana.instance.altarsAlive++;
    }

	protected override void OnBossPhaseSwitch (BossPhaseSwitchEvent e) {
		
	}
}