using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class CanvasGroupController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    TopgunTimer fadeTimer = new TopgunTimer();
    bool shown = false;
    bool fadeActive = false;
    enum FadeState
    {
        In,
        Out
    }
    FadeState fadeOutActive = FadeState.In;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (fadeActive)
        {
            fadeTimer.Update();
            if (canvasGroup)
                canvasGroup.alpha = (fadeOutActive != FadeState.In) ? fadeTimer.PercentComplete() : 1f - fadeTimer.PercentComplete();

            if (fadeTimer.IsComplete)
                fadeActive = false;
        }
    }

    public void Show(float p_fadeInTime = 0f)
    {
        if (canvasGroup)
        {
            shown = true;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            if (p_fadeInTime == 0f)
                canvasGroup.alpha = 1f;
            else
            {
                fadeActive = true;
                fadeOutActive = FadeState.In;
                fadeTimer.StartTimerBySeconds(p_fadeInTime);
            }
        }
    }

    public void Hide(float p_fadeInTime = 0f)
    {
        if (canvasGroup)
        {
            shown = false;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            if (p_fadeInTime == 0f)
                canvasGroup.alpha = 0f;
            else
            {
                fadeActive = true;
                fadeOutActive = FadeState.Out;
                fadeTimer.StartTimerBySeconds(p_fadeInTime);
            }
        }
    }

    public bool IsShown { get { return shown; } }
}
