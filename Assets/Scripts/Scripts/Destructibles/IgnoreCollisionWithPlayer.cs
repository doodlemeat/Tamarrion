using UnityEngine;
using System.Collections;

public class IgnoreCollisionWithPlayer : MonoBehaviour
{
    void Start()
    {
        CollisionIgnoranceManager.SetCollisionBetweenPlayerAndChosenCollider(gameObject.GetComponent<Collider>(), false);
    }
}
