using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Lightning : MonoBehaviour {
		LineRenderer lineRenderer;
		float length = 1.0f;
		public Transform start;
		public Transform end;
		public float duration = 3.0f;
		public float radius = 0.15f;
		public int numSegments = 12;
		public Color color = Color.white;
		public Vector3 startOffset;
		public Vector3 endOffset;
		public bool destroyStartOnDestroy = false;

		// Alpha decay
		public bool alphaDecay = false;
		public bool destroyOnAlphaDecay = true;
		public AnimationCurve alphaDecayCurve = new AnimationCurve (new Keyframe (0.0f, 1.0f), new Keyframe (3.0f, 0.0f));
		public float alphaDecaySpeed = 1.0f;
		float alphaCyclePosition = 0.0f;

		void Start () {
			lineRenderer = GetComponent<LineRenderer> ();

			if ( lineRenderer != null ) {
				lineRenderer.SetVertexCount (numSegments);
			}
		}

		void Update () {
			if ( start == null || end == null || lineRenderer == null )
				return;


			lineRenderer.SetColors (color, color);
			lineRenderer.SetVertexCount (numSegments);

			Vector3 startPosition = start.position + startOffset;
			Vector3 endPosition = end.position + endOffset;
			length = Vector3.Distance (startPosition, endPosition);

			lineRenderer.SetPosition (0, Vector3.zero);

			for ( int i = 1; i < numSegments - 1; ++i ) {
				float z = length / (float)(numSegments - 1) * (float)i;
				lineRenderer.SetPosition (i, new Vector3 (Random.Range (-radius, radius), Random.Range (-radius, radius), z));
			}

			lineRenderer.SetPosition (numSegments - 1, new Vector3 (0, 0, length));

			// Rotate towards end position
			Quaternion quat = new Quaternion ();
			quat.SetLookRotation (endPosition - startPosition, start.up);
			transform.rotation = quat;
			transform.position = startPosition;

			if ( alphaDecay ) {
				float a = alphaDecayCurve.Evaluate (alphaCyclePosition);
				alphaCyclePosition += Time.deltaTime * alphaDecaySpeed;
				color.a = a;

				if ( alphaCyclePosition >= alphaDecayCurve.keys[alphaDecayCurve.length - 1].time ) {
					if ( destroyStartOnDestroy ) {
						Destroy (start.gameObject);
					}

					Destroy (this.gameObject);
				}
			}
		}
	}
}