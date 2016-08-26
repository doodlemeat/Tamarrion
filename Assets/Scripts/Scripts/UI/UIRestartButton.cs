using System;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Tamarrion {
	public class UIRestartButton : MyMonoBehaviour, IPointerDownHandler {
		public void OnPointerDown (PointerEventData eventData) {
			if(eventData.button == PointerEventData.InputButton.Left) {
				Application.LoadLevelAsync (Application.loadedLevelName);
			}
		}
	}
}
