using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamarrion {
	public class ChangeContextPanelEvent : BaseEvent {
		public string id;

		public ChangeContextPanelEvent(string id) {
			this.id = id;
		}
	}
}
