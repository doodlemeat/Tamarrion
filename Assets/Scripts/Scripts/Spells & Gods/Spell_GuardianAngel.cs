using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Spell_GuardianAngel : PassiveSpellBase {
		public float percent = 10.0f;
		public float invulnerableDuration = 0.0f;

		public override void onCastSpell (SpellBase spell) {
			float n = Random.Range (0.0f, 100.0f);
			if ( n <= percent ) {
				playerStats.Add_Modifier ("guardian_angel", "invulnerable", 1.0f, 0.0f);
				BuffManager.player_buffs.AddBuff ("guardian_angel", Player.player.gameObject, invulnerableDuration, spellIcon);
			}
		}
	}
}