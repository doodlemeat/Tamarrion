using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class ButtonSelectOnStart : MonoBehaviour {
		void Start () {
			GetComponent<UnityEngine.UI.Button> ().Select ();
		}
	}
}