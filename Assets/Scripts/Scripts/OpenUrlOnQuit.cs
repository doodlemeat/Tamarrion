using UnityEngine;
using System.Collections;

public class OpenUrlOnQuit : MonoBehaviour
{
    public string adress;

    void OnApplicationQuit()
    {
        Application.OpenURL(adress);
    }
}
