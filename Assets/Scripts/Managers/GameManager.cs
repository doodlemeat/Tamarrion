using UnityEngine;
using System.Collections;

namespace Tamarrion {
	[UnitySingleton(false, true)]
	public class GameManager : UnitySingleton<GameManager> {
		public string Version;
		private bool paused;

		public static bool Paused {
			get {
				return instance.paused;
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
			paused = true;
			Time.timeScale = 0;
		}

		void PauseStop() {
			paused = false;
			Time.timeScale = 1;
		}

		public static string GetVersion() {
			return instance.Version;
		}
	}
}
