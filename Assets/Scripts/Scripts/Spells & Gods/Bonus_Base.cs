using UnityEngine;
using System.Collections;

public class Bonus_Base : MonoBehaviour 
{
    public Texture Texture;
	public FSSkillElement element;
	public bool active = false;
	public int Power = 0;
	public float Timer = 0.0f;

	protected PlayerStats playerStats;

	protected virtual void Update()
	{
		if (active)
		{
			if(Timer <= 0.0f)
			{
				DeActivate();
			}
			else
			{
				Timer -= Time.deltaTime;
			}
		}
	}

	public virtual void Activate(int Power, float TimerTime)
	{
		this.playerStats = Player.player.GetComponent<PlayerStats>();
		this.Power = Power;
		this.active = true;
		this.Timer = TimerTime;
	}

	public virtual void DeActivate()
	{
		this.Power = 0;
		this.Timer = 0.0f;
		this.active = false;
	}
}
