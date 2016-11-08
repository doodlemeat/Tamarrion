using System;

namespace Tamarrion {
	class MessageBoxEvent : BaseEvent {
		public string Message;
		public Action YesAction;
		public Action NoAction;
	}
}
