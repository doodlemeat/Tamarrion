using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class HighscoreLoader : MonoBehaviour
{
	public static HighscoreLoader Instance;
	public Menu menu;
	public GameObject _rowObject;

	Dictionary<int, List<Highscore>> _scores = new Dictionary<int, List<Highscore>>();
	RectTransform _myTransform;
	Button _firstButton;
	int _currentDifficulty;

	void Awake()
	{
		Instance = this;
		_myTransform = transform as RectTransform;
	}

	void SortHighscores()
	{
		List<int> keys = new List<int>(_scores.Keys);

		foreach (int key in keys)
		{
			_scores[key] = _scores[key].OrderBy(o => o.duration).ToList();
		}
	}

	void BuildHighscoresTable()
	{
		foreach (Transform t in transform)
		{
			Destroy(t.gameObject);
		}

		_myTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

		int place = 1;

		if(!_scores.ContainsKey(_currentDifficulty))
		{
			return;
		}

		foreach (Highscore highscore in _scores[_currentDifficulty])
		{
			GameObject rowObject = (GameObject)Instantiate(_rowObject);

			rowObject.transform.SetParent(_myTransform, false);

			_myTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _myTransform.sizeDelta.y + ((RectTransform)(rowObject.transform)).sizeDelta.y);

			Text positionText = rowObject.transform.Find("#").GetComponent<Text>();
			Text timeText = rowObject.transform.Find("Time").GetComponent<Text>();
			Text nameText = rowObject.transform.Find("Name").GetComponent<Text>();

			positionText.text = place.ToString();
			timeText.text = highscore.duration.ToString() + " secs";
			nameText.text = highscore.name;

			HighscoreRow_Button buttonScript = rowObject.GetComponent<HighscoreRow_Button>();
			buttonScript._highScore = highscore;

			if (place == 1)
			{
				_firstButton = rowObject.GetComponent<Button>();
				_firstButton.Select();
			}
			++place;
		}

		HighscoreScrollbar.Instance._scrollbar.value = 1;
	}

	public void applyFilters(int difficulty)
	{
		_currentDifficulty = difficulty;
	}

	public void SelectFirstButton()
	{
		if (_firstButton)
		{
			_firstButton.Select();
		}
	}
}
