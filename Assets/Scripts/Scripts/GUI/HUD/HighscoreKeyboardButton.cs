using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreKeyboardButton : MonoBehaviour
{
    public string OverrideKey = "";
    public string Hotkey = "";
    public bool EraseLetter = false;

    private bool HotkeyEnabled = false;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { OnClick(); });
        HotkeyEnabled = (Hotkey != "");
        //if (HotkeyEnabled)
        //    Debug.Log("hotkey enabled! " + gameObject);
    }

    void Update()
    {
        if (HotkeyEnabled && Input.GetButtonDown(Hotkey))
        {
           // Debug.Log("hotkey clicked" + gameObject);
            OnClick();
        }
    }

    void OnClick()
    {
        if (HighscoreInputManager.instance)
        {
            if (EraseLetter)
                HighscoreInputManager.instance.EraseCurrentSelection();
            else
            {
                if (OverrideKey == "")
                    HighscoreInputManager.instance.SetLetter(gameObject.GetComponentInChildren<Text>().text);
                else
                    HighscoreInputManager.instance.SetLetter(OverrideKey);
            }
        }
    }
}
