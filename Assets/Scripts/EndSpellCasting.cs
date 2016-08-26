using UnityEngine;
using System.Collections;

public class EndSpellCasting : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PlayerAttack.instance.RemoveAttackBlock("spell_cast");
        animator.SetBool("Cast", false);
        animator.SetBool("Looping spell", false);
        animator.SetBool("Cast defensive", false);
        animator.SetBool("Cast offensive", false);
    }
}
