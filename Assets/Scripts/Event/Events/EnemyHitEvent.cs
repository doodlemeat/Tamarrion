namespace Tamarrion
{
	public class EnemyHitEvent : BaseEvent
	{
		public float damage;

		public EnemyHitEvent(float damage)
		{
			this.damage = damage;
		}
	}
}
