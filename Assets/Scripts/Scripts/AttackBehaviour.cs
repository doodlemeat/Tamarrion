using UnityEngine;
using System.Collections;

public class AttackBehaviour : StateMachineBehaviour {

	/*public AudioClip attackSound;
	private GameObject player;
	private CombatStats combatStats;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		player = Player.player.gameObject;
		combatStats = player.GetComponent<PlayerStats>();
		Ray ray = new Ray(player.transform.position, player.transform.forward);
		RaycastHit hitInfo = new RaycastHit();
		if (Physics.Raycast(ray, out hitInfo, combatStats.AttackRange)) {
			Debug.Log("HIT");
		}
	}*/
}