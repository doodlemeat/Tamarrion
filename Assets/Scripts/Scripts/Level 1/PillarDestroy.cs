using UnityEngine;
using System.Collections;

public class PillarDestroy : MonoBehaviour {
	public GameObject ConnectedTorch;

	public void Destroy () {
		if ( ConnectedTorch ) {
			ConnectedTorch.GetComponent<FlickeringTorch> ().PutOut ();
		}
	}
}
