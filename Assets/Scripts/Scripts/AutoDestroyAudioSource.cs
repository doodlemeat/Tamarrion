using UnityEngine;
using System.Collections;

public class AutoDestroyAudioSource : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
            Destroy(gameObject);
    }
}
