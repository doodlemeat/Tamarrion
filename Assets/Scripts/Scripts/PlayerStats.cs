using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class PlayerStats : CombatStats {
		public static PlayerStats instance;

		public Animator playerAnimator;

		[Header ("Hit particles")]
		public ParticleSystem hitParticles;
		public float hitHeight = 1;

		[Header ("Liquid Love")]
		public float liquid_love_heal = 1.0f;
		public float liquid_love_tick_time = 1.0f;
		public float liquid_love_no_damage_time = 5.0f;
		private float liquid_love_time_no_damage = 0.0f, liquid_love_hot_time = 0.0f, liquid_love_last_hp = 0.0f;
		private bool liquid_love_equipped = false;

		[Header ("Perkulator")]
		public float percent_to_gain_speed_by_perk = 20.0f;
		public float perk_speed_boost = 1.5f;
		public float perk_speed_duration = 5.0f;

		[Header ("Reanimator")]
		public float reanimator_health_flat = 50.0f;
		public float reanimator_health_percent = 0.5f;
		public GameObject ReanimParticleSys;
		private bool reanimator_used = false;

		protected override void Awake () {
			base.Awake ();
			instance = this;
		}

		void Start () {
			liquid_love_equipped = false;
			for ( int i = 0; i < InventoryManager.inventoryManager.AvailableItems.Count; i++ ) {
				if ( InventoryManager.inventoryManager.equipped[4] == i && InventoryManager.inventoryManager.AvailableItems[i].GetComponent<BaseItem> ().itemName == "Liquid Love" ) {
					liquid_love_equipped = true;
					break;
				}
			}
		}

		void Update () {
			if ( liquid_love_equipped ) {
				liquid_love_time_no_damage += Time.deltaTime;
				if ( liquid_love_last_hp > m_stat["health"] ) {
					liquid_love_time_no_damage = 0.0f;
					liquid_love_hot_time = 0.0f;
				}
				liquid_love_last_hp = m_stat["health"];
				if ( liquid_love_time_no_damage > liquid_love_no_damage_time ) {
					liquid_love_hot_time += Time.deltaTime;
					if ( liquid_love_hot_time > liquid_love_tick_time ) {
						liquid_love_hot_time -= liquid_love_tick_time;
						HealFlat (liquid_love_heal);
					}
				}
			}
		}

		public override void HealFlat (float p_amount) {
			base.HealFlat (p_amount);

			for ( int i = 0; i < InventoryManager.inventoryManager.AvailableItems.Count; i++ ) {
				if ( InventoryManager.inventoryManager.equipped[4] == i && InventoryManager.inventoryManager.AvailableItems[i].GetComponent<BaseItem> ().itemName == "Perkulator" ) {
					if ( Random.Range (0.0f, 100.0f) <= percent_to_gain_speed_by_perk ) {
						Remove_Modifier ("perkulator_speed");
						Add_Modifier ("perkulator_speed", "movement_speed", 0.0f, perk_speed_boost);
						BuffManager.player_buffs.AddBuff ("perkulator_speed", Player.player.gameObject, perk_speed_duration, InventoryManager.inventoryManager.AvailableItems[i].GetComponent<BaseItem> ().itemIcon);
					}
					break;
				}
			}
		}

		public override float DealDamage (float p_amount, bool p_crit = false) {
			float damage = base.DealDamage (p_amount, p_crit);
			if ( damage > 0 ) {
				if ( PlayerAnimationEventHandler.Instance )
					PlayerAnimationEventHandler.Instance.OnHit ();

				if ( hitParticles )
					Instantiate (hitParticles, gameObject.transform.position + new Vector3 (0, hitHeight, 0), Quaternion.identity);

				if ( targetAnimator )
					targetAnimator.SetBool (hurtAnimatorString, true);
			}
			return damage;
		}

		public void PrintModifiers () {
			Debug.Log ("printing modifiers:");
			if ( m_modifiers.Count == 0 )
				Debug.Log ("no mods");
			foreach ( Modifier mod in m_modifiers ) {
				Debug.Log (mod.name + " (" + mod.stat + ") flat: " + mod.flat + " percent: " + mod.percent);
			}
		}

		protected override void InstansiateFloatingText (float p_amount, bool p_crit, Color p_color) {
			FloatingText.Amount = p_amount;
			FloatingText.Crit = p_crit;
			FloatingText.Color = p_color;
			Instantiate (FloatingText, transform.position + new Vector3 (0.0f, 1.75f, 0.0f), Quaternion.identity);
		}

		protected override void Death () {
			if ( !reanimator_used && InventoryManager.inventoryManager.GetItemInEquippedSlot (BaseItem.EItemType.Token) && InventoryManager.inventoryManager.GetItemInEquippedSlot (BaseItem.EItemType.Token).itemName == "The Reanimator of Mika’Elah" ) {
				reanimator_used = true;
				if ( ReanimParticleSys )
					Instantiate (ReanimParticleSys, Player.player.gameObject.transform.position, ReanimParticleSys.transform.rotation);
				m_stat["health"] = reanimator_health_flat;
				m_stat["health"] += m_stat["max_health"] * reanimator_health_percent;
			}
			reanimator_used = true;
		}
	}
}