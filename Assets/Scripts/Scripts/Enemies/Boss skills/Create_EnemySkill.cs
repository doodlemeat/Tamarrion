using UnityEngine;
using System.Collections;

public class Create_EnemySkill : StateMachineBehaviour {

    public Base_EnemySkill_Update Skill_updater;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Skill_updater.GetComponent<Base_EnemySkill_Update>().m_boss = animator.GetComponentInParent<Enemy_Base>().gameObject;
        Instantiate(Skill_updater, Vector3.zero, Quaternion.identity);
    }
}