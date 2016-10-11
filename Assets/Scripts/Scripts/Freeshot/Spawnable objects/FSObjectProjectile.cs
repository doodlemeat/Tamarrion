using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class FSObjectProjectile : MonoBehaviour {
		public FSSkillShape shape = FSSkillShape.FS_Shape_Box;
		public float duration = 0;
		public float range = 0;

		TopgunTimer durationTimer = new TopgunTimer ();
		Vector3 startPosition;

		virtual public void Start () {
			if ( duration <= 0 )
				Destroy (gameObject);

			startPosition = transform.position;
		}

		virtual public void Update () {
			durationTimer.Update ();
			if ( durationTimer.IsComplete )
				Destroy (gameObject);

			if ( (startPosition - transform.position).magnitude >= range )
				Destroy (gameObject);
		}
	}
}