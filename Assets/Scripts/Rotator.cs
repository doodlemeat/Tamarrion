using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Rotator : MonoBehaviour {
		public float speed = 10f;


		void Update () {
			transform.Rotate (Vector3.back, speed * Time.deltaTime);
		}
	}
}