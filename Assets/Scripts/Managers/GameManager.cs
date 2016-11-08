using UnityEngine;
using System.Collections;

namespace Tamarrion {
	[UnitySingleton(false, true)]
	public class GameManager : UnitySingleton<GameManager> {
		public string Version;

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
			Time.timeScale = 0;
		}

		void PauseStop() {
			Time.timeScale = 1;
		}

		public static string GetVersion() {
			return instance.Version;
		}
	}
}
