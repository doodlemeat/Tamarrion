using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Spell_HolyLight : SpellBase {
		public float minHealAmount = 15;
		public float maxHealAmount = 25;

		public override void use () {
			Debug.Log ("Spell_HolyLight:use");
			base.use ();
			_playerStats.HealFlat (Random.Range (minHealAmount, maxHealAmount));
		}
	}
}