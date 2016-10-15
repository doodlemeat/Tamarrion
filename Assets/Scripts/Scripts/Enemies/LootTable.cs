using System.Collections.Generic;
using UnityEngine;

/*
	LootTable is a component that defines what items the player will be rewarded with when an entity dies.
	The Lootmanager must be present in the scene for this to have effect.
*/

namespace Tamarrion {
	public class LootTable : MyMonoBehaviour {
		[SerializeField]
		List<LootItem> lootItems = new List<LootItem> ();

		List<LootTableItem> lootTableItems = new List<LootTableItem>();
		float sumChances = 0;

		void Awake() {
			foreach( LootItem item in lootItems) {
				if ( item.item ) {
					lootTableItems.Add(new LootTableItem(item.chance, item));
					sumChances += item.chance;
				}
			}
		}

		public BaseItem GetRandomItem() {
			float chance = Random.Range (0, sumChances);

			foreach(LootTableItem itemChance in lootTableItems ) {
				if(chance <= itemChance.chance) {
					return itemChance.item.item;
				}
			}

			return null;
		}
	}

	class LootTableItem {
		public float chance;
		public LootItem item;

		public LootTableItem(float chance, LootItem item) {
			this.chance = chance;
			this.item = item;
		}
	}
}
