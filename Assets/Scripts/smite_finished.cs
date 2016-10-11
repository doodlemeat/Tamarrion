using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class smite_finished : MonoBehaviour {

		private float m_time = 0.0f;

		// Use this for initialization
		void Start () {
			gameObject.GetComponent<Animation> ().Play ();
		}

		// Update is called once per frame
		void Update () {
			m_time += Time.deltaTime;
			if ( m_time > 0.5f ) {
				Destroy (gameObject);
			}
		}
	}
}