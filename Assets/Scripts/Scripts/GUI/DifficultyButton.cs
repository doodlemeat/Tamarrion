using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DifficultyButton : MonoBehaviour, ISelectHandler
{
    public Difficulty.difficulty DifficultySetting = Difficulty.difficulty.beginner;

    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { OnClick(); });
    }

    void OnClick()
    {
        Difficulty.Current_difficulty = DifficultySetting;
    }

    public void OnSelect(UnityEngine.EventSystems.BaseEventData data)
    {
        UpdateDifficultySetting();
    }

    public void OnMouseEnter()
    {
        UpdateDifficultySetting();
    }

    void UpdateDifficultySetting()
    {
        if (DifficultyMarker.instance)
            DifficultyMarker.instance.SetDifficultyTexture(DifficultySetting);
    }
}
