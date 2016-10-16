using UnityEngine;
using System;

namespace Tamarrion {
	public abstract class UnitySingleton<T> : MyMonoBehaviour where T : MyMonoBehaviour {
		protected static T instance;

		protected void Awake() {
			int numberOfTypeComponents = GetComponents<T> ().Length;
			if ( numberOfTypeComponents > 1 ) {
				Debug.LogError ("An instance of " + typeof(T).Name + " do already exist on this object");
				DestroyImmediate (this);
			} else if ( instance == null ) {
				instance = this as T;
				HandleAttribute ();
				OnAwake ();
			}
			else {
				Component[] components = GetComponents<Component> ();
				if ( components.Length > 2 ) {
					Destroy (this);
				}
				else {
					Destroy (gameObject);
				}
			}
		}

		protected virtual void OnAwake() {}

		private void HandleAttribute() {
			UnitySingletonAttribute attribute = Attribute.GetCustomAttribute (typeof (T), typeof (UnitySingletonAttribute)) as UnitySingletonAttribute;
			if ( attribute == null ) {
				Debug.LogError ("Failed to find " + typeof (UnitySingletonAttribute).Name + " on " + typeof (T));
			}
			else {
				if ( attribute.mustBeOnlyComponent ) {
					Component[] allComponents = GetComponents<Component> ();
					if ( allComponents.Length > 2 ) {
						Debug.LogError (typeof (T) + " must be the only component on this object");
					}
				}

				if ( attribute.mustBeWithinRootObject ) {
					if ( transform.parent != null ) {
						Debug.LogError (typeof (T) + " is required to be within a root object");
					}
				}
			}
		}
	}
}
