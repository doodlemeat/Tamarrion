using UnityEngine;
using UnityEngine.UI;
namespace Tamarrion {
	[RequireComponent (typeof (Text))]

	public class TextColorPulse : MonoBehaviour {
		public AnimationCurve pulseCurve = new AnimationCurve ();
		public float pulseSpeedInSeconds = 1f;
		public Color firstColor = Color.white;
		public Color secondColor = Color.white;

		Text targetText;
		Timer pulseTimer = new Timer();

		void Start () {
			RestartTimer ();

			targetText = GetComponent<Text> ();
			if ( !targetText )
				this.enabled = false;
		}

		void RestartTimer () {
			pulseTimer.Start(pulseSpeedInSeconds);
		}

		void Update () {
			pulseTimer.Update ();
			if ( pulseTimer.IsFinished ) {
				RestartTimer ();
			}
			targetText.color = Color.Lerp (firstColor, secondColor, pulseCurve.Evaluate (1-pulseTimer.Progress()));
		}
	}
}