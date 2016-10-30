using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class InvertedController : MonoBehaviour {

		void Start() {
			GetComponent<UnityEngine.UI.Toggle>().isOn = Player.player.GetComponent<PlayerMovement>().Inverted;
			GetComponent<UnityEngine.UI.Toggle>().onValueChanged.AddListener(OnClick);
		}

		void OnClick(bool p_value) {
			Player.player.GetComponent<PlayerMovement>().Inverted = p_value;
		}
	}
}
