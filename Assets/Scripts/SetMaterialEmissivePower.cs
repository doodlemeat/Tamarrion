using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]

public class SetMaterialEmissivePower : MonoBehaviour
{
    public float StartPower = 1f;

    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_EmissivePower", StartPower);
    }

    public void SetEmissivePower(float p_value)
    {
        GetComponent<Renderer>().material.SetFloat("_EmissivePower", p_value);
    }
}
