using UnityEngine;
using System.Collections;

public class PlaySoundOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
