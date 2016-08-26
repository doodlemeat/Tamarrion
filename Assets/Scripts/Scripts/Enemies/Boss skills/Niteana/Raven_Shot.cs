using UnityEngine;
using System.Collections;

public class Raven_Shot : Base_EnemySkill {

    public override void Start() {
        base.Start();
        m_name = "Raven shot";
        m_end_with_animation = true;
    }

    public override float CheckRelevance() {
        float delta_time = GetDeltaTime();
        if (m_cooldown > 0.0f) {
            m_cooldown -= delta_time;
            return 0.0f;
        }
        return 100.0f;
    }
}