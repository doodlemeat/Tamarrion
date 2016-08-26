using UnityEngine;
using System.Collections;

public class Spell_Heavy : SpellBase
{
    public float percentVulnerability = -0.2f;
    public float stunDuration = 2.0f;
    public GameObject effect;
    public GameObject CastParticleSys;
    public float speed;
    public float minDamage;
    public float maxDamage;
    public CombatText FloatingText;

    //Enemy_Stats Enemy_Stats;

    public override void Start()
    {
        base.Start();
        //if (FirstBoss.instance)
        //    Enemy_Stats = FirstBoss.instance.GetComponent<Enemy_Stats>();
    }

    public override void use()
	{
		base.use();
		if(!Valac.instance) return;
		
        bool crit = _playerStats.GetCrit();
        float base_damage = _playerStats.m_stat["damage"] + _playerStats.m_stat["magical"];
        float damage = Random.Range(base_damage, base_damage * 1.5f) * (crit ? _playerStats.m_stat["crit_damage"] : 1.0f);

        //hand particle effect
        if (CastParticleSys)
        {
            Transform CastTransform = Player.player.LeftHand ? Player.player.LeftHand.transform : Player.player.transform;
            Vector3 Offset = new Vector3(0, !Player.player.LeftHand ? 1.1f : 0, 0);
            GameObject partSys = (GameObject)Instantiate(CastParticleSys, CastTransform.position + Offset, Player.player.transform.rotation);
            partSys.transform.SetParent(CastTransform);
        }

        if (effect) {
            Vector3 ProjSpawnPos = Player.player.LeftHand ? Player.player.LeftHand.transform.position : Player.player.transform.position + new Vector3(0, 1.1f, 0);
            GameObject projectileObject = (GameObject)Instantiate(effect, ProjSpawnPos, Player.player.transform.rotation);
            Projectile projectileScript = projectileObject.GetComponent<Projectile>();
            projectileScript.speed = speed;
            projectileScript.damage = damage + Random.Range(minDamage, maxDamage);
            projectileScript.crit = crit;
            //projectileScript.target = FirstBoss.instance.transform.FindChild("Spell target").gameObject;
            projectileScript.heavy = true;
            //projectileScript.duration = stunDuration;
            //projectileScript.vurnuability = percentVulnerability;
            //projectileScript.icon = _spellIconMenu;
        }
		/*damage = Enemy_Stats.DealDamage(damage + Random.Range(minDamage, maxDamage), crit);*/

    }
}
