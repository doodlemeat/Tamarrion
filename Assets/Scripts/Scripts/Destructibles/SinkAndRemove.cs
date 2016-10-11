using UnityEngine;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Rigidbody))]

	public class SinkAndRemove : MonoBehaviour {
		public float SinkSpeed = 1;
		public float SinkDelay = 0f;
		public float DestroyDelayAfterSink = 2f;
		public bool WaitForIdleRigidBody = true;

		bool sinkHasBegun = false;
		TopgunTimer sinkTimer = new TopgunTimer ();
		TopgunTimer destroyTimer = new TopgunTimer ();
		Rigidbody rigidBody;

		void Start () {
			rigidBody = GetComponent<Rigidbody> ();
			sinkTimer.StartTimerBySeconds (SinkDelay);
			destroyTimer.StartTimerBySeconds (DestroyDelayAfterSink);
		}

		void Update () {
			Sink ();
			CheckDestroy ();
		}

		void Sink () {
			if ( !sinkHasBegun && WaitForIdleRigidBody && rigidBody.velocity.magnitude > 0f )
				return;

			if ( sinkHasBegun ) {
				transform.position = transform.position + Vector3.down * SinkSpeed * Time.deltaTime;
			}
			else {
				sinkTimer.Update ();
				if ( sinkTimer.IsComplete ) {
					StartSink ();
				}
			}
		}

		void StartSink () {
			rigidBody.detectCollisions = false;
			rigidBody.useGravity = false;
			sinkHasBegun = true;
		}

		void CheckDestroy () {
			if ( !sinkHasBegun )
				return;

			destroyTimer.Update ();
			if ( destroyTimer.IsComplete ) {
				Destroy (gameObject);
			}
		}
	}
}