using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tamarrion {
	public class ExitToDesktopButton : MyMonoBehaviour, IPointerDownHandler {
		public void OnPointerDown (PointerEventData eventData) {
			if(eventData.button == PointerEventData.InputButton.Left) {
				if ( Application.isEditor ) {
#if UNITY_EDITOR
					UnityEditor.EditorApplication.isPlaying = false;
#endif
				}
				else {
					Application.Quit ();
				}
			}
		}
	}
}
