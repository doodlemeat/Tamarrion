using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowCanvasGroupOnMouseOver : MonoBehaviour
{
    public bool showFromStart = false;
    bool showThis = false;
    public CanvasGroup targetCanvasGroup;

    void Start()
    {
        if (showFromStart)
            Show();
        else
            Hide();
    }

    public void Show()
    {
        showThis = true;
        targetCanvasGroup.alpha = 1;
    }

    public void Hide()
    {
        showThis = false;
        targetCanvasGroup.alpha = 0;
    }
    
    bool GetShown()
    {
        return showThis;
    }

    public void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        Show();
    }

    public void OnMouseExit()
    {
        Debug.Log("mouse exit");
        Hide();
    }
}
