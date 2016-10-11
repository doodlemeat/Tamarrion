using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	public class ComboHelpText : MonoBehaviour {
		public static ComboHelpText instance;
		public GameObject HelpText;
		public float HorizontalRange = 10;
		public FSSkillManager skillManager;

		private Text StaticDescription;
		private bool StaticTextShown = false;

		void Awake () {
			instance = this;
			StaticDescription = transform.FindChild ("StaticDescription").gameObject.GetComponent<Text> ();
			StaticDescription.text = "";
		}

		void Update () {
			if ( StaticTextShown && !GodManager.Instance.CurrentGod ) {
				SetStaticText ("", FSSkillElement.FS_Elem_Holy);
			}
		}

		public void SpawnText (string p_textString, FSSkillElement p_skillElement) {
			if ( !HelpText )
				return;

			GameObject inst = (GameObject)Instantiate (HelpText, gameObject.transform.position + new Vector3 (Random.Range (-HorizontalRange, HorizontalRange), 0, 0), Quaternion.identity);
			Text instText = inst.GetComponent<Text> ();
			instText.text = p_textString;

			if ( skillManager ) {
				if ( p_skillElement == FSSkillElement.FS_Elem_Holy )
					instText.color = skillManager.ColorHoly;
				else if ( p_skillElement == FSSkillElement.FS_Elem_Nature )
					instText.color = skillManager.ColorNature;
				else if ( p_skillElement == FSSkillElement.FS_Elem_War )
					instText.color = skillManager.ColorWar;
				else if ( p_skillElement == FSSkillElement.FS_Elem_Magic )
					instText.color = skillManager.ColorMagic;
				else if ( p_skillElement == FSSkillElement.FS_Elem_Defense )
					instText.color = skillManager.ColorDefense;
			}

			//RectTransform rectTrans = inst.GetComponent<RectTransform>();
			//Debug.Log("size before: " + inst.GetComponent<RectTransform>().sizeDelta);
			//inst.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().left, rectTrans.sizeDelta.y);
			inst.transform.SetParent (gameObject.transform);
			inst.transform.localScale = new Vector3 (1, 1, 1);
			//Debug.Log("size after: " + inst.GetComponent<RectTransform>().sizeDelta);
			//Debug.Log("scale: " + inst.transform.localScale);
			//Debug.Log("fontsize: " + instText.fontSize);
		}

		public void SetStaticText (string p_textString, FSSkillElement p_skillElement) {
			StaticTextShown = (p_textString != "");
			StaticDescription.text = p_textString;

			if ( StaticTextShown && skillManager ) {
				if ( p_skillElement == FSSkillElement.FS_Elem_Holy )
					StaticDescription.color = skillManager.ColorHoly;
				else if ( p_skillElement == FSSkillElement.FS_Elem_Nature )
					StaticDescription.color = skillManager.ColorNature;
				else if ( p_skillElement == FSSkillElement.FS_Elem_War )
					StaticDescription.color = skillManager.ColorWar;
				else if ( p_skillElement == FSSkillElement.FS_Elem_Magic )
					StaticDescription.color = skillManager.ColorMagic;
				else if ( p_skillElement == FSSkillElement.FS_Elem_Defense )
					StaticDescription.color = skillManager.ColorDefense;
			}
		}

		public bool GetStaticTextShown () {
			return StaticTextShown;
		}
	}
}