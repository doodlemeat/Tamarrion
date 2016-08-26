using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Cloth))]

public class ClothRotationCorrection : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 targetExtAcceleration;
    Vector3 targetRandomAcceleration;
    Cloth cloth;

    void Start()
    {
        cloth = GetComponent<Cloth>();
        targetExtAcceleration = cloth.externalAcceleration;
        targetRandomAcceleration = cloth.randomAcceleration;
    }

    void Update()
    {
        if (!targetTransform)
            return;

        cloth.externalAcceleration = Quaternion.Euler(targetTransform.forward) * targetExtAcceleration;
        cloth.randomAcceleration = Quaternion.Euler(targetTransform.forward) * targetRandomAcceleration;
        //Debug.Log(targetTransform.forward);
        //Debug.Log(cloth.externalAcceleration + " " + cloth.randomAcceleration);
    }
}
