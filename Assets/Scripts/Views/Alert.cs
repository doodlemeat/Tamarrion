using System;
using MarkLight;

namespace Tamarrion {
	public class Alert : MyUIViewMonoBehavior {
		public _string Message;

		public override void Initialize () {
			base.Initialize ();
		}

		public override void BackgroundChanged () {
			base.BackgroundChanged ();

			if ( IsVisible.Value ) {
				RaycastBlockMode.Value = MarkLight.RaycastBlockMode.Always;
			}
			else {
				RaycastBlockMode.Value = MarkLight.RaycastBlockMode.Default;
			}
		}

		public void Click () {
			IsVisible.Value = false;
		}
	}
}
