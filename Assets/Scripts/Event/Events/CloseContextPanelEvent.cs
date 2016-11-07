using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamarrion {
	public class CloseContextPanelEvent : BaseEvent {
		public ContextPanel panel;

		public CloseContextPanelEvent (ContextPanel panel) {
			this.panel = panel;
		}
	}
}
