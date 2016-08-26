using UnityEngine;
using System;
using System.Collections;

public class SimpleCollision : ViewCollision 
{
	RayHitComparer rayHitComparer = new RayHitComparer();

	public override float Process(Vector3 cameraTarget, Vector3 cameraDirection, float distance)
	{
		float targetDistance = distance;
		float nearest = Mathf.Infinity;

		Ray ray = new Ray();
		ray.origin = cameraTarget;
		ray.direction = -cameraDirection;

		RaycastHit[] hits = Physics.RaycastAll(ray, distance);

		Array.Sort(hits, rayHitComparer);


		foreach(RaycastHit hit in hits)
		{
			CollisionClass collisionClass = GetCollisionClass(hit.collider, "IgnoreCollision", "TransparentCollision");

			if(hit.distance < nearest && collisionClass == CollisionClass.Collision)
			{
				nearest = hit.distance;
				targetDistance = nearest;
			}

			if(collisionClass == CollisionClass.IgnoreTransparent)
			{
				// TODO: Update transparency on object
			}
		}

		return Mathf.Clamp(targetDistance, 0.1f/* TODO: Put min distance in a variable */, distance);
	}

	public class RayHitComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
		}
	}
}
