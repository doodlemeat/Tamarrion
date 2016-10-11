using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class Enemy_List : MonoBehaviour {
		public static List<Enemy_Base> Enemies = new List<Enemy_Base> ();

		public static void AddEnemyToList (Enemy_Base p_enemy) {
			Enemies.Add (p_enemy);
		}

		public static void RemoveEnemyFromList (Enemy_Base p_enemy) {
			Enemies.Remove (p_enemy);
		}

		public static bool GameObjectIsEnemy (GameObject p_obj) {
			return p_obj.GetComponent<Enemy_Base> ();
		}

		public static bool GameObjectsParentIsEnemy (GameObject p_obj) {
			return (p_obj.transform.parent && p_obj.transform.parent.GetComponent<Enemy_Base> ());
		}
	}
}