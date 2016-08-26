using UnityEngine;

namespace Tamarrion {
	public class BossDeathEffect : MyMonoBehaviour {
		Transform target;
		Vector3 offsetAngles;

		void Awake () {
			AddListener<BossDeathEffectActivateEvent> (OnBossDeathEffectActivate);
		}

		void OnDestroy () {
			RemoveListener<BossDeathEffectActivateEvent> (OnBossDeathEffectActivate);
		}

		void OnBossDeathEffectActivate (BossDeathEffectActivateEvent e) {
			target = e.target;
			offsetAngles = e.offsetAngles;

			UpdatePosition ();
		}

		void Update () {
			UpdatePosition ();
			UpdateRotation ();
		}

		void UpdatePosition() {
			if ( transform ) {
				transform.position = target.position;
			}
		}

		void UpdateRotation() {
			if ( transform ) {
				transform.rotation = target.rotation;
			}
		}
	}
}
