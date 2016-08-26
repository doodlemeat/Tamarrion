using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamarrion {
	public class UIEvent : BaseEvent {
		public enum TYPE {
			CLICK,
			HOVER
		};

		public TYPE type;

		public UIEvent(TYPE type) {
			this.type = type;
		}
	}
}
