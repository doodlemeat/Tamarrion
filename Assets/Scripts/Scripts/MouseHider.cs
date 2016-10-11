using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class MouseHider : MonoBehaviour {
		public static MouseHider instance;

		public Texture2D cursorTexture;
		public Vector2 offset = new Vector2 (0, 0);
		bool m_showCursor;
		bool m_forceShowCursor = false;

		void Awake () {
			instance = this;
		}

		void Start () {
			HideCursor ();
		}

		void Update () {
			if ( (!m_showCursor && !m_forceShowCursor) && Cursor.visible )
				HideCursor ();

			if ( Input.GetButton ("ShowMouseCursor") || m_forceShowCursor ) {
				if ( m_showCursor == false )
					ShowCursor ();
			}
			else if ( m_showCursor )
				HideCursor ();
		}

		void ShowCursor () {
			if ( cursorTexture )
				Cursor.SetCursor (cursorTexture, offset, CursorMode.Auto);

			m_showCursor = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		void HideCursor () {
			if ( cursorTexture )
				Cursor.SetCursor (null, offset, CursorMode.Auto);

			m_showCursor = false;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		public void SetForceShow (bool p_value) {
			m_forceShowCursor = p_value;
		}
	}
}