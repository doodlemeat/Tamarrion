using UnityEngine;
using System.Collections;

namespace Tamarrion {
	public class SkillProjector : MyMonoBehaviour {
        public float FromPlayerRange = 2.5f;

        private Projector projector;

		void Start() {
			projector = GetComponent<Projector>();
		}

        public float GetMaxDistance() {
            return projector.farClipPlane;
        }

        /*
         * Shows the projection area of the skill in the world
         */
        public void ShowSkillShape() {
            gameObject.SetActive(true);
        }

        /*
         * Hides the projection area of the skill in the world
         */
        public void HideSkillShape() {
            gameObject.SetActive(false);
        }

        /*
         * Colorize the skill projector to match the element of our spell and set the method of placement
         */
        public void SetNewSkillShape(FSSkillBase currentSkill) {
            projector.orthographic = true;
            projector.aspectRatio = (float) currentSkill.shapeTexture.width / (float) currentSkill.shapeTexture.height;
            projector.orthographicSize = currentSkill.shapeSize * 0.5f;
            projector.material.SetColor("_Color", currentSkill.Element.Color);
            projector.material.SetTexture("_ShadowTex", currentSkill.shapeTexture);
        }

        /*
         * Place the skill projector at the correct position depending on the placement type of the current skill
         */
        public void UpdatePositionToPlacing(FSSkillPlacing placement, GameObject caster, FSSkillBase skill) {
			if (placement == FSSkillPlacing.FS_Placing_FreePlace)
				DetermineFreeplaceTargetPosition(caster, skill);
			else if (placement == FSSkillPlacing.FS_Placing_FromPlayer) {
				transform.localRotation = (Quaternion.Euler(90, 0, 0));
				transform.localPosition = (Vector3.up * (projector.farClipPlane * 0.5f)) + new Vector3(0, 0, GetClosestDistanceToShapeCenter(skill));
			}
			else if (placement == FSSkillPlacing.FS_Placing_PlayerIsCenter) {
				transform.localRotation = (Quaternion.Euler(90, 0, 0));
				transform.localPosition = (Vector3.up * (projector.farClipPlane * 0.5f));
			}
		}

		private void DetermineFreeplaceTargetPosition(GameObject caster, FSSkillBase skill) {
            CameraController cameraController = caster.GetComponentInChildren<FSSkillUser>().cameraController;

			if (SetProjectionViaRaycast(caster, caster.transform.position + new Vector3(0, 1, 0), cameraController.transform.forward, skill.range)) {
				ShowSkillShape();
			}
			else if (SetProjectionViaRaycast(caster, caster.transform.position + new Vector3(0, 1, 0) + cameraController.transform.forward * skill.range, Vector3.down, 30.0f)) {
				ShowSkillShape();
			}
			else {
				HideSkillShape();
			}
		}

		private float GetClosestDistanceToShapeCenter(FSSkillBase skill) {
			if (skill != null)
				return FromPlayerRange + skill.shapeSize * 0.5f;

            return FromPlayerRange;
		}

		private bool SetProjectionViaRaycast(GameObject caster, Vector3 p_startPos, Vector3 p_direction, float p_maxRange) {
			Ray ray = new Ray(p_startPos, p_direction);
			Debug.DrawRay(p_startPos, p_direction * p_maxRange, Color.cyan, 0.2f);
			RaycastHit[] hitInfo = Physics.RaycastAll(ray, p_maxRange);

			if (hitInfo.Length > 0) {
				float closestDistance = (hitInfo[0].point - (caster.transform.position + new Vector3(0, 1, 0))).magnitude;
				foreach (RaycastHit hit in hitInfo) {
					if (hit.collider.gameObject.tag == "IgnoreFreeshotProjecting")
						continue;

					float distanceToHit = (hit.point - p_startPos).magnitude;
					if (distanceToHit <= closestDistance) {
						closestDistance = distanceToHit;
						transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
						transform.position = hit.point + (transform.up * (projector.farClipPlane * 0.5f));
						transform.rotation = transform.rotation * (Quaternion.Euler(90, 0, 0));
					}
				}
				return true;
			}

			return false;
		}
	}
}
