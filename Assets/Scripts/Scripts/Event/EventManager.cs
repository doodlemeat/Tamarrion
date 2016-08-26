using UnityEngine;
using System.Collections.Generic;

namespace Tamarrion {
	public class EventManager {
		private static EventManager _instance;

		private EventManager () { }

		public static EventManager instance {
			get {
				if ( _instance == null ) {
					_instance = new EventManager ();
				}

				return _instance;
			}
		}

		void OnDestroy () {
			delegates.Clear ();
			delegateLookup.Clear ();
		}

		public delegate void EventDelegate<T> (T e) where T : BaseEvent;
		private delegate void EventDelegate (BaseEvent e);

		private Dictionary<System.Delegate, EventDelegate> delegateLookup = new Dictionary<System.Delegate, EventDelegate> ();
		private Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate> ();

		private EventDelegate AddDelegate<T> (EventDelegate<T> del) where T : BaseEvent {
			if ( delegateLookup.ContainsKey (del) ) {
				return null;
			}

			EventDelegate internalDelegate = (e) => del ((T)e);
			delegateLookup[del] = internalDelegate;

			EventDelegate tempDel;
			if ( delegates.TryGetValue (typeof (T), out tempDel) ) {
				delegates[typeof (T)] = tempDel += internalDelegate;
			}
			else {
				delegates[typeof (T)] = internalDelegate;
			}

			return internalDelegate;
		}

		public void AddListener<T> (EventDelegate<T> del) where T : BaseEvent {
			AddDelegate<T> (del);
		}

		public void RemoveListener<T> (EventDelegate<T> del) where T : BaseEvent {
			EventDelegate internalDelegate;

			if ( delegateLookup.TryGetValue (del, out internalDelegate) ) {
				EventDelegate tempDel;
				if ( delegates.TryGetValue (typeof (T), out tempDel) ) {
					tempDel -= internalDelegate;

					if ( tempDel == null ) {
						delegates.Remove (typeof (T));
					}
					else {
						delegates[typeof (T)] = tempDel;
					}
				}
			}
		}

		public void TriggerEvent (BaseEvent e) {
			EventDelegate del;

			if ( delegates.TryGetValue (e.GetType (), out del) ) {
				del.Invoke (e);
			}
			else {
				Debug.LogWarning ("Event: " + e.GetType () + " has no listener");
			}
		}
	}
}