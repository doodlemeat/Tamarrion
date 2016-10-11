using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class DestroyHandsOnEnd : MonoBehaviour {

		private float m_time = 0.0f;
		public float m_life_time = 2.0f;

		void Start () {
			m_time = 0.0f;
		}

		void Update () {
			m_time += Time.deltaTime;
			if ( m_time > m_life_time ) {
				Destroy (gameObject);
			}
		}
	}
}