using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class OrbSpawn : MonoBehaviour {
		GameObject _orb;

		void Start () {

		}

		void Update () {

		}

		public void SetOrb (GameObject orbObject) {
			_orb = orbObject;
		}

		public bool HasOrb () {
			return _orb;
		}
	}
}