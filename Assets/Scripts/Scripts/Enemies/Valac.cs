using UnityEngine;
using System.Collections;
using System;
using Tamarrion;

public class Valac : Enemy_Base
{
    public static Valac instance;

    public Encounter encounter;

    public bool Whirling = false, Swiping = false;
    
    void Awake()
    {
        instance = this;
    }

    public float[] PhasesPercent = new float[1];

    protected override void Death()
    {
        base.Death();

        //PlayerStats.instance.Add_Modifier("game_over_invul", "invulnerable", 1.0f, 0.0f);
        if (HUDController.hudController)
            HUDController.hudController.ShowStatsScreen(true);

        encounter.SetEncounterAsCompelte();
    }

    protected override void Act()
    {
        base.Act();

        if (Whirling)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0.0f, -1300.0f * Time.deltaTime, 0.0f));
        }
    }

    protected override void Observe_Specific()
    {
        if (Phase != PhasesPercent.Length)
        {
            if (gameObject.GetComponent<CombatStats>().GetPercentageHP() < PhasesPercent[Phase - 1])
            {
                Phase++;
                gameObject.GetComponent<Enemy_SkillManager>().NewPhase(Phase);
            }
        }
    }

	protected override void OnBossPhaseSwitch (BossPhaseSwitchEvent e) {
		
	}
}