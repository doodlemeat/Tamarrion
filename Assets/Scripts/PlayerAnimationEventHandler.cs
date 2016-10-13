using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class PlayerAnimationEventHandler : MonoBehaviour {
		public static PlayerAnimationEventHandler Instance;

		// Sword swing
		public GameObject _swordSourceObject;
		AudioSource _swordSource;

		// Sword swing around
		public GameObject _swordAroundSourceObject;
		AudioSource _swordAroundSource;

		// Footstep sound
		public GameObject _footstepSourceObject;
		AudioSource _footstepSource;
		public List<AudioClip> _footstepSounds = new List<AudioClip>();

		// hit sounds
		public GameObject _hitSourceObject;
		AudioSource _hitSource;
		public List<AudioClip> _hitSounds = new List<AudioClip>();
		public float hitSoundsTargetPitch = 1f;
		public float hitSoundsRandomPitchRange = 0.1f;

		// arcane
		public GameObject _arcanceSourceObject;
		AudioSource _arcanceSource;

		// god
		public GameObject _godSourceObject;
		AudioSource _godSource;

		// shield
		public GameObject _shieldSourceObject;
		AudioSource _shieldSource;

		void Awake() {
			Instance = this;
		}

		void Start() {
			_swordSource = _swordSourceObject.GetComponent<AudioSource>();
			_swordAroundSource = _swordAroundSourceObject.GetComponent<AudioSource>();
			_footstepSource = _footstepSourceObject.GetComponent<AudioSource>();
			_hitSource = _hitSourceObject.GetComponent<AudioSource>();
			_arcanceSource = _arcanceSourceObject.GetComponent<AudioSource>();
			_godSource = _godSourceObject.GetComponent<AudioSource>();
			_shieldSource = _shieldSourceObject.GetComponent<AudioSource>();
		}

		public void OnSwing() {
			_swordSource.pitch = Random.Range(0.9f, 1.4f);
			_swordSource.Play();
		}

		public void OnSwingAround() {
			_swordAroundSource.Play();
		}

		public void OnStep() {
			if (_footstepSounds.Count == 0 || PlayerMovement.instance.GetForcedDirection().magnitude > 0.1f || Player.player.InMenu)
				return;

			int soundIndex = Random.Range(1, _footstepSounds.Count - 1);
			_footstepSource.clip = _footstepSounds[soundIndex];
			_footstepSource.pitch = Random.Range(0.8f, 1.4f);
			_footstepSource.Play();
			AudioClip tmp = _footstepSounds[0];
			_footstepSounds[0] = _footstepSounds[soundIndex];
			_footstepSounds[soundIndex] = tmp;
		}

		public void OnHit(float p_pitchAdjust = 0f) {
			if (_hitSounds.Count == 0)
				return;

			int soundIndex = Random.Range(1, _hitSounds.Count - 1);
			_hitSource.clip = _hitSounds[soundIndex];
			_hitSource.Play();

			_hitSource.pitch = hitSoundsTargetPitch + p_pitchAdjust + Random.Range(-hitSoundsRandomPitchRange, hitSoundsRandomPitchRange);

			AudioClip tmp = _hitSounds[0];
			_hitSounds[0] = _hitSounds[soundIndex];
			_hitSounds[soundIndex] = tmp;
		}

		public void OnArcane() {
			_arcanceSource.Play();
		}

		public void OnGodActive(AudioClip clip) {
			_godSource.clip = clip;
			_godSource.Play();
		}

		public void OnShield() {
			_shieldSource.Play();
		}
	}
}
