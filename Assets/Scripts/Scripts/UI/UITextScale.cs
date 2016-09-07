using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextScale : MonoBehaviour {
	Text text;

	void Awake () {
		text = GetComponent<Text> ();
		text.resizeTextForBestFit = true;
	}

	void Update() {
		float width = text.preferredWidth;
		float maxWidth = (transform as RectTransform).rect.width;

		if(width > maxWidth) {
			Vector3 scale = transform.localScale;
			scale.x = maxWidth / width;
			scale.y = scale.x;
			transform.localScale = scale;
		}
	}
}
