using UnityEngine;

namespace Tamarrion {
	public class BossDeathEffectActivateEvent : BaseEvent {
		public Transform target;
		public Vector3 offsetAngles;

		public BossDeathEffectActivateEvent (Transform target, Vector3 offsetAngles) {
			this.target = target;
			this.offsetAngles = offsetAngles;
		}
	}
}

