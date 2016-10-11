using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class MenuSoundManager : MonoBehaviour {
		public static MenuSoundManager instance;

		public AudioSource clickSoundSource;
		public AudioSource selectSoundSource;

		void Awake () {
			instance = this;
		}

		public void PlayClickSound () {
			if ( clickSoundSource )
				clickSoundSource.Play ();
		}

		public void PlaySelectSound () {
			if ( selectSoundSource )
				selectSoundSource.Play ();
		}
	}
}