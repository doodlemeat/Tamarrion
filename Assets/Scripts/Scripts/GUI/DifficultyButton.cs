using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace Tamarrion {
	public class DifficultyButton : MonoBehaviour, ISelectHandler {
		public Difficulty DifficultySetting = Difficulty.Beginner;

		void Start () {
			GetComponent<UnityEngine.UI.Button> ().onClick.AddListener (() => { OnClick (); });
		}

		void OnClick () {
			DifficultyManager.current = DifficultySetting;
		}

		public void OnSelect (UnityEngine.EventSystems.BaseEventData data) {
			UpdateDifficultySetting ();
		}

		public void OnMouseEnter () {
			UpdateDifficultySetting ();
		}

		void UpdateDifficultySetting () {
			if ( DifficultyMarker.instance )
				DifficultyMarker.instance.SetDifficultyTexture (DifficultySetting);
		}
	}
}