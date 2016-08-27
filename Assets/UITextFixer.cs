using UnityEngine.UI;

namespace Tamarrion {
	public class UITextFixer : MyMonoBehaviour {
		void Awake () {
			AddListener<EnableHUDEvent> (OnEnableHud);
		}

		void OnDestroy() {
			RemoveListener<EnableHUDEvent> (OnEnableHud);
		}
		
		void OnEnableHud(EnableHUDEvent e) {
			Text[] texts = GetComponentsInChildren<Text> ();
			foreach ( Text text in texts ) {
				text.SetAllDirty ();
			}
		}
	}
}