using UnityEngine;
using System.Collections;
using System;

abstract public class FSSkillProjectile : FSSkillBase
{
    [Header("Projectile skill")]
    public GameObject projectileSpawnObject;

    public override void ApplySkillEffect()
    {
        if (projectileSpawnObject)
        { 
            GameObject obj = (GameObject)Instantiate(projectileSpawnObject, Player.player.LeftHand.position, Player.player.transform.rotation);
            FSObjectProjectile proj = obj.GetComponent<FSObjectProjectile>();
            proj.duration = base.duration;
            proj.shape = base.shape;
            proj.range = base.range;
        }
    }
}
