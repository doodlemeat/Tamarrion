using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class DestructibleObject : MonoBehaviour {
		public GameObject DestroyedObject;
		public GameObject ParticleSys;
		public GameObject AudioObject;
		public float DestroyMagnitude = 2;
		public Vector3 PositionAdjustment = new Vector3 ();
		public Vector3 RotationAdjustment = new Vector3 ();
		public bool Active = true;
		public bool ScaleBrokenWithWhole = true;

		void Start () {
			foreach ( Collider col in Valac.instance.gameObject.GetComponentsInChildren<SphereCollider> () ) {
				Physics.IgnoreCollision (col, gameObject.GetComponent<Collider> ());
			}
		}

		void OnCollisionEnter (Collision collision) {
			if ( !Active )
				return;

			if ( collision.relativeVelocity.magnitude > DestroyMagnitude ) {
				DestroyIt ();
			}
		}

		public void DestroyIt () {
			if ( AudioObject ) {
				Instantiate (AudioObject, gameObject.transform.position, gameObject.transform.rotation);
			}
			if ( ParticleSys ) {
				GameObject obj = (GameObject)Instantiate (ParticleSys, gameObject.transform.position + new Vector3 (0, 0.5f * gameObject.transform.localScale.y, 0), gameObject.transform.rotation);
				obj.transform.localScale = gameObject.transform.localScale;
			}
			if ( DestroyedObject ) {
				Transform destTrans = gameObject.transform;
				destTrans.position = gameObject.transform.position + PositionAdjustment;
				destTrans.Rotate (RotationAdjustment.x, RotationAdjustment.y, RotationAdjustment.z, Space.Self);

				GameObject obj = (GameObject)Instantiate (DestroyedObject, destTrans.position, destTrans.rotation);
				if ( ScaleBrokenWithWhole )
					obj.transform.localScale = gameObject.transform.localScale;
				foreach ( Rigidbody child in obj.GetComponentsInChildren<Rigidbody> () ) {
					Physics.IgnoreCollision (gameObject.GetComponent<Collider> (), child.gameObject.GetComponent<Collider> ());
					child.mass *= gameObject.transform.localScale.y;
					foreach ( Collider col in Valac.instance.gameObject.GetComponentsInChildren<SphereCollider> () ) {
						Physics.IgnoreCollision (child.gameObject.GetComponent<Collider> (), col);
					}
				}
			}
			Destroy (gameObject);
		}
	}
}