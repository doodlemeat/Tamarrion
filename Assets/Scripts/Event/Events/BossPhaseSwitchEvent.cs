namespace Tamarrion {
	public class BossPhaseSwitchEvent : BaseEvent {
		public int newPhase;
		public Enemy_Base boss;

		public BossPhaseSwitchEvent (int newPhase, Enemy_Base boss) {
			this.newPhase = newPhase;
			this.boss = boss;
		}
	}
}

