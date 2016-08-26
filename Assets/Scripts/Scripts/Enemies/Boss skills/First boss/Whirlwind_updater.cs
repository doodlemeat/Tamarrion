using UnityEngine;
using System.Collections;

public class Whirlwind_updater : Base_EnemySkill_Telegraph
{
    public float ForceTimer;
    private float ForceTimerCurrent;
    private float Angle = 0;

    public float stun_duration = 0.0f;
    public Texture stunned_texture;

    protected override void Update_telegrapher_movement()
    {
        base.Update_telegrapher_movement();
        ForceTimerCurrent -= Time.deltaTime;
        if (ForceTimerCurrent <= 0)
        {
            ForceTimerCurrent = ForceTimer;

            float ForceStrength = 20;
            float xForce = (Angle == 0) ? 1 : ((Angle == 180) ? -1 : 0);
            float zForce = (Angle == 90) ? 1 : ((Angle == 270) ? -1 : 0);

            xForce *= ForceStrength;
            zForce *= ForceStrength;

            if (ForcePusher.instance)
                ForcePusher.instance.SendForceFromObject(Valac.instance.gameObject, new Vector3(xForce, 0, zForce), 0.15f, ForcePusher.Shape.Box, new Vector3(3.5f, 2, 3.5f), new Vector3(0, 1.25f, 0), false);
            
            Angle = (Angle + 90) % 360;
        }
    }

    protected override void ActivatedSkill()
    {
        Valac.instance.Whirling = true;
    }
    protected override void OnExit()
    {
        Valac.instance.gameObject.GetComponentInChildren<Animator>().SetBool("Whirl", false);
        m_Enemy_Stats.Add_Modifier(Buff_Debuff + "_stunned", "stun", 5.0f, 1.0f);
        BuffManager.boss_buffs.AddBuff(Buff_Debuff + "_stunned", Valac.instance.gameObject, stun_duration, stunned_texture);
    }
}