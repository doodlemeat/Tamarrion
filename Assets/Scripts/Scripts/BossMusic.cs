using UnityEngine;
using System.Collections;

public class BossMusic : MonoBehaviour
{
    public static BossMusic instance;

    public float FadeInTime = 2;
    public float LowerVolumeDelay = 25;
    public float LowerVolumeFadeTime = 10;
    public float TargetMusicVolumeStandard;
    private float FadeInTimeCurrent = 2;
    private float TargetMusicVolumeLoud;
    private float LowerVolumeFadeTimeCurrent = 10;
    private bool Started = false;

    private float PauseTime;
    private AudioSource TargetAudioSource;

    void Awake()
    {
        instance = this;

        TargetAudioSource = GetComponent<AudioSource>();
        FadeInTimeCurrent = FadeInTime;
        LowerVolumeFadeTimeCurrent = LowerVolumeFadeTime;
        if (TargetAudioSource)
            TargetMusicVolumeLoud = TargetAudioSource.volume;
    }

    void Update()
    {
        if (!TargetAudioSource)
            return;

        if (Started)
        {
            if (FadeInTimeCurrent > 0)
            {
                FadeInTimeCurrent -= Time.deltaTime;
                if (FadeInTimeCurrent <= 0)
                    FadeInTimeCurrent = 0;

                TargetAudioSource.volume = Mathf.Lerp(0, TargetMusicVolumeLoud, 1 - (FadeInTimeCurrent / FadeInTime));
            }
            if (LowerVolumeDelay > 0)
            {
                LowerVolumeDelay -= Time.deltaTime;
                if (LowerVolumeDelay <= 0)
                    LowerVolumeDelay = 0;
            }
            else
            {
                if (LowerVolumeFadeTimeCurrent > 0)
                {
                    LowerVolumeFadeTimeCurrent -= Time.deltaTime;
                    if (LowerVolumeFadeTimeCurrent <= 0)
                        LowerVolumeFadeTimeCurrent = 0;

                    TargetAudioSource.volume = Mathf.Lerp(TargetMusicVolumeLoud, TargetMusicVolumeStandard, 1 - (LowerVolumeFadeTimeCurrent / LowerVolumeFadeTime));
                }
            }
        }
    }

    public void StartMusic(float p_offset)
    {
        if (!TargetAudioSource)
            return;
        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
        //audioSource.volume = 0;
        //audioSource.time = p_offset;

        TargetAudioSource.Play();
        TargetAudioSource.volume = 0;
        TargetAudioSource.time = p_offset;
        
        Started = true;
    }

    public void PauseMusic()
    {
        if (!Started || !TargetAudioSource)
            return;
        
        PauseTime = TargetAudioSource.time;
        TargetAudioSource.Stop();
    }

    public void ResumeMusic()
    {
        if (!Started || !TargetAudioSource)
            return;

        TargetAudioSource.Play();
        TargetAudioSource.time = PauseTime;
    }
}