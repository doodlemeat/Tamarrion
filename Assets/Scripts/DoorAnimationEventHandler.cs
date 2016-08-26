using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class DoorAnimationEventHandler : MonoBehaviour
{
    public GameObject _openSourceObject;
    AudioSource _openSource;
    public bool OnlyPlayOpenSoundOnce = true;
    bool SoundHasBeenPlayed = false;

    void Start()
    {
        _openSource = _openSourceObject.GetComponent<AudioSource>();
    }

    public void OnOpen()
    {
        if (!SoundHasBeenPlayed)
        {
            _openSource.Play();
            SoundHasBeenPlayed = true;
        }
    }
}
