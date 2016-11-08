using UnityEngine;
using System.Collections;

namespace Tamarrion {
	[UnitySingleton(false, true)]
	public class GameManager : UnitySingleton<GameManager> {
		public string Version;
		bool _Paused;

		public static bool Paused {
			get {
				return instance._Paused;
			}
		}

		protected override void OnAwake () {
			AddListener<IngameMenuOpenEvent> (OnIngameMenuOpen);
			AddListener<IngameMenuCloseEvent> (OnIngameMenuClose);
		}

		void OnDestroy() {
			RemoveListener<IngameMenuOpenEvent> (OnIngameMenuOpen);
			RemoveListener<IngameMenuCloseEvent> (OnIngameMenuClose);
		}

		void OnIngameMenuOpen (IngameMenuOpenEvent e) {
			PauseStart ();
		}

		void OnIngameMenuClose (IngameMenuCloseEvent e) {
			PauseStop ();
		}

		void PauseStart() {
			_Paused = true;
			Time.timeScale = 0;
		}

		void PauseStop() {
			_Paused = false;
			Time.timeScale = 1;
		}

		public static string GetVersion() {
			return instance.Version;
		}
	}
}
