using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class HighscoreRow_Button : MonoBehaviour, ISelectHandler
{
	public Highscore _highScore;

	public void OnSelect(UnityEngine.EventSystems.BaseEventData data)
	{
		SelectedHighscoreInfo.Instance.SetHighscore(_highScore);
	}
}
