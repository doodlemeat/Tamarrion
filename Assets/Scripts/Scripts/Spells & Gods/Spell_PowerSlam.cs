using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Spell_PowerSlam : SpellBase {
		public float minDamage;
		public float maxDamage;
		public CombatText FloatingText;
		public float percentVulnerability = -0.2f;
		public float stunDuration = 2.0f;

		Enemy_Stats enemyStats;

		public override void Start () {
			base.Start ();

			if ( Valac.instance != null ) {
				enemyStats = Valac.instance.GetComponent<Enemy_Stats> ();
			}
		}

		public override void use () {
			base.use ();

			if ( Valac.instance == null )
				return;

			bool crit = _playerStats.GetCrit ();
			float base_damage = _playerStats.m_stat["damage"] + _playerStats.m_stat["physical"];
			float damage = Random.Range (base_damage, base_damage * 1.5f) * (crit ? _playerStats.m_stat["crit_damage"] : 1.0f);

			damage = enemyStats.DealDamage (damage + Random.Range (minDamage, maxDamage), crit);


			//      BuffManager.boss_buffs.AddBuff("Stun", "Boss", stunDuration, _spellIconMenu);
			//Enemy_Stats.Add_Modifier("Stun", "stun", 1);

			//      BuffManager.boss_buffs.AddBuff("DR", "Boss", stunDuration, _spellIconMenu);
			//Enemy_Stats.Add_Modifier("DR", "damage_reduction", percentVulnerability);
		}
	}
}