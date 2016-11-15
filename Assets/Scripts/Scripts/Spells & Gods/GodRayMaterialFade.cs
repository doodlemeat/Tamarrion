using UnityEngine;
using System.Collections;
namespace Tamarrion {
	[RequireComponent (typeof (Renderer))]

	public class GodRayMaterialFade : MonoBehaviour {
		public float fadeTime = 0.5f;
		Timer fadeTimer = new Timer();
		bool done = false;
		Renderer rend;

		void Start () {
			rend = GetComponent<Renderer> ();
			SetSeqSelectValue (0f);
			fadeTimer.Start(fadeTime);
		}

		void Update () {
			if ( done )
				return;

			fadeTimer.Update ();
			SetSeqSelectValue (1-fadeTimer.Progress());

			if ( fadeTimer.IsFinished ) {
				SetSeqSelectValue (0f);
				done = true;
			}
		}

		void SetSeqSelectValue (float p_value) {
			rend.material.SetFloat ("_SeqSelect", p_value);
		}
	}
}