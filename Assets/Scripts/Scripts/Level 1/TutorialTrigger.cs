using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour
{
    public TutorialProgression.TutorialMessageType tutorialMessage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.player.gameObject)
        {
            TutorialProgression.instance.Progress(tutorialMessage);
            Destroy(gameObject);
        }
    }
}
