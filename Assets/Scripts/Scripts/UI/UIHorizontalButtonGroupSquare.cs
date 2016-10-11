using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
namespace Tamarrion {
	[ExecuteInEditMode]
	[RequireComponent (typeof (RectTransform))]
	public class UIHorizontalButtonGroupSquare : MonoBehaviour {
		List<Button> buttons = new List<Button> ();
		public float padding;

		void Awake () {
			buttons = new List<Button> ();

			GetButtonsInChildren ();
		}

		void Update () {
			if ( padding < 0 ) {
				padding = 0;
			}

			GetButtonsInChildren ();
			RectTransform rt = transform as RectTransform;
			float perBtnPadding = padding / buttons.Count;
			float childWidth = rt.rect.width / buttons.Count - padding + perBtnPadding;

			for ( int i = 0; i < buttons.Count; ++i ) {
				RectTransform buttonRt = buttons[i].transform as RectTransform;
				Vector2 size = buttonRt.sizeDelta;
				size.x = childWidth;
				size.y = childWidth;
				buttonRt.sizeDelta = size;

				float xPosition = childWidth * i;
				Vector3 newPos = buttonRt.anchoredPosition;
				newPos.x = xPosition + buttonRt.rect.width / 2.0f + i * padding;
				newPos.y = -rt.rect.height / 2.0f;

				buttonRt.anchoredPosition = newPos;
			}
		}

		void GetButtonsInChildren () {
			buttons.Clear ();
			for ( int i = 0; i < transform.childCount; ++i ) {
				Transform child = transform.GetChild (i);
				Button btn = child.GetComponent<Button> ();
				if ( btn != null ) {
					buttons.Add (btn);
				}
			}
		}
	}
}