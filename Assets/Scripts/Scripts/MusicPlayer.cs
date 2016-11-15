using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class MusicPlayer : MonoBehaviour {
		struct FadeClip {
			public float m_fadeInTime, m_fadeOutTime;
			public AudioClip m_clip;
			public Timer m_fadeInTimer;
			public Timer m_fadeOutTimer;

			public void StartFadeInTimer () {
				m_fadeInTimer.Start(m_fadeInTime);
			}
			public void StartFadeOutTimer () {
				m_fadeOutTimer.Start(m_fadeOutTime);
			}
		}

		bool changeClip = false;
		//float targetVolume = 1;
		//AudioSource audioSource;

		FadeClip PlayingClip;
		FadeClip QueuedClip;

		void Start () {
			//audioSource = GetComponent<AudioSource>();
			//targetVolume = audioSource.volume;
		}

		void Update () {
			if ( changeClip ) {
				if ( PlayingClip.m_clip != null ) {
					if ( PlayingClip.m_fadeOutTimer.IsFinished == false ) {

					}
				}
			}
		}

		public void PlayClip (AudioClip p_clip, float p_fadeIn, float p_fadeOut) {
			QueuedClip.m_clip = p_clip;
			QueuedClip.m_fadeInTime = p_fadeIn;
			QueuedClip.m_fadeOutTime = p_fadeOut;

			changeClip = true;
			PlayingClip.StartFadeOutTimer ();
		}
	}
}