using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
    public class ComboHelpText : MonoBehaviour {
        public static ComboHelpText instance;
        public GameObject HelpText;
        public float HorizontalRange = 10;

        private Text StaticDescription;
        private bool StaticTextShown = false;

        void Awake() {
            instance = this;
            StaticDescription = transform.FindChild("StaticDescription").gameObject.GetComponent<Text>();
            StaticDescription.text = "";
        }

        void Update() {
            if (StaticTextShown && !GodManager.Instance.CurrentGod) {
                SetStaticText("", FSSkillElement.FS_Elem_Holy);
            }
        }

        public void SpawnText(string p_textString, FSSkillElement p_skillElement) {
            if (!HelpText)
                return;

            GameObject inst = (GameObject)Instantiate(HelpText, gameObject.transform.position + new Vector3(Random.Range(-HorizontalRange, HorizontalRange), 0, 0), Quaternion.identity);
            Text instText = inst.GetComponent<Text>();
            instText.text = p_textString;
			instText.color = SkillManager.GetElement (p_skillElement).Color;
            inst.transform.SetParent(gameObject.transform);
            inst.transform.localScale = new Vector3(1, 1, 1);
        }

        public void SetStaticText(string p_textString, FSSkillElement p_skillElement) {
            StaticTextShown = (p_textString != "");
            StaticDescription.text = p_textString;
			StaticDescription.color = SkillManager.GetElement (p_skillElement).Color;
        }

        public bool GetStaticTextShown() {
            return StaticTextShown;
        }
    }
}