using UnityEngine;
using System.Collections;
using MarkLight.Views.UI;
using MarkLight.Views;
using MarkLight;

namespace Tamarrion {
	public class MainMenu : MyViewMonoBehavior {
		public ViewSwitcher ContentViewSwitcher;

		public void ClickMenu(Button button) {
			Trigger (new TriggerAudioEvent("menu_click"));

			string submenu_id = button.Id + "_submenu";
			ContentViewSwitcher.SwitchTo(submenu_id);
		}

		public void MouseEnterMenuButton (Button button) {
			Image hoverImage = button.Parent.Find<Image> (button.Id + "_hover");
			if ( hoverImage ) {
				hoverImage.SetValue ("IsVisible", true);
				Trigger (new TriggerAudioEvent ("menu_hover"));
			}
		}

		public void MouseExitMenuButton(Button button) {
			Image hoverImage = button.Parent.Find<Image> (button.Id + "_hover");
			if ( hoverImage ) {
				hoverImage.SetValue ("IsVisible", false);
			}
		}
	}
}