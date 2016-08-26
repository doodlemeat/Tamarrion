using UnityEngine;
using System.Collections;

public class EnableTargetObjectOnAwake : MonoBehaviour
{
    public GameObject target;

    void Awake()
    {
        if (target)
            target.SetActive(true);
    }
}
