using UnityEngine;
using System;
using System.Collections;
namespace Tamarrion {
	public class BaseItem : MonoBehaviour, IComparable {
		public enum EItemType {
			Generic,
			Ring,
			Amulet,
			Weapon,
			Token,
			Count,
		}

		public enum EItemRarity {
			Common,
			Uncommon,
			Rare,
			Mythical,
		}

		public string itemName = "";
		public string itemDescription = "";
		public EItemType type = EItemType.Ring;
		public EItemRarity rarity = EItemRarity.Common;
		public int Rating = 0;
		public bool Available = true;
		public Texture2D itemIcon = null;

		public int CompareTo (object obj) {
			if ( obj == null ) return 1;

			BaseItem other = obj as BaseItem;

			if ( other.rarity > rarity ) {
				return 1;
			}
			else if ( other.rarity < rarity ) {
				return -1;
			}

			return 0;
		}
	}
}