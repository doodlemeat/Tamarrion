using UnityEngine;
using System.Collections;

public class Summon_Minion : Base_EnemySkill {

    public string Animator_name;

    public override void Start() {
        base.Start();
        m_name = Animator_name;
        m_end_with_animation = false;
    }

    public override float CheckRelevance() {
        float delta_time = GetDeltaTime();
        if (m_cooldown > 0.0f) {
            m_cooldown -= delta_time;
            return 0.0f;
        }
        return 150.0f;
    }
}