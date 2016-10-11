using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	public class CanvasVisibleIfComboPoints : MonoBehaviour {
		public float FadeTime = 1;
		private float FadeTimeCurrent = 0;
		private bool Active = false;
		private CanvasGroup canvasGroup;

		void Start () {
			canvasGroup = GetComponent<CanvasGroup> ();
			canvasGroup.alpha = 0;
			FadeTimeCurrent = 0;
		}

		void Update () {
			if ( FadeTimeCurrent > 0 ) {
				FadeTimeCurrent -= Time.deltaTime;
				if ( Active )
					canvasGroup.alpha = 1 - (FadeTimeCurrent / FadeTime);
				else if ( !Active )
					canvasGroup.alpha = FadeTimeCurrent / FadeTime;
			}
		}
	}
}