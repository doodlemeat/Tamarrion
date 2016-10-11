using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	public class ErrorTextFadeOut : MonoBehaviour {
		public float BaseFadeDelay = 1;
		public float FadeTime = 1;
		public float VerticalSpeed = 1;

		private float FadeDelayCurrent = 1;
		private float FadeTimeCurrent = 1;
		private Text text;
		private Color StartColor;
		private Color EndColor;

		void Start () {
			FadeTimeCurrent = FadeTime;
			FadeDelayCurrent = BaseFadeDelay;
			text = gameObject.GetComponent<Text> ();

			StartColor = text.color;
			EndColor = new Color (text.color.r, text.color.g, text.color.b, 0);
		}

		void Update () {
			//vertical move
			transform.position += Vector3.down * VerticalSpeed * Time.deltaTime;

			//räkna ner base fade delay
			if ( FadeDelayCurrent > 0 )
				FadeDelayCurrent -= Time.deltaTime;
			else {
				//fade out
				FadeTimeCurrent -= Time.deltaTime;
				if ( FadeTimeCurrent > 0 ) {
					if ( FadeTimeCurrent < 0 )
						FadeTimeCurrent = 0;

					text.color = Color.Lerp (EndColor, StartColor, FadeTimeCurrent / FadeTime);
				}
				else
					Destroy (gameObject);
			}
		}
	}
}