using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Tamarrion {
	public class ItemInfo : MonoBehaviour {
		public static ItemInfo itemInfo = null;
		private InventoryManager InvManager = null;
		private GameObject targetitem = null;

		public Color RarityCommon = new Color (1, 1, 1, 1);
		public Color RarityUncommon = new Color (1, 1, 1, 1);
		public Color RarityRare = new Color (1, 1, 1, 1);
		public Color RarityMythical = new Color (1, 1, 1, 1);

		void Awake () {
			itemInfo = this;
		}

		void Start () {
			UpdateToSelected ();
		}

		void Update () {
			if ( !InvManager ) {
				GameObject player = Player.player.gameObject;
				if ( player ) {
					InvManager = player.GetComponentInChildren<InventoryManager> ();
					UpdateToSelected ();
				}
				else
					return;
			}

			if ( InvManager.SelectedItem != -1 && (!targetitem || InvManager.AvailableItems[InvManager.SelectedItem] != targetitem) ) {
				targetitem = InvManager.AvailableItems[InvManager.SelectedItem];
				UpdateToSelected ();
			}
			else if ( InvManager.SelectedItem == -1 && targetitem ) {
				targetitem = null;
				UpdateToSelected ();
			}
		}

		public void UpdateToSelected () {
			if ( !InvManager )
				return;

			if ( InvManager.SelectedItem != -1 ) {
				StatsItem item = InvManager.AvailableItems[InvManager.SelectedItem].GetComponent<StatsItem> ();

				Text xName = gameObject.transform.FindChild ("Name").GetComponent<Text> ();
				Text xType = gameObject.transform.FindChild ("RarityAndType").GetComponent<Text> ();
				Text xDescription = gameObject.transform.FindChild ("Description").GetComponent<Text> ();
				Text xStatNames = gameObject.transform.FindChild ("StatNames").GetComponent<Text> ();
				Text xStats = gameObject.transform.FindChild ("Stats").GetComponent<Text> ();
				Text xStatsCompareRed = gameObject.transform.FindChild ("StatsCompareRed").GetComponent<Text> ();
				Text xStatsCompareGreen = gameObject.transform.FindChild ("StatsCompareGreen").GetComponent<Text> ();

				//GameObject compareItem = null;
				//if (InvManager.equipped[(int)InventoryManager.ItemTypeToInvType(item.GetComponent<BaseItem>().type)] != -1)
				//compareItem = InvManager.AvailableItems[InvManager.SelectedItem];

				//StatsItem compareItemScript = null;
				//if (compareItem)
				//  compareItemScript = compareItem.GetComponent<StatsItem>();

				//Name
				xName.text = item.itemName;

				//Rarity & Type
				xType.text = item.rarity.ToString () + " " + item.type.ToString ();
				if ( item.rarity == BaseItem.EItemRarity.Common )
					xType.color = RarityCommon;
				else if ( item.rarity == BaseItem.EItemRarity.Uncommon )
					xType.color = RarityUncommon;
				else if ( item.rarity == BaseItem.EItemRarity.Rare )
					xType.color = RarityRare;
				else if ( item.rarity == BaseItem.EItemRarity.Mythical )
					xType.color = RarityMythical;

				//Description
				xDescription.text = item.itemDescription;

				//Statnames
				xStatNames.text = "Health:\nDamage reduction:\nBase damage:\nPhysical damage:\nMagical damage:\nCrit chance:\nMultistrike\nMovement speed:";

				//Stats
				if ( item.type != BaseItem.EItemType.Token ) {
					xStats.text = "";
					for ( int i = 0; i < (int)StatsItem.EStatType.Count; ++i ) {
						if ( i == (int)StatsItem.EStatType.Armor
							|| i == (int)StatsItem.EStatType.CritDamage
							|| i == (int)StatsItem.EStatType.Cooldown )
							continue;
						if ( item.stats[i].value > 0 ) {
							if ( item.stats[i].percentage )
								xStats.text += "+" + (item.stats[i].value * 100) + "%";
							else
								xStats.text += "+" + item.stats[i].value;
						}
						xStats.text += "\n";
					}
				}
				else {
					xStatNames.text = "";
					xStats.text = "";
					xStatsCompareRed.text = "";
					xStatsCompareGreen.text = "";
				}

				if ( item.itemIcon ) {
					GetComponentInChildren<RawImage> ().texture = item.itemIcon;
					GetComponentInChildren<RawImage> ().color = new Color (1, 1, 1, 1);
				}
			}
			else {
				GetComponentInChildren<RawImage> ().color = new Color (1, 1, 1, 0);

				gameObject.transform.FindChild ("Name").GetComponent<Text> ().text = "";
				gameObject.transform.FindChild ("RarityAndType").GetComponent<Text> ().text = "";
				gameObject.transform.FindChild ("Description").GetComponent<Text> ().text = "";
				gameObject.transform.FindChild ("StatNames").GetComponent<Text> ().text = "";
				gameObject.transform.FindChild ("Stats").GetComponent<Text> ().text = "";
				gameObject.transform.FindChild ("StatsCompareRed").GetComponent<Text> ().text = "";
				gameObject.transform.FindChild ("StatsCompareGreen").GetComponent<Text> ().text = "";
			}
		}
	}
}