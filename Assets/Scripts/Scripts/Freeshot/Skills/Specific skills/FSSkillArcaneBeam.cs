using UnityEngine;
using System.Collections;

public class FSSkillArcaneBeam : FSSkillBase
{
    [Header("Arcane Beam")]
    public GameObject ArcaneBeamObject;
    public Vector3 effectOffset = new Vector3();
    GameObject m_arcaneObjectInstance;

    public override void ApplySkillEffect()
    {
        m_arcaneObjectInstance = (GameObject)Instantiate(ArcaneBeamObject, Player.player.transform.position + GetRelativeOffsetFromObject(Player.player.gameObject), Player.player.transform.rotation);
        m_arcaneObjectInstance.transform.SetParent(Player.player.transform);
        m_arcaneObjectInstance.GetComponent<FSObjectArcaneBeam>().MagicDamagePercentage = MagicDamagePercentage;
    }

    Vector3 GetRelativeOffsetFromObject(GameObject p_obj)
    {
        return (p_obj.transform.forward * effectOffset.x) + (Vector3.up * effectOffset.y) + (p_obj.transform.right * effectOffset.z);
    }

    public override void SkillEnd()
    {
        m_arcaneObjectInstance.GetComponent<FSObjectArcaneBeam>().SpawnSparkParticles();
        Destroy(m_arcaneObjectInstance);
    }
}
