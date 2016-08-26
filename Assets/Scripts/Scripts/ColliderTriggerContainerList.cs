using UnityEngine;
using System.Collections.Generic;

public class ColliderTriggerContainerList : MonoBehaviour
{
    public List<GameObject> containerList = new List<GameObject>();

    virtual protected void OnTriggerEnter(Collider other)
    {
        if (!containerList.Contains(other.gameObject))
            containerList.Add(other.gameObject);
    }

    virtual protected void OnTriggerExit(Collider other)
    {
        if (containerList.Contains(other.gameObject))
            containerList.Remove(other.gameObject);
    }
}
