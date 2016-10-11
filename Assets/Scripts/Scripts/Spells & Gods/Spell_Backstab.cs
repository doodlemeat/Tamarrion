using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Spell_Backstab : SpellBase {

		public float minDamage;
		public float maxDamage;

		public CombatText FloatingText;

		//Enemy_Stats Enemy_Stats;

		public override void Start () {
			base.Start ();

			//if (FirstBoss.instance != null) {
			//    Enemy_Stats = FirstBoss.instance.GetComponent<Enemy_Stats>();
			//}
		}

		public override void use () {
			base.use ();

			if ( Valac.instance == null )
				return;


		}
	}
}