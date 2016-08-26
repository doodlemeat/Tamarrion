using UnityEngine;

namespace Tamarrion {
	public class InGameMenu : MyMonoBehaviour {
		Canvas canvas;
		bool contextEnabled;

		[SerializeField]
		bool startEnabled;

		void Awake () {
			canvas = GetComponent<Canvas> ();
			contextEnabled = false;

//			if ( startEnabled && !canvas.enabled ) {
//				Show ();
//			}
//			else if ( !startEnabled && canvas.enabled ) {
//				Hide ();
//			}

			AddListener<ChangeContextPanelEvent> (OnChangeContextPanel);
			AddListener<CloseContextPanelEvent> (OnCloseContextPanel);
		}

		void OnDestroy() {
			RemoveListener<ChangeContextPanelEvent> (OnChangeContextPanel);
			RemoveListener<CloseContextPanelEvent> (OnCloseContextPanel);
		}

		void OnChangeContextPanel(ChangeContextPanelEvent e) {
			contextEnabled = true;
		}

		void OnCloseContextPanel(CloseContextPanelEvent e) {
			contextEnabled = false;
		}

		void Update () {
			if ( Input.GetKeyDown (KeyCode.Escape) && !contextEnabled) {
				if ( canvas.enabled ) {
					Trigger (new EnableHUDEvent(true));
					PauseMenu.instance.ToggleActivation ();
					Hide ();
				}
				else {
					Trigger (new EnableHUDEvent (false));
					PauseMenu.instance.ToggleActivation ();
					Show ();
				}
			}
		}

		void Hide () {
			canvas.enabled = false;
			MouseHider.instance.SetForceShow(false);
		}

		void Show () {
			canvas.enabled = true;
			MouseHider.instance.SetForceShow(true);
			Cursor.lockState = CursorLockMode.None;
		}

		public void Close() {
			Trigger (new EnableHUDEvent (true));
			PauseMenu.instance.ToggleActivation ();
			Hide ();
		}
	}
}