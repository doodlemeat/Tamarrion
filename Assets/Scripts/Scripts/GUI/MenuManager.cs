using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Menu StartMenu;
    public Menu CurrentMenu;
    public bool waitForButtonpress = true;
    public float StartDelay = 0;

    bool buttonHasBeenPressed = false;
    private bool Started = false;
    private float DelayCurrent = 0;

    void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        DelayCurrent = StartDelay;
    }

    public void ShowMenu(Menu p_menu)
    {
        if (CurrentMenu)
            CurrentMenu.IsOpen = false;

        if (p_menu)
        {
            CurrentMenu = p_menu;
            CurrentMenu.Activate();
        }
    }

    public void RemoveCurrentMenu()
    {
        ShowMenu(null);
    }

    void Update()
    {
        if (waitForButtonpress && !buttonHasBeenPressed)
            if ((Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                buttonHasBeenPressed = true;
               
        if (!Started && (!waitForButtonpress || waitForButtonpress && buttonHasBeenPressed))
        {
            DelayCurrent -= Time.deltaTime;
            if (DelayCurrent <= 0)
            {
                DelayCurrent = 0;
                Started = true;
                ShowMenu(StartMenu);
            }
        }

        if (Input.GetButtonDown("Cancel") && CurrentMenu.BackEnabled)
            if (CurrentMenu)
                if (CurrentMenu.PreviousMenu && !CurrentMenu.PreviousMenu.IsCovered)
                    ShowMenu(CurrentMenu.PreviousMenu);
    }

    public void CompleteDelay()
    {
        DelayCurrent = 0;
    }

    public void Restart()
    {
        Started = false;

        if (CurrentMenu)
            CurrentMenu.IsOpen = false;

        DelayCurrent = StartDelay;
    }
}