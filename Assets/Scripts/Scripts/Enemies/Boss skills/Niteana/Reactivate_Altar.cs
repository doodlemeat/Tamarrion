using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Reactivate_Altar : Base_EnemySkill {

    public override void Start() {
        base.Start();
        m_name = "ReAltar";
        m_end_with_animation = true;
    }

    public override float CheckRelevance() {
        float delta_time = GetDeltaTime();
        if (m_cooldown > 0.0f) {
            m_cooldown -= delta_time;
            return 0.0f;
        }
        //Debug.Log(Nihteana.instance.altars_alive + " altars alive!");
        return 150.0f * (4 - Nihteana.instance.altars_alive);
    }

    protected override void InitializeSkill() {
        activated = false;
        m_animator.SetBool(m_name, false);
        Minion_Altar altar;
        List<int> altars = new List<int>();
        altars.Add(0);
        altars.Add(1);
        altars.Add(2);
        altars.Add(3);
        do {
            int tmp = Random.Range(0, altars.Count);
            //Debug.Log(altars.Count + " altars... " + tmp + " (" + altars[tmp] + ")");
            altar = Nihteana.instance.altars[altars[tmp]];
            altars.RemoveAt(tmp);
            //Debug.Log(altar.name + " is alive? " + altar.Alive);
        } while (altar.Alive);
        //Debug.Log("Reactivate " + altar.name);
        Nihteana.instance.destination = altar.transform.position;
        Nihteana.instance.moving = true;
    }
    private bool activated = false;
    public override bool UpdateSkill() {
        //Debug.Log("Reactivating Altar! " + Vector3.Distance(Nihteana.instance.transform.position, Nihteana.instance.destination));
        if (!activated && Vector3.Distance(Nihteana.instance.transform.position, Nihteana.instance.destination) < 2.5f) {
            m_animator.SetBool(m_name, true);
            activated = true;
        }
        return base.UpdateSkill();
    }
}