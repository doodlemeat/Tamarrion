using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Timer {
        private float time;
        private float duration;

        private bool finished = true;

        public void Update() {
            if (finished)
                return;

            time += Time.deltaTime;

            if (time >= duration) {
                Finish();
            }
        }

        public void Start(float duration) {
            this.duration = duration;
            time = 0;
            finished = false;
        }

        public void Finish() {
            time = duration;
            finished = true;
        }

        public float Progress() {
            return time / duration;
        }

        public bool IsFinished {
            get { return finished; }
        }
    }
}
