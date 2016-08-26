using UnityEngine;
using System.Collections;

public class Raven_Shot_Updater : Base_EnemySkill_Telegraph {
    public float min_raven_distance = 10.0f;
    public float[] Special_Cast_Time;

    protected override void Start() {
        base.Start();
        Casting_time = Special_Cast_Time[(int)Difficulty.Current_difficulty];
    }

    protected override float GetSpecificSize(float p_size) {
        return p_size < min_raven_distance ? min_raven_distance : p_size;
    }

    public Base_Enemy_Projectile projectile;

    protected override void OnHitEffect() {
        projectile.Origin = Nihteana.instance.gameObject.GetComponentInChildren<SpellOrigin>().transform.position;
        projectile.Target = Player.player.gameObject.GetComponentInChildren<SpellTarget>().transform.position;
        projectile.Origin.y = projectile.Target.y;
        projectile.Damage = Damage[(int)Difficulty.Current_difficulty];
        Instantiate(projectile, Vector3.zero, Quaternion.identity);
    }
}