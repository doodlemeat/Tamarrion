using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class CirclingParticles : MonoBehaviour {

		private List<Transform> m_orbs;
		public Transform m_orb_prefab;
		public int m_orb_amount = 1;
		public float m_orb_speed = 50.0f, m_orbit_size = 1.0f;

		void Start () {
			m_orbs = new List<Transform> ();
			for ( int i = 0; i < m_orb_amount; i++ ) {
				m_orbs.Add ((Transform)Instantiate (m_orb_prefab, transform.position + RandomPosition () * m_orbit_size, Quaternion.LookRotation (RandomPosition ())));
				m_orbs[i].parent = transform;
			}
		}
		void Update () {
			foreach ( Transform orb in m_orbs ) {
				if ( orb == null )
					m_orbs.Remove (orb);
				else
					orb.RotateAround (transform.position, orb.forward, m_orb_speed * Time.deltaTime);
			}
		}

		private Vector3 RandomPosition () {
			return new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f)).normalized;
		}
	}
}