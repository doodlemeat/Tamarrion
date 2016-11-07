using System;
using MarkLight;

namespace Tamarrion {
	public class MessageBox : MyUIViewMonoBehavior {
		public _string Message;
		public Action YesAction;
		public Action NoAction;

		public override void Initialize () {
			base.Initialize ();
		}

		public override void BackgroundChanged () {
			base.BackgroundChanged ();

			if ( IsVisible.Value ) {
				RaycastBlockMode.Value = MarkLight.RaycastBlockMode.Always;
			} else {
				RaycastBlockMode.Value = MarkLight.RaycastBlockMode.Default;
			}
		}

		public void ClickYes() {
			if(YesAction != null) {
				YesAction ();
			}
			IsVisible.Value = false;
		}

		public void ClickNo() {
			if ( NoAction != null ) {
				NoAction ();
			}
			IsVisible.Value = false;
		}
	}
}
