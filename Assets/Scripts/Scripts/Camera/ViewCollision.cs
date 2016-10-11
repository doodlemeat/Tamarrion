using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public abstract class ViewCollision {
		public enum CollisionClass {
			Collision,
			Trigger,
			Ignore,
			IgnoreTransparent
		}

		public abstract float Process (Vector3 cameraTarget, Vector3 cameraDirection, float distance);

		public static CollisionClass GetCollisionClass (Collider collider, string ignoreTag, string transparentTag) {
			CollisionClass collisionClass = CollisionClass.Collision;

			if ( collider.isTrigger ) {
				collisionClass = CollisionClass.Trigger;
			}
			else if ( collider.gameObject != null ) {
				if ( collider.gameObject.GetComponent<IgnoreCameraCollision> () || collider.gameObject.tag == ignoreTag ) {
					collisionClass = CollisionClass.Ignore;
				}
				else if ( collider.gameObject.GetComponent<TransparentCollision> () || collider.gameObject.tag == transparentTag ) {
					collisionClass = CollisionClass.IgnoreTransparent;
				}
			}

			return collisionClass;
		}
	}
}