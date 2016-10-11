using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (CanvasGroup))]

	public class HPRect : MonoBehaviour {
		public float scaleDelay = 2;
		public float scaleTime = 1;
		public CombatStats Target;
		public bool deactivateIfTargetDies = true;

		public float CurrentPercent = 0;
		private float PreviousPercent = 0;
		private Text TextPercent = null;
		private Image HPBar = null;
		private Image RecentChangeBar = null;
		private Color RecentChangeBarVisibleColor;
		private Color RecentChangeBarInvisColor;
		public float scaleDelayCurrent = 0;
		public float scaleTimeCurrent = 0;

		[Header ("AlphaFade")]
		public bool FadeAlpha = false;
		public AnimationCurve FadeCurve = new AnimationCurve ();

		void Start () {
			PreviousPercent = CurrentPercent = 1;

			HPBar = transform.FindChild ("Bar_Color").gameObject.GetComponent<Image> ();

			if ( gameObject.transform.FindChild ("Text_Percent") )
				TextPercent = gameObject.transform.FindChild ("Text_Percent").GetComponent<Text> ();

			if ( gameObject.transform.FindChild ("Bar_RecentChange") ) {
				RecentChangeBar = gameObject.transform.FindChild ("Bar_RecentChange").GetComponent<Image> ();
				RecentChangeBarVisibleColor = new Color (RecentChangeBar.color.r, RecentChangeBar.color.g, RecentChangeBar.color.b, RecentChangeBar.color.a);
				RecentChangeBarInvisColor = new Color (RecentChangeBarVisibleColor.r, RecentChangeBarVisibleColor.g, RecentChangeBarVisibleColor.b, 0);
				RecentChangeBar.color = RecentChangeBarInvisColor;
			}

			if ( FadeAlpha )
				GetComponent<CanvasGroup> ().alpha = FadeCurve.Evaluate (1);
		}

		void Update () {
			if ( !Target )
				return;

			CurrentPercent = Target.GetPercentageHP ();

			if ( scaleDelayCurrent > 0 ) {
				scaleDelayCurrent -= Time.deltaTime;
				if ( scaleDelayCurrent <= 0 ) {
					scaleDelayCurrent = 0;
					scaleTimeCurrent = scaleTime;
				}
			}
			else if ( scaleTimeCurrent > 0 ) {
				scaleTimeCurrent -= Time.deltaTime;
				if ( scaleTimeCurrent <= 0 ) {
					scaleDelayCurrent = 0;
					RecentChangeBar.color = RecentChangeBarInvisColor;
				}
				RecentChangeBar.color = Color.Lerp (RecentChangeBarInvisColor, RecentChangeBarVisibleColor, scaleTimeCurrent / scaleTime);
			}
			//update percentage text
			if ( TextPercent )
				TextPercent.text = "" + (int)(((Target.GetStatValue ("health") + Target.GetStatValue ("shield")) / Target.GetStatValue ("max_health")) * 100) + " %";

			//check if change has occurred
			if ( CurrentPercent != PreviousPercent ) {
				//update HPBar fill
				HPBar.fillAmount = CurrentPercent;

				//update alpha
				if ( FadeAlpha )
					GetComponent<CanvasGroup> ().alpha = FadeCurve.Evaluate (CurrentPercent);


				//reset recent change
				//to-do(tomas): expand (instead of replace) changeRect if already existent
				{
					//scale
					if ( scaleDelayCurrent == 0 )
						RecentChangeBar.fillAmount = PreviousPercent;

					RecentChangeBar.color = RecentChangeBarVisibleColor;
					scaleDelayCurrent = scaleDelay;
				}

				//update previous percent
				PreviousPercent = CurrentPercent;
			}

			if ( deactivateIfTargetDies && Target.m_stat["health"] == 0 )
				gameObject.SetActive (false);
		}
	}
}