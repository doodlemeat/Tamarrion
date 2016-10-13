using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class Entomb_Effect : MonoBehaviour {
		public float Activate_time, Death_time;
		public float[] Life_time;
		private float m_time_alive = 0.0f;
		public ParticleSystem Particle;
		private ParticleSystem m_particleinstance;

		void Start() {
			m_time_alive = 0.0f;
			transform.position -= new Vector3(0, 4, 0);
			if (Particle) {
				m_particleinstance = (ParticleSystem)Instantiate(Particle, transform.position + Particle.transform.position, transform.rotation);
				m_particleinstance.transform.rotation *= Quaternion.Euler(new Vector3(270, 0, 0));
			}
		}

		void Update() {
			m_time_alive += Time.deltaTime;
			if (m_time_alive <= Activate_time) {
				transform.position += new Vector3(0, 4.0f * Time.deltaTime * (1 / Activate_time), 0);
			}
			else if (m_time_alive > Activate_time + Life_time[(int)Difficulty.Current_difficulty]) {
				transform.position -= new Vector3(0, 4.0f * Time.deltaTime * (1 / Death_time), 0);
			}
			if (m_time_alive > Activate_time + Life_time[(int)Difficulty.Current_difficulty] + Death_time) {
				Destroy(gameObject);
			}
		}
	}
}
