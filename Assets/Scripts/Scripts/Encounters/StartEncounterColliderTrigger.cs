using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class StartEncounterColliderTrigger : MonoBehaviour
{
    public Encounter m_attachedEncounter;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (m_attachedEncounter.GetStarted() == false && collider.gameObject != Player.player.gameObject)
            return;

        m_attachedEncounter.StartEncounter();
    }
}
