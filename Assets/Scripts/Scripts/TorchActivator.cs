using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class TorchActivator : MonoBehaviour {
		public List<FlickeringTorch> torches = new List<FlickeringTorch> ();
		bool _activated = false;

		void Start () {

		}

		void Update () {

		}

		void OnTriggerEnter (Collider other) {
			if ( other.gameObject.tag == "Player" && !_activated ) {
				Activate ();
			}
		}

		public void Activate () {
			_activated = true;
			foreach ( FlickeringTorch torch in torches ) {
				torch.toggleOn ();
			}
		}
		public void Deactivate () {
			_activated = false;
			foreach ( FlickeringTorch torch in torches ) {
				torch.toggleOff ();
			}
		}
	}
}