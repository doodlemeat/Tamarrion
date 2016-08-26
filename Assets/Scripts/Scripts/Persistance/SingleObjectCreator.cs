using UnityEngine;
using System.Collections;

public class SingleObjectCreator : MonoBehaviour
{
    public GameObject Object;

    void Start()
    {
        CreateObjectCheck();
    }

    void OnLevelWasLoaded()
    {
        CreateObjectCheck();
    }

    void CreateObjectCheck()
    {
        if (!Object)
            return;

        //Debug.Log("object creation check");
        if (FindObjectsOfType(Object.GetType()).Length != 0)
        {
            //Debug.Log("creating object: " + Object.name);
            Instantiate(Object);
        }
    }
}