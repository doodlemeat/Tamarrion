using UnityEngine;

namespace Tamarrion {
	[UnitySingleton (false, true)]
	public class LootManager : UnitySingleton<LootManager> {
		protected override void OnAwake () {
			AddListener<EnemyDeathEvent> (OnEnemyDeath);
		}

		void OnDestroy() {
			RemoveListener<EnemyDeathEvent> (OnEnemyDeath);
		}

		void OnEnemyDeath(EnemyDeathEvent e) {
			LootTable lootTable = e.enemy.GetComponent<LootTable> ();
			if(lootTable == null) {
				return;
			}

			BaseItem item = lootTable.GetRandomItem ();
			if(InventoryManager.inventoryManager) {
				if ( InventoryManager.IsItemLocked (item) ) {
					Trigger (new LootEvent(item));
				}
			}
		}

		void Update() {
			if(Input.GetKeyDown(KeyCode.F)) {
				Trigger (new LootEvent (null));
			}
		}
	}
}
