using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
	public class SelectedHighscoreInfo : MonoBehaviour {
		public static SelectedHighscoreInfo Instance;
		Highscore _currentHighscore;
		Text _values;
		Text _name;

		void Awake() {
			_values = GetComponent<Text>();
			_name = transform.parent.FindChild("Header").GetComponent<Text>();
			Instance = this;
		}

		void Start() {
		}

		void Update() {

		}

		public void SetHighscore(Highscore highscore) {
			_currentHighscore = highscore;
			_values.text = "";
			_values.text += _currentHighscore.duration.ToString() + "\n";
			_values.text += System.Math.Round(_currentHighscore.damageDealt / _currentHighscore.duration, 2).ToString() + "\n";
			_values.text += _currentHighscore.damageTaken.ToString() + "\n";
			_values.text += _currentHighscore.healingDone.ToString() + "\n";

			_name.text = highscore.name;
		}
	}
}
