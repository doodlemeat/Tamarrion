using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class PlayerMovement : MonoBehaviour {
		public static PlayerMovement instance;

		public float Gravity = 20.0f;
		public float RotationSpeed = 10.0f;
		public bool Inverted = false;
		public float StrafeSpeedMod = 0.5f;
		public float BackwardsSpeedMod = 0.5f;
		public float BaseMoveSpeed = 1.0f;

		[Header("Strafe rotation transforms")]
		public float RotationAdjustmentDegrees = 30;
		public List<Transform> RotationTransforms = new List<Transform>();

		public CharacterController Controller;

		private float currentMoveSpeed = 1.0f;
		private bool forceDirectionActive = false;
		private bool inMenu = false;
		private bool strafingLeft = false,
			strafingRight = false,
			movingBackwards = false;

		private List<string> rotateBlockers = new List<string>();
		private List<string> moveBlockers = new List<string>();

		private Animator animator;
		private Vector3 moveDirection;
		private Vector2 input;

		private PlayerStats playerStats;

		private Vector3 forcedMoveDirection = Vector3.zero;
		private bool freeRotationEnabled = false;
		private Vector3 freeRotationCameraStartPos;

		void Awake() {
			instance = this;
		}

		void Start() {
			if (Application.loadedLevelName == "main_menu") {
				inMenu = true;
				AddMoveBlock("main_menu_scene");
			}

			animator = GetComponentInChildren<Animator>();
			moveDirection = Vector3.zero;
			
			playerStats = GetComponent<PlayerStats>();
		}

		void /*Fixed*/Update() {
			if (inMenu)
				return;

			// If the player is dead, don't allow any movement
			if (Player.player.IsDead())
				return;

			Vector3 inputDirection = Vector3.zero;
			if (MoveEnabled())
				inputDirection = GetInputDirection();
			else
				inputDirection = new Vector3(0, 0, 0);

			CheckFreeRotation();

			Quaternion direction = transform.rotation;

			inputDirection.Normalize();
			moveDirection.x = inputDirection.x;
			moveDirection.z = inputDirection.z;

			forceDirectionActive = forcedMoveDirection != Vector3.zero;
			if (forceDirectionActive) {
				moveDirection.x = forcedMoveDirection.x;
				moveDirection.z = forcedMoveDirection.z;
			}

			// Scale the movement direction by the movement speed
			float movementSpeed = playerStats.m_stat["movement_speed"];
			moveDirection.x *= movementSpeed;
			moveDirection.z *= movementSpeed;
			float currentSpeed = new Vector2(moveDirection.x, moveDirection.z).magnitude;
			animator.SetFloat("Speed", currentSpeed);

			moveDirection.y -= Gravity * Time.deltaTime;

			// Set the desired rotation of the camera
			Vector3 rotation = (!freeRotationEnabled ? CameraController.instance.transform.forward : Controller.transform.forward);
			rotation.y = 0;

			if (!rotation.Equals(Vector3.zero)) {
				direction = Quaternion.LookRotation(rotation);
				transform.rotation = Quaternion.Lerp(transform.rotation, direction, RotationSpeed * Time.deltaTime);
			}

			UpdateAnimatorMoveVariables(input);

			if (MoveEnabled()) {
				currentMoveSpeed = BaseMoveSpeed;
				if (forceDirectionActive == false) {
					if (movingBackwards)
						currentMoveSpeed *= BackwardsSpeedMod;
					else if (strafingLeft || strafingRight)
						currentMoveSpeed *= StrafeSpeedMod;
				}

				Controller.Move(moveDirection * Time.deltaTime * currentMoveSpeed);
			}
			else
				Controller.Move(new Vector3(0.0f, moveDirection.y, 0.0f) * Time.deltaTime);
		}

		void CheckFreeRotation() {
			if (Input.GetButton("FreeRotation")) {
				if (!freeRotationEnabled) {
					AddMoveBlock("FreeRotation");
					freeRotationEnabled = true;
					freeRotationCameraStartPos = CameraController.instance.gameObject.transform.position;
				}
			}
			else if (freeRotationEnabled) {
				RemoveMoveBlock("FreeRotation");
				freeRotationEnabled = false;
				CameraController.instance.gameObject.transform.position = freeRotationCameraStartPos;
				CameraController.instance.gameObject.transform.LookAt(CameraController.instance.Target.transform.position);
			}
		}

		void LateUpdate() {
			RotateTransformsToLegRotation();
		}

		public void forceDirection(Vector3 forcedDirection) {
			forcedMoveDirection = forcedDirection;
			forcedMoveDirection.y = 0;
		}

		public Vector3 GetMoveDirection() {
			return moveDirection;
		}

		public Vector2 GetInput() {
			return input;
		}

		public bool IsMoving() {
			Vector3 direction = moveDirection;
			direction.y = 0;

			if (direction.magnitude > 0)
				return true;
			return false;
		}

		public Vector3 GetInputDirection() {
			if (Camera.main != null) {
				Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
				Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

				// Get input vector
				input.x = Input.GetAxisRaw("Horizontal") * (Inverted ? -1 : 1);
				input.y = Input.GetAxisRaw("Vertical") * (Inverted ? -1 : 1);

				return input.x * cameraRight + input.y * cameraForward;
			}

			return Vector3.zero;
		}

		void UpdateAnimatorMoveVariables(Vector3 relativeDirection) {
			SetStrafeLeft(IsStrafingLeft(relativeDirection));
			SetStrafeRight(IsStrafingRight(relativeDirection));
			SetBackwards(IsMovingBackwards(relativeDirection));
			UpdateStrafeAnimatorVariables(relativeDirection);
		}

		bool IsMovingForwards(Vector3 relativeDirection) {
			return (relativeDirection.y > 0);
		}

		bool IsStrafingLeft(Vector3 relativeDirection) {
			return (relativeDirection.x < 0);
		}

		bool IsStrafingRight(Vector3 relativeDirection) {
			return (relativeDirection.x > 0);
		}

		bool IsMovingBackwards(Vector3 relativeDirection) {
			return (relativeDirection.y < 0);
		}

		void SetStrafeLeft(bool state) {
			strafingLeft = state;
			//_animator.SetBool("MovingLeft", p_state);
		}

		void SetStrafeRight(bool state) {
			strafingRight = state;
			//_animator.SetBool("MovingRight", p_state);
		}

		void SetBackwards(bool state) {
			movingBackwards = state;
		}

		public void AddRotationBlock(string sourceName) {
			if (!rotateBlockers.Contains(sourceName))
				rotateBlockers.Add(sourceName);
		}

		public void RemoveRotationBlock(string sourceName) {
			rotateBlockers.Remove(sourceName);
		}

		public bool RotationEnabled() {
			return rotateBlockers.Count == 0;
		}

		public void AddMoveBlock(string sourceName) {
			//Debug.Log("move block: " + p_sourceName);

			if (!moveBlockers.Contains(sourceName))
				moveBlockers.Add(sourceName);
		}

		public void RemoveMoveBlock(string sourceName) {
			//Debug.Log("REMOVE move block: " + p_sourceName);

			moveBlockers.Remove(sourceName);
		}

		public bool MoveEnabled() {
			return moveBlockers.Count == 0;
		}

		void UpdateStrafeAnimatorVariables(Vector3 relativeDirection) {
			animator.SetBool("MovingLeft", (!IsMovingForwards(relativeDirection) && IsStrafingLeft(relativeDirection)));
			animator.SetBool("MovingRight", (!IsMovingForwards(relativeDirection) && IsStrafingRight(relativeDirection)));
			animator.SetBool("MovingBackwards", IsMovingBackwards(relativeDirection));
		}

		void RotateTransformsToLegRotation() {
			foreach (Transform trans in RotationTransforms) {
				if (strafingRight && !movingBackwards)
					trans.RotateAround(trans.position, Vector3.up, RotationAdjustmentDegrees);
				else if (strafingRight && movingBackwards)
					trans.RotateAround(trans.position, Vector3.up, -RotationAdjustmentDegrees);
				else if (strafingLeft && !movingBackwards)
					trans.RotateAround(trans.position, Vector3.up, -RotationAdjustmentDegrees);
				else if (strafingLeft && movingBackwards)
					trans.RotateAround(trans.position, Vector3.up, RotationAdjustmentDegrees);
			}
		}

		public Vector3 GetForcedDirection() {
			return forcedMoveDirection;
		}
	}
}
