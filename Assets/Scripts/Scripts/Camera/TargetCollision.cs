using UnityEngine;
using System.Collections;

public class TargetCollision 
{
	RayHitComparer rayHitComparer = new RayHitComparer();

	public float CalculateTarget(Vector3 targetHead, Vector3 cameraTarget)
	{
		float newTarget = 1.0f;

		Vector3 rayDir = (cameraTarget - targetHead).normalized;
		Ray ray = new Ray(targetHead, rayDir);

		RaycastHit[] hits = Physics.RaycastAll(ray, rayDir.magnitude + 0.5f);
		System.Array.Sort(hits, rayHitComparer);

		float nearest = Mathf.Infinity;
		bool rayHit = false;

		foreach (RaycastHit hit in hits)
		{
			ViewCollision.CollisionClass collisionClass = ViewCollision.GetCollisionClass(hit.collider, "IgnoreCollision", "TransparentCollision");

			if(hit.distance < nearest && collisionClass == ViewCollision.CollisionClass.Collision)
			{
				nearest = hit.distance;
				newTarget = nearest;
				rayHit = true;
			}
		}

		if (rayHit)
		{
			return Mathf.Clamp01(newTarget / (targetHead - cameraTarget).magnitude);
		}

		return 1.0f;
	}

	public class RayHitComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
		}
	}
}
