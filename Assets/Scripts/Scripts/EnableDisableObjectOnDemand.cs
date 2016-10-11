using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class EnableDisableObjectOnDemand : MonoBehaviour {
		public GameObject target;

		void Update () {
			if ( (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && Input.GetKeyDown (KeyCode.L) ) {
				if ( target )
					target.SetActive (!target.activeSelf);
			}
		}
	}
}