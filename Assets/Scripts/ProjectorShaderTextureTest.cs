using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class ProjectorShaderTextureTest : MonoBehaviour {
		public Texture2D testTexture1;
		public float firstTextureHeight = 2;
		public FSSkillPlacing firstPlacing = FSSkillPlacing.FS_Placing_FreePlace;
		public Texture2D testTexture2;
		public float secondTextureHeight = 2;
		public FSSkillPlacing secondPlacing = FSSkillPlacing.FS_Placing_FromPlayer;
		public Projector testProjector;

		FSSkillPlacing currentPlacingMethod = FSSkillPlacing.FS_Placing_FromPlayer;
		public float fromPlayerRange = 2.5f;

		void Start () {
			ActivateFirstTexture ();
		}

		void Update () {
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				Debug.Log ("pressed 1");
				if ( testTexture1 && testProjector )
					ActivateFirstTexture ();

				UpdatePositionToPlacing ();
			}
			else if ( Input.GetKeyDown (KeyCode.Alpha2) ) {
				Debug.Log ("pressed 2");
				if ( testTexture2 && testProjector )
					ActivateSecondTexture ();

				UpdatePositionToPlacing ();
			}

			if ( currentPlacingMethod == FSSkillPlacing.FS_Placing_FreePlace )
				UpdatePositionToPlacing ();
		}

		void ActivateFirstTexture () {
			testProjector.material.SetTexture ("_ShadowTex", testTexture1);
			testProjector.orthographicSize = firstTextureHeight;
			testProjector.aspectRatio = (float)testTexture1.width / (float)testTexture1.height;
			currentPlacingMethod = firstPlacing;
		}

		void ActivateSecondTexture () {
			testProjector.material.SetTexture ("_ShadowTex", testTexture2);
			testProjector.orthographicSize = secondTextureHeight;
			testProjector.aspectRatio = (float)testTexture2.width / (float)testTexture2.height;
			currentPlacingMethod = secondPlacing;
		}

		void UpdatePositionToPlacing () {
			if ( currentPlacingMethod == FSSkillPlacing.FS_Placing_FreePlace )
				transform.localPosition = new Vector3 (0, 1.5f, 4.0f);
			else if ( currentPlacingMethod == FSSkillPlacing.FS_Placing_FromPlayer )
				transform.localPosition = new Vector3 (0, 1.5f, fromPlayerRange);
			else if ( currentPlacingMethod == FSSkillPlacing.FS_Placing_PlayerIsCenter )
				transform.localPosition = new Vector3 (0, 1.5f, 0);
		}
	}
}