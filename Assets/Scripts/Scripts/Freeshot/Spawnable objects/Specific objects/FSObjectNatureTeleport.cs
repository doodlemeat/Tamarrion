using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]

public class FSObjectNatureTeleport : FSObjectArea
{
    public float teleportDelaySeconds = 4f;
    FSObjectNatureTeleport otherTeleport;
    public ParticleSystem teleportObjectEffect;

    GameObject m_targetObject;
    TopgunTimer teleportDelayTimer = new TopgunTimer();
    bool m_teleportUsed = false;

    public delegate void TeleportAction();
    public static event TeleportAction onTeleport;

    override protected void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (!PlayerIsTarget() && Player.GameObjectIsPlayer(other.gameObject))
        {
            SetNewTargetObject(Player.player.gameObject);
        }

        if (other.CompareTag("Force"))
            return;

        if (other.gameObject.transform.parent)
        {
            if (Enemy_List.GameObjectIsEnemy(other.gameObject.transform.parent.gameObject))
            {
                if (!PlayerIsTarget())
                    SetNewTargetObject(other.gameObject.transform.parent.gameObject);
            }
        }
    }

    bool PlayerIsTarget()
    {
        return (m_targetObject && m_targetObject == Player.player.gameObject);
    }

    public void SetOtherTeleport(FSObjectNatureTeleport p_other)
    {
        if (p_other == null)
            otherTeleport = null;
        else
            otherTeleport = p_other;

        ResetDelay();
    }

    public void ResetDelay()
    {
        teleportDelayTimer.StartTimerBySeconds(teleportDelaySeconds);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Force"))
            return;

        if (m_targetObject)
        {
            if (m_targetObject == other.gameObject || (ObjectHasParent(other.gameObject) && m_targetObject == other.gameObject.transform.parent.gameObject))
            {
                RemoveTargetObject();
                ChangeTargetIfAnyInArea();
            }
        }
    }

    bool ObjectHasParent(GameObject p_object)
    {
        return (p_object.transform.parent != null);
    }

    void SetNewTargetObject(GameObject p_object)
    {
        if (p_object == null)
        {
            RemoveTargetObject();
            return;
        }

        m_targetObject = p_object;

        ActivateEffect();
        ResetDelay();
    }

    void ActivateEffect()
    {
        if (teleportObjectEffect)
        {
            if (teleportObjectEffect.isStopped)
                teleportObjectEffect.Play();

            teleportObjectEffect.enableEmission = true;
            teleportObjectEffect.loop = true;
        }

    }

    void DisableEffect()
    {
        if (teleportObjectEffect)
        { 
            teleportObjectEffect.enableEmission = false;
            teleportObjectEffect.loop = false;
        }
    }

    void RemoveTargetObject()
    {
        m_targetObject = null;
        DisableEffect();
    }

    void ChangeTargetIfAnyInArea()
    {
        if (m_enemiesWithinBounds.Count > 0)
            SetNewTargetObject(m_enemiesWithinBounds[0]);
    }

    public override void Update()
    {
        base.Update();

        if (m_teleportUsed)
            return;

        if (m_targetObject != null && m_targetObject != Player.player.gameObject && m_PlayerIsWithinBounds)
            SetNewTargetObject(Player.player.gameObject);

        if (m_targetObject && otherTeleport)
        {
            teleportDelayTimer.Update();
            if (teleportDelayTimer.IsComplete)
                PerformTeleport();
        }
    }

    void PerformTeleport()
    {
        onTeleport();

        if (m_targetObject && otherTeleport)
        {
            m_targetObject.transform.position = otherTeleport.transform.position;
        }

        m_teleportUsed = true;
    }

    public bool GetTeleportUsed()
    {
        return m_teleportUsed;
    }

    public void RemoveTeleport()
    {
        m_teleportUsed = true;
        Destroy(gameObject);
    }
}
