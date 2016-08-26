using UnityEngine;
using System.Collections;

public class Boss_StartUsingSkill : StateMachineBehaviour {
    public bool blockMovement = true, blockRotation = true;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (blockMovement)
            Valac.instance.GetComponent<Enemy_Stats>().Add_Modifier("start_skill_movement", "movement_speed", 0.0f, 0.0f);
        if (blockRotation)
            Valac.instance.GetComponent<Enemy_Stats>().Add_Modifier("start_skill_rotation", "rotation_speed", 0.0f, 0.0f);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (blockMovement)
            Valac.instance.GetComponent<Enemy_Stats>().Remove_Modifier("start_skill_movement");
        if (blockRotation)
            Valac.instance.GetComponent<Enemy_Stats>().Remove_Modifier("start_skill_rotation");
	}
}