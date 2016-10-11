using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class RemoveObjectAtStart : MonoBehaviour {
		public enum ETask {
			Disable,
			Destroy,
		};

		public float Delay = 0;
		public ETask Task = ETask.Disable;

		void Start () {
			if ( Delay == 0 ) {
				if ( Task == ETask.Disable )
					enabled = false;
				else if ( Task == ETask.Destroy )
					Destroy (gameObject);
			}
		}

		public void Update () {
			Delay -= Time.deltaTime;
			if ( Delay <= 0 ) {
				if ( Task == ETask.Disable )
					enabled = false;
				else if ( Task == ETask.Destroy )
					Destroy (gameObject);
			}
		}
	}
}