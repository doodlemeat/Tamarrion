namespace Tamarrion {
	public class TributeChangeEvent : BaseEvent {
		public float newAmount;
		public float changedAmount;
		public float percentageDone;
		public FSSkillElement element;

		public TributeChangeEvent() { }
	}
}
