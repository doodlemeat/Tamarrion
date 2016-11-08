using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class SpawnOrbFromUrn : MyMonoBehaviour {
		private readonly Vector3 Offset = new Vector3(0, 1, 0);

		public GameObject healthOrb;
		public float[] probability = new float[System.Enum.GetValues(typeof(Difficulty)).Length];

		void Start () {
			if (Random.Range(0.0f, 100.0f) < probability[(int) DifficultyManager.current]) {
				if ( healthOrb ) {
					Instantiate (healthOrb, transform.position + Offset, Quaternion.identity);
				}
			}
		}
	}
}
