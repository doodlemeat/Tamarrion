using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
namespace Tamarrion {
	public class HudPopupManager : MonoBehaviour {
		public static HudPopupManager instance;

		public class PopupInfo {
			public string Title;
			public string Content;
			public float Time = 2;
		}

		public List<PopupInfo> popupQueue = new List<PopupInfo> ();
		PopupInfo currentPopup;
		public float betweenPopupsTime = 0.5f;
		public GameObject popupObject;
		public Text popupTitle;
		public Text popupContent;
		TopgunTimer popupTimer = new TopgunTimer ();
		TopgunTimer betweenPopupsTimer = new TopgunTimer ();
		CanvasGroupController canvasGroupController;

		enum PopupState {
			Inactive,
			Active,
			BetweenPopups,
		}

		PopupState state = PopupState.Inactive;

		void Awake () {
			instance = this;
		}

		void Start () {
			canvasGroupController = popupObject.GetComponent<CanvasGroupController> ();
			canvasGroupController.Hide ();
		}

		void Update () {
			if ( state == PopupState.Inactive ) {
				if ( !QueueIsEmpty () ) {
					ActivateNextPopup ();
					RemoveFirstPopupFromQueue ();
				}
			}
			else if ( state == PopupState.Active ) {
				popupTimer.Update ();
				if ( popupTimer.IsComplete ) {
					DeactivateCurrentPopup ();
				}
			}
			else if ( state == PopupState.BetweenPopups ) {
				betweenPopupsTimer.Update ();
				if ( betweenPopupsTimer.IsComplete ) {
					state = PopupState.Inactive;
				}
			}
		}

		public void AddPopupToQueue (PopupInfo p_info) {
			popupQueue.Add (p_info);
		}

		bool QueueIsEmpty () {
			return (popupQueue.Count == 0);
		}

		void ActivateNextPopup () {
			currentPopup = popupQueue[0];
			state = PopupState.Active;
			popupTimer.StartTimerBySeconds (currentPopup.Time);

			if ( popupObject )
				canvasGroupController.Show (2f);
			if ( popupTitle )
				popupTitle.text = currentPopup.Title;
			if ( popupContent )
				popupContent.text = currentPopup.Content;
		}

		void DeactivateCurrentPopup () {
			if ( QueueIsEmpty () )
				state = PopupState.Inactive;
			else
				StartPauseBetweenPopups ();

			if ( popupObject )
				canvasGroupController.Hide (0.5f);
		}

		void StartPauseBetweenPopups () {
			state = PopupState.BetweenPopups;
			betweenPopupsTimer.StartTimerBySeconds (betweenPopupsTime);
		}

		void RemoveFirstPopupFromQueue () {
			popupQueue.RemoveAt (0);
		}
	}
}