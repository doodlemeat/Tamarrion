using UnityEngine;

namespace Tamarrion {
	public class ContextPanel : MyMonoBehaviour {
		
		protected string id;
		
		protected void Awake() {
			id = gameObject.name.ToLower ();
		}

		public string GetId() {
			return id;
		}

		protected virtual void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)) {
				Trigger (new CloseContextPanelEvent(this));
			}
		}
	}
}
