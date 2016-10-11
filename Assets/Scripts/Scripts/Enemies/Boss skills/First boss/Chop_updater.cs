using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Chop_updater : Base_EnemySkill_Telegraph {
		protected override void CheckHit () {
			base.CheckHit ();
			if ( ForcePusher.instance )
				ForcePusher.instance.SendForceFromObject (Valac.instance.gameObject, new Vector3 (20, 0, 0), 0.15f, ForcePusher.Shape.Box, new Vector3 (4, 2, 4), new Vector3 (0, 1.25f, 0), true);
		}
	}
}