using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
	public class HighscoreScrollbar : MonoBehaviour {
		public static HighscoreScrollbar Instance;

		public Scrollbar _scrollbar;

		void Awake() {
			Instance = this;
			_scrollbar = GetComponent<Scrollbar>();
		}
	}
}
