namespace Tamarrion {
	public class UIController : MyMonoBehaviour {
		void Awake() {
			AddListener<UIEvent> (OnUIEvent);
		}

		void OnDestroy() {
			RemoveListener<UIEvent> (OnUIEvent);
		}

		void OnUIEvent(UIEvent e) {
			switch(e.type) {
			case UIEvent.TYPE.CLICK:
				Trigger (new TriggerAudioEvent("menu_click"));
				break;
			case UIEvent.TYPE.HOVER:
				Trigger (new TriggerAudioEvent("menu_hover"));
				break;
			}
		}

		public void OnHover() {
			Trigger (new UIEvent(UIEvent.TYPE.HOVER));
		}

		public void OnClick () {
			Trigger (new UIEvent (UIEvent.TYPE.CLICK));
		}
	}
}
