using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
	public class DifficultyIndicator : MonoBehaviour {
		private RawImage[] images;

		void Start () {
			images = gameObject.GetComponentsInChildren<RawImage> ();
			images[(int)Difficulty.Current_difficulty].color = new Color (1, 1, 1, 1);
		}

		public void ChangeDifficulty () {
			for ( int i = 0; i < images.Length; i++ ) {
				images[i].color = new Color (1, 1, 1, 0);
			}
			images[(int)Difficulty.Current_difficulty].color = new Color (1, 1, 1, 1);
		}
	}
}
