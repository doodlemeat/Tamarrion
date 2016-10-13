using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class MagicalGodPowerFeedback : MonoBehaviour {
		public float fade_in = 1.0f, duration = 10.0f;
		private float time = 0.0f;
		private bool activated = false;
		private float opcaity = 0.7f;

		// Use this for initialization
		void Start() {
			time = 0.0f;
		}

		// Update is called once per frame
		void Update() {
			if (activated) {
				//Debug.Log("Activated: " + time);
				time += Time.deltaTime;
				Material[] materials = gameObject.GetComponent<SkinnedMeshRenderer>().materials;
				foreach (Material m in materials) {
					//Debug.Log(m.name);
					if (m.name == "Magic G power (Instance)") {
						m.SetFloat("_Opacity", opcaity);
						if (time < fade_in) {
							m.SetFloat("_Opacity", time / fade_in * opcaity);
						}
						if (time >= duration - fade_in) {
							//Debug.Log((1 - ((time - (duration - fade_in)) / fade_in)));
							m.SetFloat("_Opacity", (1 - ((time - (duration - fade_in)) / fade_in)) * opcaity);
						}
						if (time >= duration) {
							m.SetFloat("_Opacity", 0.0f);
						}
					}
				}
			}
		}
		public void Activate() {
			time = 0.0f;
			activated = true;
			//Debug.Log("Activate Magical Godpowers");
		}
	}
}
