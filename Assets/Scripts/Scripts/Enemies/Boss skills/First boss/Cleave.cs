using UnityEngine;
using System.Collections;

public class Cleave : Base_EnemySkill {

    public float Angle, Distance;

    public override void Start() {
        base.Start();
        m_name = "Cleave";
    }

    public override float CheckRelevance() {
        float delta_time = GetDeltaTime();
        m_bonus_relevance += delta_time;
        float relevance = 100.0f + m_bonus_relevance;
        //Debug.Log(m_name + ", " + relevance);
        return CloseEnough(Angle, Distance) ? relevance : 0.0f;
    }
    protected override void StartUsingSkill() {
        //int[] spawn = { 1 };
        //Minion_Spawner.instance.Spawn_minions(spawn);
    }
}