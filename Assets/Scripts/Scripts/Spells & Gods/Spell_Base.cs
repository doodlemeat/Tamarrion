using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class SpellBase : MonoBehaviour {
		public Texture _spellIconMenu = null;
		public Texture _spellIconIngame = null;
		public Sprite _spellIconCooldown = null;

		[Header ("Channeling effect")]
		public GameObject ChannelingParticleSys;
		public float ChannelingParticlesHeight = 1;
		protected GameObject ChannelingParticleInstance;

		[Header ("Player effect")]
		public GameObject PlayerCastParticleSys;
		public float PlayerCastParticlesHeight = 1;
		public bool PlayerEffectSetParent = false;
		public GameObject PlayerCastSound;

		[Header ("Boss effect")]
		public GameObject BossCastParticleSys;
		public float BossCastParticlesHeight = 2;
		public bool BossEffectSetParent = false;
		public GameObject BossCastSound;

		[Header ("Stats")]
		public string _Name = "";
		public FSSkillElement element = FSSkillElement.FS_Elem_Holy;
		public string _description = "";
		public bool _ranged = false;
		public bool _angleDependent = true;
		public float _cooldown = 0;
		public float _range = 0;
		public float _castTime = 0;
		public bool _castThroughAttack = false;
		public float _cancelAcceptTime = 0.1f;
		public bool _canBeCastBeforeBoss = false;
		public bool _defensive = false;
		public bool _playDefaultAnimations = true;

		protected bool _activated = false; // When the spell is cast by an input action
		protected bool _cool = true;
		protected bool _castActivated = false;
		protected float _cooldownTimer = 0;
		protected float _castSpellTimer = 0;
		protected Vector3 _castingPosition = Vector3.zero;
		protected PlayerStats _playerStats = null;
		protected PlayerMovement _playerMovement = null;
		protected PlayerAttack _playerAttack = null;
		protected SpellManager _spellManager = null;
		protected float MoveThreshold = 0.1f;
		protected float MoveThresholdCurrent;

		[Header ("Music box")]
		public float music_box_proc_chance = 0.1f;

		public virtual void Start () {
			_playerStats = GetComponentInParent<PlayerStats> ();
			_playerMovement = GetComponentInParent<PlayerMovement> ();
			_playerAttack = GetComponentInParent<PlayerAttack> ();
			_spellManager = GetComponentInParent<SpellManager> ();
		}

		public virtual void Update () {
			if ( _cool == false ) {
				if ( _cooldownTimer == 0.0f ) {
					_cool = true;
				}
				else {
					_cooldownTimer -= Time.deltaTime;
					if ( _cooldownTimer < 0.0f ) {
						_cooldownTimer = 0.0f;
					}
				}
			}

			if ( _activated ) {
				if ( MoveThresholdCurrent > 0 ) {
					MoveThresholdCurrent -= Time.deltaTime;
					if ( MoveThresholdCurrent <= 0 ) {
						_castingPosition = _playerMovement.transform.position;
						MoveThresholdCurrent = 0;
					}
				}

				if ( !_castActivated ) {
					_castSpellTimer -= Time.deltaTime;
					if ( _castSpellTimer <= 0.0f ) {
						use ();
					}

					if ( MoveThresholdCurrent == 0 && !PositionsAreWithinRange (_playerMovement.transform.position, _castingPosition, 1.0f) ) {
						if ( !GodManager.Instance.CurrentGod || GodManager.Instance.CurrentGod.element != FSSkillElement.FS_Elem_Nature ) {
							CancelSpell ();
							Player.player.GetComponentInChildren<CastHandEffect> ().RemoveSpellEffect ();
						}
					}
				}
			}

			if ( ChannelingParticleSys ) {
				if ( _activated && !ChannelingParticleInstance ) {
					ChannelingParticleInstance = (GameObject)Instantiate (ChannelingParticleSys, Player.player.transform.position + new Vector3 (0, ChannelingParticlesHeight, 0), ChannelingParticleSys.transform.rotation);
					ChannelingParticleInstance.transform.SetParent (Player.player.transform);

					//add "AutoDestroyParticleSystem" script if it doesn't exist
					if ( !ChannelingParticleInstance.GetComponent<AutoDestroyParticleSystem> () ) {
						ChannelingParticleInstance.AddComponent<AutoDestroyParticleSystem> ();
						ChannelingParticleInstance.GetComponent<AutoDestroyParticleSystem> ().DestroyWhenOrphan = true;
					}
				}
				if ( !_activated && ChannelingParticleInstance ) {
					ChannelingParticleInstance.transform.SetParent (null);
					ChannelingParticleInstance = null;
				}
			}
		}

		bool PositionsAreWithinRange (Vector3 p_first, Vector3 p_second, float p_range) {
			Debug.Log ("first (" + p_first + ") second (" + p_second + ") range: " + (p_first - p_second).magnitude);
			return (p_first - p_second).magnitude <= p_range;
		}

		public virtual void cast () {
			if ( !_activated ) {
				MoveThresholdCurrent = MoveThreshold;
				if ( _playDefaultAnimations ) {
					Player.player.GetComponentInChildren<Animator> ().SetBool (_defensive ? "Cast defensive" : "Cast offensive", true);
					Player.player.GetComponentInChildren<Animator> ().SetBool ("Cast", true);
				}
				_activated = true;

				if ( _castTime > 0.0f ) {
					if ( _playDefaultAnimations )
						Player.player.GetComponentInChildren<Animator> ().SetBool ("Looping spell", true);
					//PlayerCastbar.castbar.OnSpellcast(this);
					_castSpellTimer = _castTime;
					_castActivated = false;
				}
				else {
					_castActivated = true;
					use ();
				}
			}
		}

		public virtual void use () {
			if ( _playDefaultAnimations )
				Player.player.GetComponentInChildren<Animator> ().SetBool ("Looping spell", false);
			Player.player.RemoveCastingSpell ();
			Player.player.GetComponentInChildren<CastHandEffect> ().RemoveSpellEffect ();

			//_playerStats.ComboPoints.Add(new ComboPoint(element));
			//if (_playerStats.ComboPoints.Count == 1 && ComboHelpText.instance)
			//    ComboHelpText.instance.SpawnText("Invoke " + GodManager.Instance.GetGodByType(_playerStats.ComboPoints[0].element).GodName(), _playerStats.ComboPoints[0].element);

			_castActivated = true;
			startCooldown ();
			_activated = false;

			// Inform spell manager the spell is cast
			//_spellManager.onSpellCast(this);

			// particle effects
			if ( PlayerCastParticleSys ) {
				GameObject sys = (GameObject)Instantiate (PlayerCastParticleSys, Player.player.transform.position + new Vector3 (0, PlayerCastParticlesHeight, 0), PlayerCastParticleSys.transform.rotation);

				if ( PlayerEffectSetParent )
					sys.transform.SetParent (Player.player.transform);
			}
			if ( PlayerCastSound )
				Instantiate (PlayerCastSound, Player.player.transform.position + new Vector3 (0, 0.5f, 0), Quaternion.identity);
			if ( BossCastParticleSys ) {
				GameObject sys = (GameObject)Instantiate (BossCastParticleSys, Valac.instance.transform.position + new Vector3 (0, BossCastParticlesHeight, 0), BossCastParticleSys.transform.rotation);

				if ( BossEffectSetParent )
					sys.transform.SetParent (Valac.instance.transform);
			}
			if ( BossCastSound )
				Instantiate (BossCastSound, Valac.instance.transform.position + new Vector3 (0, 0.5f, 0), Quaternion.identity);
		}

		private void startCooldown () {
			if ( music_box_proc_chance >= 0.0f ) {
				for ( int i = 0; i < InventoryManager.inventoryManager.AvailableItems.Count; i++ ) {
					//Debug.Log(InventoryManager.inventoryManager.equipped[4]);
					if ( InventoryManager.inventoryManager.equipped[4] == i && InventoryManager.inventoryManager.AvailableItems[i].GetComponent<BaseItem> ().itemName == "Music Box" ) {
						if ( Random.Range (0.0f, 1.0f) <= music_box_proc_chance ) {
							//Debug.Log("Perk speed: " + perk_speed_boost + "% for " + perk_speed_duration + "secs");
							return;
						}
						break;
					}
				}
			}
			_cooldownTimer = _cooldown * (1.0f - _playerStats.m_stat["cooldown_reduction"]);
			_cool = false;
		}

		public bool isCool () {
			return _cool;
		}

		public float CooldownRemainingPercent () {
			return (_cooldownTimer / _cooldown);
		}

		public bool IsCasting () {
			return _activated;
		}

		public float SpellcastProgress () {
			return (_castSpellTimer / _castTime);
		}

		public void CancelSpell () {
			//Debug.Log("Canceling spell");
			if ( _playDefaultAnimations ) {
				Player.player.GetComponentInChildren<Animator> ().SetBool ("Looping spell", false);
				Player.player.GetComponentInChildren<Animator> ().SetBool ("Cast", false);
			}
			if ( _castSpellTimer <= _cancelAcceptTime ) {
				_castSpellTimer = 0;
				use ();
			}
			else {
				Player.player.RemoveCastingSpell ();
				_activated = false;
				ErrorBar.instance.SpawnText ("Spell interrupted");
				Player.player.GetComponentInChildren<CastHandEffect> ().RemoveSpellEffect ();
			}
		}
	}
}