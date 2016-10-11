using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Spell_Thrust : SpellBase {
		public float percentVulnerability = -0.2f;
		public float stunDuration = 2.0f;
		public GameObject target;
		public float extraMovementSpeed = 50.0f;
		Enemy_Stats Enemy_Stats;
		public float minDamage;
		public float maxDamage;
		public float maxChargeTime = 5;
		public GameObject m_trial_obj;

		private GameObject trailInstance;
		private bool isRunning = false;
		private float maxChargeTimeCurrent = 5;

		public override void Start () {
			base.Start ();
			if ( Valac.instance ) {
				target = Valac.instance.gameObject;
				Enemy_Stats = target.GetComponent<Enemy_Stats> ();
			}
		}

		public override void Update () {
			base.Update ();

			if ( !Valac.instance )
				return;

			if ( isRunning ) {
				if ( Vector3.Distance (Player.player.transform.position, Valac.instance.transform.position) < 8 ) {
					Player.player.GetComponentInChildren<Animator> ().SetBool ("Thrusting", false);
				}

				_playerMovement.forceDirection (target.transform.position - _playerStats.transform.position);
				maxChargeTimeCurrent -= Time.deltaTime;

				// If in range
				if ( (Vector3.Distance (target.transform.position, _playerStats.transform.position) <= _playerStats.m_stat["attack_range"]
					&& Vector3.Angle (_playerStats.transform.forward, target.transform.position - _playerStats.transform.position) < 67.5f)
					||
					(maxChargeTimeCurrent <= 0) ) {
					PlayerAttack.instance.RemoveAttackBlock ("spell_thrust");
					_playerMovement.forceDirection (Vector3.zero);
					_playerMovement.RemoveMoveBlock ("spell_thrust");
					_playerStats.Remove_Modifier ("Spell_Thrust_MS");

					bool crit = _playerStats.GetCrit ();

					for ( int i = 0; i < InventoryManager.inventoryManager.AvailableItems.Count; i++ ) {
						if ( InventoryManager.inventoryManager.equipped[4] == i && InventoryManager.inventoryManager.AvailableItems[i].GetComponent<BaseItem> ().itemName == "Small Scope" ) {
							crit = true;
							break;
						}
					}

					float base_damage = _playerStats.m_stat["damage"] + _playerStats.m_stat["physical"];
					float damage = Random.Range (base_damage, base_damage * 1.5f) * (crit ? _playerStats.m_stat["crit_damage"] : 1.0f);
					damage = Enemy_Stats.DealDamage (damage + Random.Range (minDamage, maxDamage), crit);
					if ( trailInstance ) {
						if ( trailInstance.GetComponent<Xft.XWeaponTrail> () )
							trailInstance.GetComponent<Xft.XWeaponTrail> ().Deactivate ();

						if ( trailInstance )
							Destroy (trailInstance);
					}

					isRunning = false;
					//Player.player.transform.Find("TamarrionAnimations01").GetComponent<DynamicBone>().enabled = false;
				}
			}
		}

		public override void use () {
			base.use ();
			isRunning = true;
			PlayerAttack.instance.AddAttackBlock ("spell_thrust");
			_playerStats.Add_Modifier ("Spell_Thrust_MS", "movement_speed", 0, 1.0f + extraMovementSpeed / 100);
			_playerMovement.AddMoveBlock ("spell_thrust");
			_playerMovement.forceDirection (target.transform.position - _playerStats.transform.position);
			maxChargeTimeCurrent = maxChargeTime;
			Player.player.GetComponentInChildren<Animator> ().SetBool ("Thrusting", true);
			//Player.player.transform.Find("TamarrionAnimations01").GetComponent<DynamicBone>().enabled = true;

			if ( m_trial_obj ) {
				trailInstance = (GameObject)Instantiate (m_trial_obj, Player.player.gameObject.transform.position, Player.player.gameObject.transform.rotation);
				trailInstance.transform.SetParent (Player.player.gameObject.transform);
			}
		}
	}
}