using UnityEngine;
using System.Collections;

abstract public class FSSkillArea : FSSkillBase
{
    [Header("Area skill")]
    public GameObject areaObject;
    protected Vector3 spawnPosition;
    protected Quaternion spawnRotation;

    public override void ApplySkillEffect()
    {
        if (areaObject)
        {
            GameObject obj = (GameObject)Instantiate(areaObject, spawnPosition, spawnRotation);
            FSObjectArea area = obj.GetComponent<FSObjectArea>();
            if (base.duration > 0)
                area.SetDuration(base.duration);

            area.MagicDamagePercentage = MagicDamagePercentage;
            area.PhysicalDamagePercentage = PhysicalDamagePercentage;
            //if (base.shape == FSSkillShape.FS_Shape_Circle)
            //    area.SetSphereCollisionRadius(base.shapeSize * 0.5f);
            //if (base.shape == FSSkillShape.FS_Shape_Box)
            //    area.SetSphereCollisionRadius(base.shapeSize * 0.5f); //TO-DO: fix to box
        }
    }

    public void SetSpawnPosition(Vector3 p_newSpawnPosition)
    {
        spawnPosition = p_newSpawnPosition;
    }

    public void SetSpawnRotation(Quaternion p_newSpawnRotation)
    {
        spawnRotation = p_newSpawnRotation;
    }
}
