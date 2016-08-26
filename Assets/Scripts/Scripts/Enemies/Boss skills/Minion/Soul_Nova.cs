﻿using UnityEngine;
using System.Collections;

public class Soul_Nova : Base_EnemySkill {

    public override void Start() {
        base.Start();
        m_name = "SoulNova";
        m_boss = gameObject.GetComponentInParent<Enemy_SkillManager>().gameObject.transform;
    }

    public override float CheckRelevance() {
        //Debug.Log(m_boss.name + ": " + m_boss.position + " = " + CloseEnough());
        return CloseEnough() ? 100.0f : 0.0f;
    }
    private bool CloseEnough() {
        return Vector3.Distance(m_player.position, m_boss.position) <= 2.4f;
    }
}