using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
    public class SpellSelector : MonoBehaviour {
        public static SpellSelector instance;
        private GameObject SelectedSpell;
        private Text TextName = null;
        private Text TextDescription = null;

        private RawImage iconImage;

        void Awake() {
            instance = this;
        }

        void Start() {
            iconImage = transform.FindChild("Icon").gameObject.GetComponent<RawImage>();

            TextName = transform.FindChild("Name").gameObject.GetComponent<Text>();
            TextDescription = transform.FindChild("Description").gameObject.GetComponent<Text>();

            TextName.text = "";
            TextDescription.text = "";
            TextName.color = new Color(TextName.color.r, TextName.color.g, TextName.color.b, 0);
            TextDescription.color = new Color(TextDescription.color.r, TextDescription.color.g, TextDescription.color.b, 0);
            if (iconImage)
                iconImage.color = new Color(1, 1, 1, 0);
        }

        public void SelectSpell(GameObject p_spell) {
            SelectedSpell = p_spell;
            if (!SelectedSpell) {
                TextName.text = "";
                TextDescription.text = "";
                TextName.color = new Color(TextName.color.r, TextName.color.g, TextName.color.b, 0);
                TextDescription.color = new Color(TextDescription.color.r, TextDescription.color.g, TextDescription.color.b, 0);
                if (iconImage)
                    iconImage.color = new Color(1, 1, 1, 0);
            }
            else {
                SpellBase spellBase = SelectedSpell.GetComponent<SpellBase>();

                if (iconImage) {
                    iconImage.texture = spellBase._spellIconMenu;
                    iconImage.color = new Color(1, 1, 1, 1);
                }

                TextName.text = spellBase._Name;
                TextDescription.text = spellBase._description;
                TextName.color = new Color(TextName.color.r, TextName.color.g, TextName.color.b, 1);
                TextDescription.color = new Color(TextDescription.color.r, TextDescription.color.g, TextDescription.color.b, 1);
            }
        }

        public GameObject GetSelected() {
            return SelectedSpell;
        }
    }
}