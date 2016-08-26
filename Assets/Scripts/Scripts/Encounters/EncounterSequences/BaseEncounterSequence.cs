using UnityEngine;
using System.Collections;

abstract public class BaseEncounterSequence : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossHealthbar;

    protected bool sequenceComplete = false;

    public virtual void StartSequence()
    {
        if (bossHealthbar)
            bossHealthbar.SetActive(true);
    }

    public abstract void Update();
}
