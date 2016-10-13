using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class AudioOptions {
		public string clip;
		public float pitch;
	}

	public class AudioManager : MyMonoBehaviour {
		public static AudioManager instance;
		public AudioClip[] audioClips;

		AudioSource audioSource;
		Hashtable audioClipsHashed = new Hashtable ();
		List<AudioSource> audioSources = new List<AudioSource> ();

		void Awake () {
			if ( instance == null ) {
				instance = this;
			}
			else {
				Destroy (this);
			}

			AddListener<TriggerAudioEvent> (OnTriggerAudio);
		}

		void OnDestroy() {
			RemoveListener<TriggerAudioEvent> (OnTriggerAudio);
		}

		void OnTriggerAudio(TriggerAudioEvent e) {
			if ( e.options != null ) {
				AudioSource source = CreateSource (e.options);
				source.Play ();
				return;
			}
			Play (e.audio);
		}

		AudioSource CreateSource(AudioOptions options) {
			AudioSource source = gameObject.AddComponent<AudioSource> ();
			source.clip = (AudioClip)audioClipsHashed[options.clip];
			source.pitch = options.pitch;
			audioSources.Add (source);
			return source;
		}

		void Start () {
			audioSource = GetComponent<AudioSource> ();

			foreach ( AudioClip clip in audioClips ) {
				audioClipsHashed.Add (clip.name, clip);
			}
		}

		public void Play (string name) {
			AudioClip clip = (AudioClip)audioClipsHashed[name];
			audioSource.PlayOneShot (clip);
		}

		public void Play (AudioClip clip) {
			audioSource.PlayOneShot (clip);
		}

		public void Play (AudioClip clip, float volume) {
			audioSource.volume = 0.25f;
			Play(clip);
		}

		void Update() {
			for(int i = audioSources.Count - 1; i >= 0; --i ) {
				if(!audioSources[i].isPlaying) {
					Destroy (audioSources[i]);
					audioSources.Remove (audioSources[i]);
				}
			}
		}
	}
}
