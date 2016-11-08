namespace Tamarrion {
	public class InventoryItemFilterChangeEvent : BaseEvent {
		public int filter;

		public InventoryItemFilterChangeEvent(int filter) {
			this.filter = filter;
		}
	}
}
