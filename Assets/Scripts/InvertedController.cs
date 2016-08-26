using UnityEngine;
using System.Collections;

public class InvertedController : MonoBehaviour {

    void Start() {
        GetComponent<UnityEngine.UI.Toggle>().isOn = Player.player.GetComponent<PlayerMovement>()._inverted;
        GetComponent<UnityEngine.UI.Toggle>().onValueChanged.AddListener(OnClick);
	}
	
    void OnClick(bool p_value) {
        Player.player.GetComponent<PlayerMovement>()._inverted = p_value;
    }
}