using UnityEngine;
using System.Collections;

public class Bonus_Magic : Bonus_Base 
{
	protected override void Update()
	{
		base.Update();
	}
	
	public override void Activate(int Power, float TimerTime)
	{
        base.Activate(Power, TimerTime);
        playerStats.Add_Modifier("bonus_magic", "magical", (float)Power, 1.0f);
        BuffManager.player_buffs.AddBuff("bonus_magic", Player.player.gameObject, TimerTime, Texture);
	}
	
	public override void DeActivate()
	{
        playerStats.Remove_Modifier("bonus_magic");
		base.DeActivate();
	}
}
