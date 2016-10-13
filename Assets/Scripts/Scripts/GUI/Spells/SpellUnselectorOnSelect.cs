using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Tamarrion {
    public class SpellUnselectorOnSelect : MonoBehaviour, ISelectHandler {

        public void OnSelect(UnityEngine.EventSystems.BaseEventData data) {
            if (SpellSelector.instance)
                SpellSelector.instance.SelectSpell(null);
        }
    }
}