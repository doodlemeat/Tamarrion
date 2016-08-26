using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]

public class GodRayMaterialFade : MonoBehaviour
{
    public float fadeTime = 0.5f;
    TopgunTimer fadeTimer = new TopgunTimer();
    bool done = false;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        SetSeqSelectValue(0f);
        fadeTimer.StartTimerBySeconds(fadeTime);
    }

    void Update()
    {
        if (done)
            return;

        fadeTimer.Update();
        SetSeqSelectValue(fadeTimer.PercentComplete());

        if (fadeTimer.IsComplete)
        {
            SetSeqSelectValue(0f);
            done = true;
        }
    }

    void SetSeqSelectValue(float p_value)
    {
        rend.material.SetFloat("_SeqSelect", p_value);
    }
}
