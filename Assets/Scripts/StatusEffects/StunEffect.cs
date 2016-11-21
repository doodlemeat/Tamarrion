using System;
using UnityEngine;

namespace Tamarrion {
	public class StunEffect : StatusEffect {
		public StunEffect(float duration) : base(StatusEffectType.Stun, duration) {

		}

		public override void onApply() {
			target.GetComponentInChildren<Animator>().SetBool("Stunned", true);
			if (target.GetComponent<NavMeshAgent>() != null)
				target.GetComponent<NavMeshAgent>().enabled = false;
			//if (StunFX != null)
			//    StunFX.SetActive(true);
		}

		public override void onTick() {
			throw new NotImplementedException();
		}

		public override void onEnd() {
			target.GetComponentInChildren<Animator>().SetBool("Stunned", false);
			if (target.GetComponent<NavMeshAgent>() != null)
				target.GetComponent<NavMeshAgent>().enabled = true;
			//if (StunFX != null)
			//    StunFX.SetActive(false);
		}
	}
}
