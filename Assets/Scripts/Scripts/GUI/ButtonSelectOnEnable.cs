using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class ButtonSelectOnEnable : MonoBehaviour {
		public UnityEngine.UI.Button TargetButton = null;

		public void OnEnable () {
			if ( TargetButton )
				TargetButton.Select ();
		}
	}
}