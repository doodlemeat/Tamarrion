using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class SlotButtonGroup : MonoBehaviour {
		public List<GameObject> Buttons;

		public void UpdateButtonTextures () {
			foreach ( GameObject button in Buttons ) {
				button.GetComponent<SlotButton> ().UpdateTexture ();
			}
		}
	}
}