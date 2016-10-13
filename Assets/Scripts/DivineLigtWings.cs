using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class DivineLigtWings : MonoBehaviour {
		public GameObject m_wings;
		private GameObject wing;
		private MeshRenderer[] renderers;
		public bool show_wings = false;
		private bool showing_wings = false;
		private float start_wings = 0.0f;

		void Update () {
			if ( show_wings && !showing_wings ) {
				wing = (GameObject)Instantiate (m_wings);
				wing.transform.parent = transform;
				wing.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
				wing.transform.localPosition = new Vector3 (0, 0, 0);
				wing.transform.localRotation = Quaternion.Euler (new Vector3 (29.2f, 265.55f, 4.42f));
				renderers = wing.GetComponentsInChildren<MeshRenderer> ();
				start_wings = 100.0f;
				SetWingSoftness (start_wings);
				showing_wings = true;
			}
			if ( showing_wings && !show_wings ) {
				start_wings += Time.deltaTime * 300.0f;
				SetWingSoftness (start_wings);
				if ( start_wings >= 100.0f ) {
					Destroy (wing);
					showing_wings = false;
				}
			}
			if ( showing_wings && show_wings && start_wings > 5.0f ) {
				start_wings -= Time.deltaTime * 300.0f;
				start_wings = start_wings < 5.0f ? 5.0f : start_wings;
				SetWingSoftness (start_wings);
			}
		}
		private void SetWingSoftness (float p_value) {
			for ( int i = 0; i < renderers.Length; i++ ) {
				renderers[i].material.SetFloat ("_Softness", p_value);
			}
		}
	}
}
