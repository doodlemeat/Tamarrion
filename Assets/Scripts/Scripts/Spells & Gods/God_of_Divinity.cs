using UnityEngine;
using System.Collections.Generic;
namespace Tamarrion {
	public class God_of_Divinity : God_Base {
		public GameObject _projectile;
		public GameObject CastParticleSys;
		public float _speed;
		public float _damageMin;
		public float _damageMax;
		public GameObject swordEffect;
		GameObject swordEffectInstance;
		public GameObject orbPrefab;
		List<OrbHandler> magicOrbInstances = new List<OrbHandler> ();
		int currentOrbIndex = -1;
		public float OrbRespawnTime = 1f;

		class OrbHandler {
			TopgunTimer respawnTimer = new TopgunTimer ();
			public bool active = true;
			public GameObject orbInstance;

			public OrbHandler () { }
			public void Activate () {
				if ( orbInstance )
					orbInstance.SetActive (true);

				active = true;
			}
			public void Deactivate (float p_deactivationTime) {
				if ( orbInstance )
					orbInstance.SetActive (false);

				active = false;
				respawnTimer.StartTimerBySeconds (p_deactivationTime);
			}
			public void Update () {
				if ( active )
					return;

				respawnTimer.Update ();
				if ( respawnTimer.IsComplete )
					Activate ();
			}
		}

		protected override void Start () {
			base.Start ();
			PlayerAttack.onAttack += OnAttack;
			//Player.player.GetComponentInChildren<MagicalGodPowerFeedback>().Activate();
			if ( TamSwordInstance.instance ) {
				TamSwordInstance.instance.gameObject.SetActive (false);
			}
			if ( swordEffect ) {
				swordEffectInstance = (GameObject)Instantiate (swordEffect, Player.player.transform.position, Player.player.transform.rotation);
				swordEffectInstance.transform.SetParent (Player.player.transform);
				swordEffectInstance.transform.localPosition = swordEffect.transform.position;
				swordEffectInstance.transform.localRotation = swordEffect.transform.rotation;
			}
		}

		public override void Deactivate () {
			base.Deactivate ();
			PlayerAttack.onAttack -= OnAttack;
			if ( TamSwordInstance.instance )
				TamSwordInstance.instance.gameObject.SetActive (true);
			DeactivateSwordEffectInstance ();
			ClearOrbs ();
		}

		protected override void Update () {
			base.Update ();
			if ( swordEffectInstance ) {
				if ( swordEffectInstance.GetComponent<Animation> ().isPlaying == false ) {
					SpawnOrbs ();
					DeactivateSwordEffectInstance ();
				}
			}
			UpdateOrbHandlers ();
		}

		void UpdateOrbHandlers () {
			foreach ( OrbHandler handler in magicOrbInstances ) {
				handler.Update ();
			}
		}

		void SpawnOrbs () {
			if ( orbPrefab && swordEffectInstance ) {
				foreach ( Transform child in swordEffectInstance.transform ) {
					if ( child.GetComponent<MagicGodPowerOrbSpawnPosition> () ) {
						OrbHandler handler = new OrbHandler ();
						handler.orbInstance = (GameObject)Instantiate (orbPrefab, child.position, Player.player.transform.rotation);
						magicOrbInstances.Add (handler);
						handler.orbInstance.transform.SetParent (Player.player.transform);
						handler.orbInstance.transform.localPosition += child.GetComponent<MagicGodPowerOrbSpawnPosition> ().offset;
					}
				}
			}
		}

		void ClearOrbs () {
			foreach ( OrbHandler handler in magicOrbInstances ) {
				Destroy (handler.orbInstance);
			}
			magicOrbInstances.Clear ();
			currentOrbIndex = -1;
		}

		void DeactivateSwordEffectInstance () {
			Destroy (swordEffectInstance);
			swordEffectInstance = null;
		}

		void OnAttack (PlayerAttack.AttackInfo attackInfo) {
			Vector3 ProjectileSpawnPos = Player.player.LeftHand ? Player.player.LeftHand.transform.position : Player.player.transform.position + new Vector3 (0, 1, 0);
			if ( CastParticleSys ) {
				GameObject partSys = (GameObject)Instantiate (CastParticleSys, ProjectileSpawnPos, Player.player.transform.rotation);
				partSys.transform.SetParent (Player.player.LeftHand ? Player.player.LeftHand.transform : Player.player.transform);
			}

			PlayerAnimationEventHandler.Instance.OnArcane ();
			if ( _projectile ) {
				GameObject projectileObject = (GameObject)Instantiate (_projectile, ProjectileSpawnPos, Player.player.transform.rotation);
				CollisionIgnoranceManager.SetCollisionBetweenPlayerAndChosenCollider (projectileObject.GetComponent<Collider> (), false);
				Projectile projectileScript = projectileObject.GetComponent<Projectile> ();
				projectileScript.speed = _speed;
				projectileScript.damage = attackInfo._damage + Random.Range (_damageMin, _damageMax) + (PlayerStats.instance ? PlayerStats.instance.GetStatValue ("magical") : 0);
				projectileScript.crit = attackInfo._crit;
				projectileScript.UpdateVelocity ();
			}

			DeactivateAnOrb ();
		}

		void DeactivateAnOrb () {
			if ( magicOrbInstances.Count > 0 )
				magicOrbInstances[++currentOrbIndex % magicOrbInstances.Count].Deactivate (OrbRespawnTime);
		}

		public override string ThreeWordDescription () {
			return "Ranged attacks";
		}

		public override string GodName () {
			return "Verristien";
		}

		public override string ActiveEffectName () {
			return "Verristien's aptitude";
		}
	}
}