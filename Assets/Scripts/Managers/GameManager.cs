using UnityEngine;
using System.Collections;

namespace Tamarrion {
	[UnitySingleton(false, true)]
	public class GameManager : UnitySingleton<GameManager> {
		public string Version;

		public static string GetVersion() {
			return instance.Version;
		}
	}
}
