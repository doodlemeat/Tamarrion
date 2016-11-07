using MarkLight;

namespace Tamarrion {
	public class MainMenuScene : MyViewMonoBehavior {
		public MessageBox MessageBox;

		void Awake() {
			AddListener<AlertEvent> (OnAlertEvent);
			AddListener<MessageBoxEvent> (OnMessageBoxEvent);
		}

		void OnDestroy() {
			RemoveListener<AlertEvent> (OnAlertEvent);
			RemoveListener<MessageBoxEvent> (OnMessageBoxEvent);
		}

		void OnAlertEvent(AlertEvent e) {
			this.ForEachChild<Alert> (c => {
				c.IsVisible.Value = true;
				c.Message.Value = e.Message;
			});
		}

		void OnMessageBoxEvent(MessageBoxEvent e) {
			this.ForEachChild<MessageBox> (c => {
				c.IsVisible.Value = true;
				c.YesAction = e.YesAction;
				c.NoAction = e.NoAction;
				c.Message.Value = e.Message;
			});
		}
	}
}
