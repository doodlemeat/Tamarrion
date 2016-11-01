using UnityEngine;
using System.Collections;
using System;

namespace Tamarrion {
	public class FSSkillBackstab : FSSkillBase {
		[Header("Backstab")]
		private GameObject player;

		public override void PerformStart() {
			Debug.Log("START");
			if (Evade.instance) {
				Evade.instance.CancelEvade();
				Evade.instance.AddEvadeBlock("skill_backstab");
			}

			player = GameObject.FindWithTag("Player");
			Enemy_Base closestEnemy = FindNearestEnemy();
			TeleportToEnemy(closestEnemy);

			PlayerCombat.instance.StartCoroutine(PlayerCombat.instance.AttackAfter(AttackType.Physical, 0.3f));
		}

		public override void PerformEnd() {
			if (Evade.instance)
				Evade.instance.RemoveEvadeBlock("skill_backstab");
		}

		private Enemy_Base FindNearestEnemy() {
			float closest = range;
			Enemy_Base closestEnemy = null;

			foreach (Enemy_Base enemy in Enemy_List.Enemies) {
				float dist = Vector3.Distance(player.transform.position, enemy.transform.position);

				if (dist < closest) {
					closest = dist;
					closestEnemy = enemy;
				}
			}
			return closestEnemy;
		}

		private void TeleportToEnemy(Enemy_Base enemy) {
			Vector3 enemyPos = enemy.transform.position;
			Vector3 offset = enemy.transform.forward * -1.0f;
			Vector3 newPosition = enemyPos + offset;

			player.transform.position = newPosition;

			CameraController.instance.transform.rotation = Quaternion.LookRotation(enemy.transform.forward);
		}

		public override void ApplySkillEffect() {
			
			//throw new NotImplementedException();
		}

		public override void SkillEnd() {
			//throw new NotImplementedException();
		}
	}
}
