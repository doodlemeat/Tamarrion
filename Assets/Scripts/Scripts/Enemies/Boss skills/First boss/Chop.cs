using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chop : Base_EnemySkill
{


    public float Angle, Distance;
    private int m_max_chops = 4, m_chops = 0;
    private List<Vector3> m_directions = new List<Vector3>();

    public override void Start()
    {
        base.Start();
        m_name = "Chop";
    }

    public override float CheckRelevance() {
        float delta_time = GetDeltaTime();
        m_bonus_relevance += delta_time;
        //Debug.Log("ChopChop check relevance");
        if (m_bonus_relevance >= 2000.0f)
        {
            return m_bonus_relevance;
        }
        //Debug.Log("< 2000");
        if (m_cooldown > 0.0f)
        {
            m_cooldown -= delta_time;
            return 0.0f;
        }
        //Debug.Log("close enough");
        float relevance = 95.0f + m_bonus_relevance;
        //Debug.Log(m_name + ", " + relevance);
        return CloseEnough(Angle, Distance) ? relevance : 0.0f;
    }
    protected override void StartUsingSkill()
    {
        base.StartUsingSkill();
        if (m_chops == 0)
        {
            m_directions.Add(Valac.instance.transform.forward);
            m_directions.Add(-Valac.instance.transform.forward);
            m_directions.Add(Valac.instance.transform.right);
            m_directions.Add(-Valac.instance.transform.right);
        }
        if (m_directions.Count > 0)
        {
            int dir = Random.Range(0, m_directions.Count - 1);
            if (m_chops == 0) {
                dir = 0;
            }
            Valac.instance.transform.rotation = Quaternion.LookRotation(m_directions[dir]);
            m_directions.RemoveAt(dir);
        }
    }
    protected override void EndUsingSkill()
    {
        if (++m_chops >= m_max_chops)
        {
            m_chops = 0;
        }
        else
        {
            m_cooldown = 0.0f;
            m_bonus_relevance = 2000.0f;
        }
        //Debug.Log(m_chops + " chop(s)");
    }
}