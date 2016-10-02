namespace Tamarrion {
	public class GodPowerPointChangeEvent : BaseEvent {
		public float newAmount;
		public float changedAmount;
		public float percentageDone;
		public FSSkillElement element;

		public GodPowerPointChangeEvent() { }
	}
}
