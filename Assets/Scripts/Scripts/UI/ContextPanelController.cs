using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class ContextPanelController : MyMonoBehaviour {
		ContextPanel currentPanel;
		Hashtable panels;
		
		void Awake () {
			currentPanel = null;
			panels = new Hashtable ();

			ContextPanel[] contextPanels = transform.GetComponentsInChildren<ContextPanel> ();
			foreach(ContextPanel contextPanel in contextPanels) {
				contextPanel.gameObject.SetActive (false);
				panels.Add (contextPanel.name.ToLower(), contextPanel);
			}

			AddListener<ChangeContextPanelEvent> (OnChangeContextPanel);
			AddListener<CloseContextPanelEvent> (OnCloseContextPanel);
		}

		void OnDestroy() {
			RemoveListener<ChangeContextPanelEvent> (OnChangeContextPanel);
			RemoveListener<CloseContextPanelEvent> (OnCloseContextPanel);
		}

		public void OnClickMenuItem (string id) {
			id = id.Trim ();
			if ( id == "" ) return;

			Trigger (new ChangeContextPanelEvent(id));
		}

		void OnChangeContextPanel(ChangeContextPanelEvent e) {
			if(!currentPanel || currentPanel.GetId() != e.id) {
				SwitchPanel (e.id.ToLower());
			}
		}

		void OnCloseContextPanel(CloseContextPanelEvent e) {
			e.panel.gameObject.SetActive (false);
			currentPanel = null;
		}
		
		void SwitchPanel(string id) {
			if(currentPanel != null) {
				currentPanel.gameObject.SetActive (false);
				currentPanel = null;
			}

			if(panels.ContainsKey(id)) {
				currentPanel = (ContextPanel)panels[id];
				currentPanel.gameObject.SetActive (true);
			} else {
				Debug.LogError ("No panel with id: " + id + " was found");
			}
		}
	}
}
