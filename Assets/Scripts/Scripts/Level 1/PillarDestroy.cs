using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class PillarDestroy : MonoBehaviour {
		public GameObject ConnectedTorch;

		public void Destroy () {
			if ( ConnectedTorch ) {
				ConnectedTorch.GetComponent<FlickeringTorch> ().PutOut ();
			}
		}
	}
}