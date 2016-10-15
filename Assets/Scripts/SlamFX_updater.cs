using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class SlamFX_updater : MonoBehaviour {

		public float FadeInTime = 0.0f, FadeOutTime = 0.0f, ActiveTime = 0.0f;
		private float m_time = 0.0f;

		void Start() {
			m_time = 0.0f;
		}

		void Update() {
			m_time += Time.deltaTime;
			Vector3 tmp = transform.rotation.eulerAngles;
			tmp.x = (1 - Clamp(m_time / FadeInTime, 0, 1)) * -20;
			transform.rotation = Quaternion.Euler(tmp);
			if (m_time > ActiveTime - FadeOutTime) {
				tmp = transform.position;
				//Debug.Log((m_time - (ActiveTime - FadeOutTime)) / FadeOutTime);
				tmp.y = Clamp((m_time - FadeOutTime) / (ActiveTime - FadeOutTime), 0, 1) * 0.4f;
				transform.position = tmp;
				if (m_time > ActiveTime) {
					//Debug.Log("Destroy slam");
					Destroy(gameObject);
				}
			}
		}
		private float Clamp(float value, float min, float max) {
			if (value < min)
				return min;
			if (value > max)
				return max;
			return value;
		}
	}
}
