using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Swipe_updater : Base_EnemySkill_Telegraph {
        public float ForceTimer;
        private float ForceTimerCurrent;
        private float Angle = 0;

        protected override void Update_telegrapher_movement() {
            base.Update_telegrapher_movement();
            ForceTimerCurrent -= Time.deltaTime;
            if (ForceTimerCurrent <= 0) {
                ForceTimerCurrent = ForceTimer;

                float ForceStrength = 20;
                float xForce = (Angle == 0) ? 1 : ((Angle == 180) ? -1 : 0);
                float zForce = (Angle == 90) ? 1 : ((Angle == 270) ? -1 : 0);

                xForce *= ForceStrength;
                zForce *= ForceStrength;

                if (ForcePusher.instance)
                    ForcePusher.instance.SendForceFromObject(Valac.instance.gameObject, new Vector3(xForce, 0, zForce), 0.15f, ForcePusher.Shape.Box, new Vector3(3.5f, 2, 3.5f), new Vector3(0, 1.25f, 0), false);

                Angle = (Angle + 90) % 360;
            }
        }

        protected override void ActivatedSkill() {
            Valac.instance.Whirling = true;
        }
        protected override void OnExit() {
            Valac.instance.gameObject.GetComponentInChildren<Animator>().SetBool("Swipe", false);
        }
    }
}