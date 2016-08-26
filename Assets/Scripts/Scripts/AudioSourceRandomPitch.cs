using UnityEngine;
using System.Collections;

public class AudioSourceRandomPitch : MonoBehaviour
{
    public float MaxPitch = 1;
    public float MinPitch = 1;

    void Start()
    {
        if (GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().pitch = Random.Range(MinPitch, MaxPitch);
        }
    }
}
