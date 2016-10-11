using UnityEngine;
using UnityEngine.UI;
namespace Tamarrion {
	[RequireComponent (typeof (Image))]

	public class GodGlyphImageColor : MonoBehaviour {
		public FSSkillElement element;
		Image glyphImage;
		//bool godPowerActive = false;

		void Start () {
			glyphImage = GetComponent<Image> ();
			glyphImage.color = Color.white;

			GodManager.onTributeGain += OnTributeGain;
			GodManager.onGodChosen += OnGodChosen;
			//GodManager.onGodActivated += OnGodActivated;
			GodManager.onGodDeactivated += OnGodDeactivated;
		}

		void OnDisable () {
			GodManager.onTributeGain -= OnTributeGain;
			GodManager.onGodChosen -= OnGodChosen;
			GodManager.onGodDeactivated -= OnGodDeactivated;
		}

		//void Update()
		//{
		//    if (godPowerActive)
		//    {
		//        glyphImage.color = Color.Lerp(FSSkillManager.instance.GetColorByElement(element), Color.white, GodManager.Instance.GetPercentDone());
		//    }
		//}

		void OnTributeGain (FSSkillElement p_element, float p_amount) {
			if ( p_element == element ) {
				float percentage = GodManager.Instance.currentTributeAmounts[(int)p_element] / GodManager.Instance.maxTribute;
				if ( glyphImage )
					glyphImage.color = Color.Lerp (Color.white, FSSkillManager.instance.GetColorByElement (element), percentage);
			}
		}

		void OnGodChosen (FSSkillElement p_element) {
			if ( p_element != element && glyphImage )
				glyphImage.color = Color.white;
		}

		//void OnGodActivated(FSSkillElement p_element)
		//{
		//    if (p_element == element)
		//        godPowerActive = true;
		//}

		void OnGodDeactivated (FSSkillElement p_element) {
			if ( glyphImage )
				glyphImage.color = Color.white;
			//godPowerActive = false;
		}
	}
}