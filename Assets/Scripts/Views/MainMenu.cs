using UnityEngine;
using MarkLight.Views.UI;
using MarkLight;

namespace Tamarrion {
	public class MainMenu : MyUIViewMonoBehavior {
		public ViewSwitcher ContentViewSwitcher;
		public Region MainMenuRegion;

		public void Update () {
			if ( Input.GetKeyDown (KeyCode.Escape) ) {
				ToggleMenu ();
			}
		}

		void ToggleMenu () {
			if ( MainMenuRegion.IsVisible.Value ) {
				HideMenu ();
			}
			else {
				ShowMenu ();
			}
		}

		void HideMenu () {
			MainMenuRegion.IsVisible.Value = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Trigger (new EnableHUDEvent (true));
			Debug.Log ("Menu hide");
		}

		void ShowMenu () {
			MainMenuRegion.IsVisible.Value = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Trigger (new EnableHUDEvent(false));
			Debug.Log ("Menu show");
		}

		public void ClickMenu (Button button) {
			Trigger (new TriggerAudioEvent("menu_click"));
			HideMenu ();

			string submenu_id = button.Id + "_submenu";
			ContentViewSwitcher.SwitchTo (submenu_id);
		}

		public void MouseEnterMenuButton (Button button) {
			Image hoverImage = button.Parent.Find<Image> (button.Id + "_hover");
			if ( hoverImage ) {
				hoverImage.SetValue ("IsVisible", true);
				Trigger (new TriggerAudioEvent ("menu_hover"));
			}
		}

		public void MouseExitMenuButton (Button button) {
			Image hoverImage = button.Parent.Find<Image> (button.Id + "_hover");
			if ( hoverImage ) {
				hoverImage.SetValue ("IsVisible", false);
			}
		}
	}
}