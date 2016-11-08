namespace Tamarrion {
	public class PauseEvent : BaseEvent {
		public bool paused;

		public PauseEvent(bool paused) {
			this.paused = paused;
		}
	}
}
