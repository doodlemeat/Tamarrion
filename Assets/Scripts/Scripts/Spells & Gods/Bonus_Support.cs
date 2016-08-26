using UnityEngine;
using System.Collections;

public class Bonus_Support : Bonus_Base 
{
	protected override void Update()
	{
		base.Update();
	}
	
	public override void Activate(int Power, float TimerTime)
	{
		base.Activate(Power, TimerTime);
        playerStats.Add_Modifier("bonus_support", "movement_speed", 0.0f, 1.0f + 0.05f * (float)Power);
        BuffManager.player_buffs.AddBuff("bonus_support", Player.player.gameObject, TimerTime, Texture);
	}
	
	public override void DeActivate() {
        playerStats.Remove_Modifier("bonus_support");
		base.DeActivate();
	}
}
