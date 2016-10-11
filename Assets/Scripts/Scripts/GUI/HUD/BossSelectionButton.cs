using UnityEngine;
using UnityEngine.UI;
namespace Tamarrion {
	[RequireComponent (typeof (Button))]

	public class BossSelectionButton : MonoBehaviour {
		public string progressionString = "";
		public string BossTitle = "";
		public string BossDescription = "";
		Button button;

		void Awake () {
			button = GetComponent<Button> ();
			button.onClick.AddListener (() => { OnClick (); });
		}

		void OnClick () {
			if ( !MainMenuBossInfo.instance || !Player.player )
				return;

			MainMenuBossInfo.instance.SetTitleText (BossTitle);
			MainMenuBossInfo.instance.SetDescriptionText (BossDescription);
			Player.player.progressStateName = progressionString;
		}
	}
}
