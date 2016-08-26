using UnityEngine;
using System.Collections;

public class Spell_Smite : SpellBase
{
	public float minDamageAmount = 0;
	public float maxDamageAmount = 0;
	public float minHealAmount = 0;
	public float maxHealAmount = 0;
	public CombatText FloatingText;
    
    [Header("Boss Effect")]
    public GameObject BossParticleSys;
    public float BossParticlesHeight = 2;
    [Header("Player Effect")]
    public GameObject PlayerParticleSys;
    public float PlayerParticlesHeight = 1;

	public Transform FlyingSword;

	public override void use()
	{
		base.use();
		//GameObject boss = _playerStats.GetComponentInParent<Player>().bossTarget;
		//Enemy_Stats Enemy_Stats = boss.GetComponent<Enemy_Stats>();

  //      bool crit = _playerStats.GetCrit();
  //      float base_damage = _playerStats.m_stat["damage"] + _playerStats.m_stat["magical"];
  //      float damage = Random.Range(base_damage, base_damage * 1.5f) * (crit ? _playerStats.m_stat["crit_damage"] : 1.0f);
		
		//Enemy_Stats.DealDamage(damage + Random.Range(minDamageAmount, maxDamageAmount));
  //      _playerStats.HealFlat(Random.Range(minHealAmount, maxHealAmount));

		////FlyingSword.transform.parent = FirstBoss.instance.transform;
		//Transform tmp = (Transform)Instantiate(FlyingSword, Vector3.zero, Quaternion.identity);
		//tmp.parent = Valac.instance.transform;
		//tmp.position = Valac.instance.transform.position;

  //      if (PlayerParticleSys)
  //          Instantiate(PlayerParticleSys, Player.player.transform.position + new Vector3(0, PlayerParticlesHeight, 0), PlayerParticleSys.transform.rotation);
  //      if (BossParticleSys)
  //          Instantiate(BossParticleSys, Valac.instance.transform.position + new Vector3(0, BossParticlesHeight, 0), BossParticleSys.transform.rotation);
	}
}