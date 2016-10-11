using UnityEngine;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Projector))]

	public class ProjectorFacingPoint : MonoBehaviour {
		public float distanceFromOrigin = 1f;
		public float fadeTime = 0.3f;
		public Vector3 targetPoint = Vector3.zero;
		Quaternion rotationOffset;
		Projector proj;
		bool lerpColorOn = false;
		bool lerpColorOff = false;
		Color defaultColor;
		Color transparentColor;

		TopgunTimer fadeTimer = new TopgunTimer ();

		void Start () {
			proj = GetComponent<Projector> ();
			rotationOffset = transform.rotation;

			Color shaderColor = proj.material.GetColor ("_Color");
			defaultColor = new Color (shaderColor.r, shaderColor.g, shaderColor.b, 1);
			transparentColor = new Color (shaderColor.r, shaderColor.g, shaderColor.b, 0);

			TurnOff (true);
		}

		void Update () {
			proj.transform.localPosition = Vector3.zero;
			proj.transform.LookAt (targetPoint);
			proj.transform.rotation *= rotationOffset;
			Vector3 offsetTowardsTarget = (targetPoint - transform.position).normalized * distanceFromOrigin;
			Vector3 verticalProjectorOffset = (Vector3.up * (proj.farClipPlane * 0.5f));
			proj.transform.position = transform.parent.position + verticalProjectorOffset + offsetTowardsTarget;

			if ( lerpColorOn || lerpColorOff )
				LerpColor ();
		}

		void LerpColor () {
			if ( lerpColorOn && !fadeTimer.IsComplete ) {
				fadeTimer.Update ();
				proj.material.SetColor ("_Color", Color.Lerp (defaultColor, transparentColor, fadeTimer.PercentComplete ()));
				if ( fadeTimer.IsComplete ) {
					lerpColorOn = false;
				}
			}
			else if ( lerpColorOff && !fadeTimer.IsComplete ) {
				fadeTimer.Update ();
				proj.material.SetColor ("_Color", Color.Lerp (transparentColor, defaultColor, fadeTimer.PercentComplete ()));
				if ( fadeTimer.IsComplete ) {
					lerpColorOff = false;
				}
			}
		}

		public void TurnOn (bool p_instant = false) {
			lerpColorOff = false;
			if ( !p_instant ) {
				lerpColorOn = true;
				fadeTimer.StartTimerBySeconds (fadeTime);
			}
			else
				proj.material.SetColor ("_Color", defaultColor);
		}

		public void TurnOff (bool p_instant = false) {
			lerpColorOn = false;
			if ( !p_instant ) {
				lerpColorOff = true;
				fadeTimer.StartTimerBySeconds (fadeTime);
			}
			else
				proj.material.SetColor ("_Color", transparentColor);
		}
	}
}