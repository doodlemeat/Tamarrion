using UnityEngine;
using System.Collections;

public class SlideableObject : MonoBehaviour
{
    //private Collider targetCollider;

    void Start()
    {
        //targetCollider = gameObject.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("trigger enter");
    }

    void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("collision enter");
    }

    void OnControllerColliderHit(Collision collision)
    {
       // Debug.Log("controller enter");
    }
}
