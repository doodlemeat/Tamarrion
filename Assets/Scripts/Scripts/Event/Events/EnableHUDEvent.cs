using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamarrion {
	public class EnableHUDEvent : BaseEvent {
		public bool enabled;

		public EnableHUDEvent(bool enabled) {
			this.enabled = enabled;
		}
	}
}
