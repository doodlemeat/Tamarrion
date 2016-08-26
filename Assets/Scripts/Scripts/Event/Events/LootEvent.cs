namespace Tamarrion {
	public class LootEvent : BaseEvent {
		public BaseItem item;

		public LootEvent(BaseItem item) {
			this.item = item;
		}
	}
}
