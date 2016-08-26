using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubMenu : MonoBehaviour
{
    public Menu parent;
    public Button DefaultButton;

    private bool Active = false;
    private CanvasGroup canvGroup;

    public void Start()
    {
        canvGroup = gameObject.GetComponent<CanvasGroup>();
        Deactivate(false);
    }

    public void Activate()
    {
        Active = true;
        canvGroup.alpha = 1;
        canvGroup.blocksRaycasts = true;
        canvGroup.interactable = true;

        if (DefaultButton)
            DefaultButton.Select();

        MenuManager.instance.ShowMenu(null);
    }

    public void Update()
    {
        if (!Active)
            return;

        if (Input.GetButtonDown("Back"))
            Deactivate();
    }

    public void Deactivate(bool p_showParentMenu = true)
    {
        Active = false;
        canvGroup.alpha = 0;
        canvGroup.blocksRaycasts = false;
        canvGroup.interactable = false;

        if (p_showParentMenu)
            MenuManager.instance.ShowMenu(parent);
    }
}
