using UnityEngine;
using System.Collections.Generic;
namespace Tamarrion {
	public class MausoleumAlcoveLight : MonoBehaviour {
		public Light candleLight;
		public List<ParticleSystem> candleParticles = new List<ParticleSystem> ();

		void Start () {
			SetEnabled (false);
		}

		public void SetEnabled (bool p_enabled = true) {
			if ( candleLight )
				candleLight.enabled = p_enabled;

			foreach ( ParticleSystem part in candleParticles ) {
				part.enableEmission = p_enabled;
			}
		}
	}
}