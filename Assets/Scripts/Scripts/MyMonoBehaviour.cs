﻿using UnityEngine;

namespace Tamarrion {
	public class MyMonoBehaviour : MonoBehaviour {
		public void AddListener<T> (EventManager.EventDelegate<T> del) where T : BaseEvent {
			EventManager.instance.AddListener<T> (del);
		}

		public void RemoveListener<T> (EventManager.EventDelegate<T> del) where T : BaseEvent {
			EventManager.instance.RemoveListener<T> (del);
		}

		public void Trigger (BaseEvent e) {
			EventManager.instance.TriggerEvent (e);
		}
	}
}