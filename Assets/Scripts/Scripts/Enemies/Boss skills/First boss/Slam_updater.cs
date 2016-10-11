using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Slam_updater : Base_EnemySkill_Telegraph {

		public GameObject slam_effect;

		protected override void ActivatedSkill () {
			slam_effect = (GameObject)Instantiate (slam_effect, transform.position, transform.rotation);
			Vector3 tmp = slam_effect.transform.rotation.eulerAngles;
			tmp.x = -20.0f;
			slam_effect.transform.rotation = Quaternion.Euler (tmp);
			tmp = slam_effect.transform.position;
			tmp.y = 0.0f;
			slam_effect.transform.position = tmp;
			//slam_effect.transform.position -= transform.up * Offset;
			var hit = CameraEffectManager.Instance.Create<Hit> ();
			hit.Play ();
		}
		protected override void CheckHit () {
			base.CheckHit ();

			var rumble = CameraEffectManager.Instance.Create<Rumble> ();
			rumble._speed = 2;
			rumble._Size = 50;
			rumble.Play ();

			if ( ForcePusher.instance )
				ForcePusher.instance.SendForceFromObject (Valac.instance.gameObject, new Vector3 (50, 0, 0), 0.07f, ForcePusher.Shape.Box, new Vector3 (6, 2, 6), new Vector3 (0, 1.25f, 0), false);
		}
	}
}