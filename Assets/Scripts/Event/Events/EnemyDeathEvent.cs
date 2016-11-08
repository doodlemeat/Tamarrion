namespace Tamarrion {
	public class EnemyDeathEvent : BaseEvent {
		public Enemy_Base enemy;

		public EnemyDeathEvent (Enemy_Base enemy) {
			this.enemy = enemy;
		}
	}
}
