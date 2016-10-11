using UnityEngine;
using System.Collections;
using Tamarrion;
namespace Tamarrion {
	public class HUDController : MyMonoBehaviour {
		public bool enabledFromStart = true;
		bool hudEnabled = true;
		public static HUDController hudController = null;
		public GameObject StatsScreen = null;

		void Awake () {
			hudController = this;
			AddListener<EnableHUDEvent> (OnEnableHUD);
		}

		void OnDestroy () {
			RemoveListener<EnableHUDEvent> (OnEnableHUD);
		}

		void OnEnableHUD (EnableHUDEvent e) {
			if ( e.enabled ) {
				EnableHUD ();
			}
			else {
				DisableHUD ();
			}
		}

		void Start () {
			if ( enabledFromStart == false )
				DisableHUD ();
		}

		public void ShowStatsScreen (bool p_victory) {
			if ( StatsScreen == null )
				return;

			MouseHider.instance.SetForceShow (true);
			StatsScreen.SetActive (true);
			StatsScreen.GetComponent<FightStatsScreen> ().SetVictory (p_victory);
		}

		public void DisableHUD () {
			hudEnabled = false;
			GetComponent<Canvas> ().enabled = false;
			GetComponent<UnityEngine.UI.GraphicRaycaster> ().enabled = false;
		}

		public void EnableHUD () {
			hudEnabled = true;
			GetComponent<Canvas> ().enabled = true;
			GetComponent<UnityEngine.UI.GraphicRaycaster> ().enabled = true;
		}

		public bool GetHudEnabled () {
			return hudEnabled;
		}
	}
}