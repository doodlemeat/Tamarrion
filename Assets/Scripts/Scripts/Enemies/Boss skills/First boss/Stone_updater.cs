using UnityEngine;
using System.Collections;

public class Stone_updater : Base_EnemySkill_Telegraph
{

    public GameObject stones;
    private GameObject m_stones;

    protected override void Update() {
        if (stones && !particle_played && particle_time >= particle_delay) {
            particle_played = true;
            m_stones = (GameObject)Instantiate(stones, transform.position, Quaternion.Euler(Vector3.zero));
            m_stones.transform.position = transform.position;
            //m_stones.transform.rotation *= Quaternion.Euler(particle_rotation);

        }
        base.Update();
    }

    protected override void CheckHit()
    {
        base.CheckHit();
        if (ForcePusher.instance)
            ForcePusher.instance.SendForceFromPosition(gameObject.transform.position + new Vector3(0, 2, 0), new Vector3(0, 30, 0), 0.15f, ForcePusher.Shape.Cylinder, new Vector3(4, 0.05f, 4));

        //int[] spawn = { 1 };
        //Minion_Spawner.instance.Spawn_minions(spawn);

    }
}