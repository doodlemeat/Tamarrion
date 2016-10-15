using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Cleave_updater : Base_EnemySkill_Telegraph {
        protected override void CheckHit() {
            base.CheckHit();
            if (ForcePusher.instance)
                ForcePusher.instance.SendForceFromObject(gameObject, new Vector3(20, 0, 0), 0.15f, ForcePusher.Shape.Box, new Vector3(3.5f, 2, 3.5f), new Vector3(0, 1.25f, 0), false);
        }
    }
}