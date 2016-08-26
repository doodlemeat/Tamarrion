using UnityEngine;
using System.Collections;

public class FractureCollision : MonoBehaviour
{
    public class ExampleClass : MonoBehaviour
    {
        public float pushPower = 2.0F;

        void OnCollisionEnter(Collision hit)
        {
            //Debug.Log("hit!");
            Rigidbody body = hit.collider.attachedRigidbody;
            if (body == null || body.isKinematic)
                return;

            if (hit.relativeVelocity.y < -0.3F)
                return;

            Vector3 pushDir = new Vector3(hit.relativeVelocity.x, 0, hit.relativeVelocity.z);
            body.velocity = pushDir * pushPower;
        }
    }
}
