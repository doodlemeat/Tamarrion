using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Image))]
	public class ComboIcon : MyMonoBehaviour {
		public FSSkillElement godElement;
		public float lerpTime = 0.3f;
		Image iconImage;
		bool godPowerActive = false;
		float lerpStart = 0, lerpTarget = 0;
		bool lerpOn = false;
		TopgunTimer lerpTimer = new TopgunTimer ();

		//add event:
		//- when god is chosen
		//- when god is disabled
		//- when tribute is gained

		void Start () {
			iconImage = GetComponent<Image> ();
			iconImage.color = FSSkillManager.instance.GetColorByElement (godElement);

			GodManager.onTributeGain += OnTributeGain;
			GodManager.onGodChosen += OnGodChosen;
			GodManager.onGodActivated += OnGodActivated;
			GodManager.onGodDeactivated += OnGodDeactivated;

			AddListener<TributeChangeEvent> (OnGodPowerPointChange);

			SetImageFill (0f);
		}

		void OnDisable () {
			GodManager.onTributeGain -= OnTributeGain;
			GodManager.onGodChosen -= OnGodChosen;
			GodManager.onGodActivated -= OnGodActivated;
			GodManager.onGodDeactivated -= OnGodDeactivated;
		}

		void OnDestroy () {
			RemoveListener<TributeChangeEvent> (OnGodPowerPointChange);
		}

		void Update () {
			if ( godPowerActive ) {
				SetImageFill (GodManager.Instance.GetPercentDone ());
			}
			else if ( lerpOn ) {
				lerpTimer.Update ();
				SetImageFill (Mathf.Lerp (lerpStart, lerpTarget, (1 - lerpTimer.PercentComplete ())));
				if ( lerpTimer.IsComplete ) {
					lerpOn = false;
				}
			}
		}

		void OnTributeGain (FSSkillElement p_element, float p_amount) {
			if ( p_element != godElement )
				return;

			float percentage = GodManager.Instance.currentTributeAmounts[(int)p_element] / GodManager.Instance.maxTribute;

			if ( iconImage )
				lerpStart = iconImage.fillAmount;

			lerpTarget = percentage;
			lerpOn = true;
			lerpTimer.StartTimerBySeconds (lerpTime);
			//SetImageFill(percentage);
		}

		void OnGodPowerPointChange (TributeChangeEvent e) {
			if ( e.element != godElement )
				return;

			lerpStart = iconImage.fillAmount;
			lerpTarget = e.percentageDone;
			lerpOn = true;
			lerpTimer.StartTimerBySeconds (lerpTime);
		}

		void SetImageFill (float p_percentage) {
			if ( iconImage )
				iconImage.fillAmount = p_percentage;
		}

		void OnGodChosen (FSSkillElement p_element) {
			if ( p_element != godElement )
				iconImage.color = Color.white;

			lerpOn = false;
		}

		void OnGodActivated (FSSkillElement p_element) {
			if ( p_element == godElement )
				godPowerActive = true;
			else
				SetImageFill (0f);

			lerpOn = false;
		}

		void OnGodDeactivated (FSSkillElement p_element) {
			if ( iconImage )
				iconImage.color = FSSkillManager.instance.GetColorByElement (godElement);

			SetImageFill (0f);
			godPowerActive = false;
		}
	}
}