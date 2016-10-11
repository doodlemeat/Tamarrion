using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class HighscoreFilters : MonoBehaviour {
		public static HighscoreFilters Instance;
		public Menu Menu;
		public Color ActiveColor = new Color ();
		public Color InactiveColor = new Color ();
		public Color ActiveTextColor = new Color ();
		public Color InactiveTextColor = new Color ();
		public string LeftButton;
		public string RightButton;
		public List<GameObject> _filterButtons = new List<GameObject> ();
		public int selected = 0;

		private bool Valid = false;

		void Awake () {
			Instance = this;
		}

		void Start () {
			if ( _filterButtons.Count == 0 ) {
				Debug.LogWarning ("There are no filter buttons for highscore menu");
				return;
			}

			if ( selected > _filterButtons.Count - 1 ) {
				Debug.LogError ("You have either selected a too large starting object or you have too few filter objects");
			}
			else {
				GameObject filterButton = _filterButtons[selected];
				HighscoreFilterButton highscoreFilterButton = filterButton.GetComponent<HighscoreFilterButton> ();
				highscoreFilterButton.Select ();

				Valid = true;
			}
		}

		void Update () {
			if ( !Valid )
				return;

			if ( Menu && MenuManager.instance.CurrentMenu == Menu ) {
				if ( Input.GetButtonDown (LeftButton) )
					SelectLeft ();
				else if ( Input.GetButtonDown (RightButton) )
					SelectRight ();
			}
		}

		public void SelectLeft () {
			if ( selected == 0 )
				return;

			_filterButtons[selected].GetComponent<HighscoreFilterButton> ().DeSelect ();
			_filterButtons[--selected].GetComponent<HighscoreFilterButton> ().Select ();

			HighscoreLoader.Instance.SelectFirstButton ();
		}

		public void SelectRight () {
			if ( selected == _filterButtons.Count - 1 )
				return;

			_filterButtons[selected].GetComponent<HighscoreFilterButton> ().DeSelect ();
			_filterButtons[++selected].GetComponent<HighscoreFilterButton> ().Select ();

			HighscoreLoader.Instance.SelectFirstButton ();
		}
	}
}