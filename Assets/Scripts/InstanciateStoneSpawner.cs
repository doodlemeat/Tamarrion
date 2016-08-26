using UnityEngine;
using System.Collections;

public class InstanciateStoneSpawner : StateMachineBehaviour {

    public GameObject stone_spawner;
    
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Instantiate(stone_spawner, Valac.instance.transform.position, Quaternion.identity);
	}
}