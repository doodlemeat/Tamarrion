using UnityEngine;
using System.Collections;

public class TamSwordInstance : MonoBehaviour
{
    public static GameObject instance;

    void Awake()
    {
        instance = gameObject;
    }
}
