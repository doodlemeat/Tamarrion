using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tamarrion {
	public class UIExitToMenuButton : MyMonoBehaviour, IPointerDownHandler {
		public void OnPointerDown (PointerEventData eventData) {
			if ( eventData.button == PointerEventData.InputButton.Left ) {
                Time.timeScale = 1;
				Application.LoadLevelAsync ("TitleScreen");
            }
		}
	}
}
