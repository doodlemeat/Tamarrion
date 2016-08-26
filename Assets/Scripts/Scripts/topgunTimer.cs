using UnityEngine;
using System.Collections;

public class TopgunTimer
{
    float currentTime = 0;
    float maxTime = 0;
    bool complete = true;
    
    public void Update()
    {
        if (complete)
            return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
            SetToComplete();
    }

    public void StartTimerBySeconds(float p_seconds)
    {
        complete = false;
        currentTime = maxTime = p_seconds;
    }

    public bool IsComplete
    {
        get { return complete; }
    }

    public float PercentComplete()
    {
        return currentTime / maxTime;
    }

    public void SetToComplete()
    {
        currentTime = 0;
        complete = true;
    }
}
