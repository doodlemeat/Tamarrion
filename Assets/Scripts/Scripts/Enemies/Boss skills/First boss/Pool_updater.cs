using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool_updater : Base_EnemySkill_Telegraph
{
    protected override void CheckHit()
    {
        base.CheckHit();
        if (ForcePusher.instance)
            ForcePusher.instance.SendForceFromPosition(gameObject.transform.position, new Vector3(0, 1, 0), 0.15f, ForcePusher.Shape.Cylinder, new Vector3(12, 0.05f, 12));
    }
}