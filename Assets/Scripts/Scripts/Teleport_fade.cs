using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Teleport_fade : MonoBehaviour {

		public SkinnedMeshRenderer[] m_renderers = new SkinnedMeshRenderer[0];
		public MeshRenderer[] m_meshes = new MeshRenderer[0];
		public float m_fade_time = 1.0f;
		private float m_time_faded = 0.0f;
		public bool Teleported = false;

		void Start () {
			Teleported = false;
		}
		void Update () {
			if ( Teleported ) {
				m_time_faded = m_time_faded + Time.deltaTime > m_fade_time ? m_fade_time : m_time_faded + Time.deltaTime;
				for ( int i = 0; i < m_renderers.Length; i++ ) {
					m_renderers[i].material.SetFloat ("_Opacity", m_time_faded / m_fade_time);
				}
				for ( int i = 0; i < m_meshes.Length; i++ ) {
					m_meshes[i].material.SetFloat ("_Opacity", m_time_faded / m_fade_time);
				}
				if ( m_time_faded >= m_fade_time ) {
					m_time_faded = 0.0f;
					Teleported = false;
				}
			}
		}
	}
}