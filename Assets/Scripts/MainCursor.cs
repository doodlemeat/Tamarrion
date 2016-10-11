using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class MainCursor : MonoBehaviour {
		public Texture2D cursorTexture;
		public Vector2 offset = new Vector2 (0, 0);

		void Start () {
			ShowCursor ();
		}

		void ShowCursor () {
			if ( cursorTexture )
				Cursor.SetCursor (cursorTexture, offset, CursorMode.Auto);

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}