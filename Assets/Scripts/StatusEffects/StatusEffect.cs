using UnityEngine;

namespace Tamarrion {
    public enum StatusEffectType {
        Invulnerability,
        Stun,
        Poison,
        Absorption
    }

    public abstract class StatusEffect {
        protected StatusEffectType type;
        protected GameObject target;
        protected float duration;

        private bool finished;

        public StatusEffect(StatusEffectType type, float duration) {
            this.type = type;
            this.duration = duration;
            finished = false;
        }

        public abstract void onApply();

        public abstract void onTick();

        public abstract void onEnd();

		public void setTarget(GameObject target) {
			this.target = target;
		}

        public StatusEffectType GetType() {
            return type;
        }

        public void Update() {
            if (finished)
                return;

            duration -= Time.deltaTime;
            
            if (duration <= 0) {
                finished = true;
                onEnd();
            }
        }

        public bool isFinished() {
            return finished;
        }
    }
}
