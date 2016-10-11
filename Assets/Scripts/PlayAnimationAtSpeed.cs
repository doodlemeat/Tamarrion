using UnityEngine;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Animation))]

	public class PlayAnimationAtSpeed : MonoBehaviour {
		AnimationState animState;
		public float speed = 1f;
		public string animationName;

		void Start () {
			animState = GetComponent<Animation> ()[animationName];
			animState.speed = speed;
		}
	}
}