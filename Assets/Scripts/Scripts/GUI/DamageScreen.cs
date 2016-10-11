using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	public class DamageScreen : MonoBehaviour {
		public static DamageScreen instance;
		public float FadeTime = 0.2f;
		public float VisibleAlpha = 1;

		private bool Active = false;
		private float FadeTimeCurrent = 0.2f;
		private Color Invisible;
		private Color Visible;
		private RawImage image;

		void Awake () {
			instance = this;
		}

		void Start () {
			image = GetComponent<UnityEngine.UI.RawImage> ();
			Visible = new Color (image.color.r, image.color.g, image.color.b, VisibleAlpha);
			Invisible = new Color (image.color.r, image.color.g, image.color.b, 0);

			image.color = Invisible;
		}

		void Update () {
			if ( Active ) {
				FadeTimeCurrent -= Time.deltaTime;
				if ( FadeTimeCurrent <= 0 ) {
					FadeTimeCurrent = 0;
					Active = false;
				}
				image.color = Color.Lerp (Invisible, Visible, (FadeTimeCurrent / FadeTime));
			}
		}

		public void StartFade () {
			Active = true;
			FadeTimeCurrent = FadeTime;
		}
	}
}