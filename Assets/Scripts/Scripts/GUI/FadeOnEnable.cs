using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOnEnable : MonoBehaviour
{
    public bool FadeIn = true;
    public float Delay = 1;
    private float DelayCurrent = 0;

    public float FadeInTime = 2;
    private float FadeInCurrent = 0;
    private CanvasGroup canvasGroup = null;

    void OnEnable()
    {
        //Debug.Log("OnEnable");
        Time.timeScale = 1;
        DelayCurrent = Delay;
        FadeInCurrent = FadeInTime;
        if (GetComponent<CanvasGroup>())
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (FadeIn)
                canvasGroup.alpha = 0;
            else
                canvasGroup.alpha = 1;
        }
    }

    void Update() {
        if (!canvasGroup)
            return;
        if (DelayCurrent > 0) {
            //Debug.Log("Delay: " + DelayCurrent);
            DelayCurrent -= Time.deltaTime;
            //Debug.Log("After: " + DelayCurrent);
            if (DelayCurrent > 0)
                return;
            else
                DelayCurrent = 0;
        }

        if (FadeInCurrent > 0) {
            //Debug.Log("Fade");
            FadeInCurrent -= Time.deltaTime;
            if (FadeInCurrent <= 0)
                FadeInCurrent = 0;

            if (FadeIn)
                canvasGroup.alpha = 1 - (FadeInCurrent / FadeInTime);
            else
                canvasGroup.alpha = (FadeInCurrent / FadeInTime);
        }
    }

    public void ChangeDelay(float p_time) {
        //Debug.Log("ChangeDelay");
        if (FadeIn)
            canvasGroup.alpha = 0;
        else
            canvasGroup.alpha = 1;

        Delay = DelayCurrent = p_time;
    }
}