using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class ItemEquipEvent : BaseEvent {
		public BaseItem item;

		public ItemEquipEvent(BaseItem item) {
			this.item = item;
		}
	}
}