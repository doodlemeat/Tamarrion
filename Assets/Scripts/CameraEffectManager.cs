using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class CameraEffectManager : MonoBehaviour {
		public static CameraEffectManager Instance;

		List<CameraEffect> _effects = new List<CameraEffect> ();

		void Awake () {
			Instance = this;
		}

		public void Register (CameraEffect effect) {
			if ( effect ) {
				_effects.Add (effect);
			}
		}

		public T Create<T> () where T : CameraEffect {
			T effect = gameObject.GetComponent<T> ();
			if ( !effect ) {
				effect = gameObject.AddComponent<T> ();

				if ( effect ) {
					Register (effect);
					effect.Init ();
				}
			}

			return effect;
		}

		public void Delete (CameraEffect effect) {
			if ( _effects.Contains (effect) ) {
				_effects.Remove (effect);
			}
		}

		public void PostUpdate () {
			foreach ( CameraEffect effect in _effects ) {
				if ( effect._isPlaying ) {
					effect.PostUpdate ();
				}
			}
		}
	}
}
