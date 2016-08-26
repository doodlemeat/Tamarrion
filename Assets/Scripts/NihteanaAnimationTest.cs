using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]

public class NihteanaAnimationTest : MonoBehaviour
{
    Animator animator;

    class AnimationTestSetting
    {
        public KeyCode keycode = KeyCode.None;
        public string animationString = "";
        public bool state = false;

        public AnimationTestSetting() { }
    }

    public List<KeyCode> keycodes = new List<KeyCode>();
    public List<string> animationString = new List<string>();

    List<AnimationTestSetting> animationSettings = new List<AnimationTestSetting>();

    void Awake()
    {
        animator = GetComponent<Animator>();
        BuildAnimationTestSetting();
    }

    void Update()
    {
        foreach(AnimationTestSetting animSetting in animationSettings)
        {
            if(Input.GetKeyDown(animSetting.keycode))
            {
                animSetting.state = !animSetting.state;
                animator.SetBool(animSetting.animationString, animSetting.state);
                Debug.Log("(" + animSetting.keycode + ") " + animSetting.animationString + " set to: " + animSetting.state);
            }
        }
    }

    void BuildAnimationTestSetting()
    {
        if (keycodes.Count != animationString.Count)
        {
            Debug.LogWarning("different amount of keycodes and strings. must be the same.");
            return;
        }

        for (int i = 0; i < keycodes.Count; ++i)
        {
            AnimationTestSetting animSetting = new AnimationTestSetting();
            animSetting.keycode = keycodes[i];
            animSetting.animationString = animationString[i];
            animationSettings.Add(animSetting);
        }
    }
}
