using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class Instansiate_Particle : StateMachineBehaviour {

		public ParticleSystem Particle;
		protected ParticleSystem m_particleinstance;
		public Vector3 position, particle_rotation;

		override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			m_particleinstance = (ParticleSystem)Instantiate (Particle, position + Valac.instance.transform.position, Valac.instance.transform.rotation);
			m_particleinstance.transform.rotation *= Quaternion.Euler (particle_rotation);
		}
	}
}