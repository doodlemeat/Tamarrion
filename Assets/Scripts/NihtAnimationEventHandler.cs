using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class NihtAnimationEventHandler : MonoBehaviour {


		// Raven
		AudioSource _ravenSource;
		public GameObject _ravenSourceObject;

		// Entomb
		AudioSource _entombSource;
		public GameObject _entombSourceObject;

		// PhaseChange
		AudioSource _phaseSource;
		public GameObject _phaseSourceObject;

		AudioSource _breath2Source;
		public GameObject _breath2SourceObject;

		AudioSource _breath1Source;
		public GameObject _breath1SourceObject;

		AudioSource _deathSource;
		public GameObject _deathSourceObject;

		void Start () {
			_ravenSource = _ravenSourceObject.GetComponent<AudioSource> ();
			_entombSource = _entombSourceObject.GetComponent<AudioSource> ();
			_phaseSource = _phaseSourceObject.GetComponent<AudioSource> ();
			_breath1Source = _breath2SourceObject.GetComponent<AudioSource> ();
			_breath2Source = _breath2SourceObject.GetComponent<AudioSource> ();
			_deathSource = _deathSourceObject.GetComponent<AudioSource> ();
		}

		/*public void OnStep()
		{
			_footstepSource.pitch = Random.Range(0.7f, 1.3f);
			_footstepSource.Play();
			if (_footstepDustParticles)
			{
				GameObject tmp = Instantiate(_footstepDustParticles);
				tmp.transform.SetParent(gameObject.transform);
				tmp.transform.localPosition = Vector3.zero;
			}
			else
				Debug.LogError("no particle effect @ boss step");
		}
		*/
		public void OnRaven () {
			_ravenSource.Play ();
		}

		public void OnEntombStart () {
			_entombSource.Play ();
		}
		/*
		public void OnChopChop()
		{
			int soundIndex = Random.Range(1, _chopSounds.Count - 1);
			_chopchopSource.clip = _chopSounds[soundIndex];
			_chopchopSource.Play();
			AudioClip tmp = _chopSounds[0];
			_chopSounds[0] = _chopSounds[soundIndex];
			_chopSounds[soundIndex] = tmp;
		}
		*/
		public void OnPhaseChangeStart () {
			_phaseSource.Play ();
		}

		public void OnBreath1Start () {
			_breath1Source.Play ();
		}

		public void OnBreath2Start () {
			_breath2Source.Play ();
		}

		public void OnDeath () {
			_deathSource.Play ();
		}
		/*
		public void OnCleaveEnd()
		{
			_cleaveSource.clip = _cleaveEndSound;
			_cleaveSource.Play();
		}
		*/
	}
}