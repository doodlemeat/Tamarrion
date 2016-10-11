using UnityEngine;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Renderer))]

	public class GodPowerPlayerBodyMaterial : MonoBehaviour {
		public static GodPowerPlayerBodyMaterial instance;

		void Awake () {
			instance = this;
		}

		public void SetMaterialFloat (string p_variableName, float p_value, int p_materialIndex = 0) {
			Renderer renderer = GetComponent<Renderer> ();
			renderer.materials[p_materialIndex].SetFloat (p_variableName, p_value);
		}

		public void SetMaterialColor (string p_colorName, Color p_colorValue, int p_materialIndex = 0) {
			Renderer renderer = GetComponent<Renderer> ();
			renderer.materials[p_materialIndex].SetColor (p_colorName, p_colorValue);
		}
	}
}