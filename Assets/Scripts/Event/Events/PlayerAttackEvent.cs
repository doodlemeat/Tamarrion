namespace Tamarrion
{
	public class PlayerAttackEvent : BaseEvent
	{
		public float damage;

		public PlayerAttackEvent(float damage)
		{
			this.damage = damage;
		}
	}
}
