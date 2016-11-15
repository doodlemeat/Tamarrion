using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Timer {
        private float time;
        private float duration;

        private bool finished;

        public void Update() {
            if (finished)
                return;

            time += Time.deltaTime;

            if (time > duration) {
                time = duration;
                finished = true;
            }
        }

        public void Start(float duration) {
            this.duration = duration;
            finished = false;
        }

        public float Progress() {
            return time / duration;
        }

        public bool isFinished() {
            return finished;
        }
    }
}
