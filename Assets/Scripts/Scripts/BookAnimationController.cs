using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animation))]

public class BookAnimationController : MonoBehaviour
{
    public Text pressAnyButtonText;
    public bool waitForButtonPress = true;
    public string StartAnimButton;
    public string CancelButton;
    public string animationName;

    bool Active = true;
    bool buttonHasBeenPressed = false;
    Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        if (waitForButtonPress)
            Active = false;
    }

    void Update()
    {
        if (!Active && !buttonHasBeenPressed)
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                buttonHasBeenPressed = true;
                Active = true;
                anim.Play(animationName);
                if (pressAnyButtonText)
                    pressAnyButtonText.enabled = false;
            }
        }
        
        if(Active && anim.isPlaying)
        {
            if (Input.GetButtonDown(CancelButton))
            {
                anim[animationName].speed = 100;
                MenuManager.instance.CompleteDelay();
            }

            if (!anim.isPlaying)
                Active = false;
        }
    }

    public void RestartAnimation()
    {
        Active = true;
        anim[animationName].speed = 1;
        anim[animationName].time = 0;
        anim.Play(animationName);
    }
}
