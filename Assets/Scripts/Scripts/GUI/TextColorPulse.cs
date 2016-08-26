using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TextColorPulse : MonoBehaviour
{
    public AnimationCurve pulseCurve = new AnimationCurve();
    public float pulseSpeedInSeconds = 1f;
    public Color firstColor = Color.white;
    public Color secondColor = Color.white;

    Text targetText;
    TopgunTimer pulseTimer = new TopgunTimer();

    void Start()
    {
        RestartTimer();

        targetText = GetComponent<Text>();
        if (!targetText)
            this.enabled = false;
    }

    void RestartTimer()
    {
        pulseTimer.StartTimerBySeconds(pulseSpeedInSeconds);
    }

    void Update()
    {
        pulseTimer.Update();
        if(pulseTimer.IsComplete)
        {
            RestartTimer();
        }
        targetText.color = Color.Lerp(firstColor, secondColor, pulseCurve.Evaluate(pulseTimer.PercentComplete()));
    }
}
