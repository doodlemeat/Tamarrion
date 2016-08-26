using UnityEngine;
using System.Collections;

public class ButtonSelectOnStart : MonoBehaviour
{
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().Select();
    }
}