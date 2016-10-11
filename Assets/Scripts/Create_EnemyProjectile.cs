using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class Create_EnemyProjectile : StateMachineBehaviour {

		public Base_Enemy_Projectile Skill_projectile;

		override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			Skill_projectile.GetComponent<Base_EnemySkill_Update> ().m_boss = animator.GetComponentInParent<Enemy_Base> ().gameObject;
			Instantiate (Skill_projectile, Vector3.zero, Quaternion.identity);
		}
	}
}