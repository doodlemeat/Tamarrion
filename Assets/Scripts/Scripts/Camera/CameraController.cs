using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class CameraController : MonoBehaviour {
        public static CameraController instance;
        public Transform Target;
        public float FOV = 60.0f;
        public float Distance = 4.0f;
        public float RotationSpeedX = 8.0f;
        public float RotationSpeedY = 5.0f;
        public float RotationYMax = 50.0f;
        public float RotationYMin = -30.0f;
        public float Spring = 0.0f;
        public float FollowCoef = 0.0f;
        public float HeadOffset = 1.0f;
        public float DefaultYRotation = 0.0f;
        public float AutoYRotation = 0.0f;
        public float m_mouseSensitivity = 0.5f;
        public Vector3 TargetOffset = Vector3.zero;

        bool _lockOntoTarget = false;
        bool _forceLockOntoTarget = false;

        bool rotationInput;
        float rotX;
        float rotY;
        float targetDistance;
        float targetVelocity;
        float collisionDistance;
        float rotationInputTimeout;
        float activateTimeout;
        Vector3 cameraTarget;
        Vector3 targetPos;
        Vector3 lastTargetPos;
        Vector3 springVelocity;
        PositionFilter targetFilter;
        CameraCollision collision;
        Camera _camera;

        PlayerMovement playerMovement;

        public void LockOntoTarget(bool value) {
            if (_forceLockOntoTarget == false)
                _lockOntoTarget = value;
        }

        public void SetLockTarget(Transform trans) {
            //LockTarget = trans;
        }

        void Awake() {
            instance = this;
        }

        void Start() {
            _camera = GetComponent<Camera>();

            if (Target) {
                cameraTarget = Target.position;
                lastTargetPos = Target.position;
                targetDistance = Distance;// (_camera.transform.position - Target.position).magnitude;

                targetFilter = new PositionFilter(10, 1.0f);
                targetFilter.Reset(Target.position);
            }

            collision = CameraCollision.Instance;

            targetVelocity = 0.0f;
            playerMovement = Player.player.GetComponent<PlayerMovement>();

            //startTime = Time.time;
        }

        void OnActivate() {
            targetFilter.Reset(Target.position);
            lastTargetPos = Target.position;
            targetVelocity = 0.0f;
            activateTimeout = 1.0f;
        }

        void RotateCamera() {
            if (Input.GetButton("ShowMouseCursor") || !playerMovement.RotationEnabled())
                return;

            Vector2 rotDistance = new Vector2(Input.GetAxis("RightStick_Horizontal"), Input.GetAxis("RightStick_Vertical"));
            Vector2 mousePosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            mousePosition *= m_mouseSensitivity;
            rotDistance += mousePosition;

            if (Settings.instance) {
                if (Settings.instance.Inverted_Xaxis)
                    rotDistance.x *= -1;
                if (Settings.instance.Inverted_Yaxis)
                    rotDistance.y *= -1;
            }

            rotationInput = rotDistance.sqrMagnitude > Mathf.Epsilon;
            rotationInputTimeout += Time.deltaTime;

            if (rotationInput) {
                rotationInputTimeout = 0.0f;
            }

            Math.ToSpherical(_camera.transform.forward, out rotX, out rotY);

            if (_lockOntoTarget) return;
            rotY += RotationSpeedY * rotDistance.y * Time.deltaTime;
            rotX += RotationSpeedX * rotDistance.x * Time.deltaTime;

            // Clamp the rotation on x-axis
            float yAngle = -rotY * Mathf.Rad2Deg;

            if (yAngle > RotationYMax)
                rotY = -RotationYMax * Mathf.Deg2Rad;

            if (yAngle < RotationYMin)
                rotY = -RotationYMin * Mathf.Deg2Rad;
        }

        void UpdateFollow() {
            Vector3 targetDiff = targetPos - lastTargetPos;
            targetDiff.y = 0.0f;

            float targetDiffLength = Mathf.Clamp(targetDiff.magnitude, 0.0f, 5.0f);

            if (Time.deltaTime > Mathf.Epsilon)
                targetVelocity = targetDiffLength / Time.deltaTime;
            else
                targetVelocity = 0.0f;

            if (playerMovement.IsMoving()) {
                Vector2 runDirection = playerMovement.GetInput();
                runDirection.Normalize();

                float deltaAngle = Mathf.Atan2(runDirection.x, runDirection.y);
                float sined = Mathf.Sin(deltaAngle);
                float rt = Mathf.Clamp01(rotationInputTimeout);
                float rotDelta = sined * Time.deltaTime * FollowCoef * targetVelocity * 0.2f * rt;
                rotX += rotDelta;
            }
        }

        void UpdateFOV() {
            _camera.fieldOfView = FOV;
        }

        void UpdateDistance() {
            Vector3 newTarget = targetPos + GetOffsetPos();
            //Vector3 newTarget = Target.transform.position;

            //journeyLength = Vector3.Distance(newTarget, GetTargetHeadPos());
            //float distCovered = (Time.time - startTime) * 1.0f;
            //float fracJourney = distCovered / journeyLength;

            cameraTarget = newTarget;
            //cameraTarget = Math.LerpS(newTarget, GetOffsetPos(), 0.05f);
            //cameraTarget = GetTargetHeadPos();
        }

        void UpdateDirection() {
            activateTimeout -= Time.deltaTime;

            if (activateTimeout > 0.0f) {
                //float yRot = DefaultYRotation;
                //rotY = -yRot * Mathf.Deg2Rad;
                //rotX = Mathf.Atan2(Target.forward.x, Target.forward.z);
            }

            Vector3 direction;
            Math.ToCartesian(rotX, rotY, out direction);

            if (_lockOntoTarget || _forceLockOntoTarget) {
                //Vector3 newRotation = Quaternion.LookRotation(FirstBoss.instance.transform.position - transform.position).eulerAngles;
                //newRotation.x = 0;
                //_camera.transform.forward = FirstBoss.instance.transform.position - transform.position; // = Quaternion.Euler(newRotation); // Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 0.05f);
            }
            else
                _camera.transform.forward = direction;

            _camera.transform.position = cameraTarget - _camera.transform.forward * targetDistance;

            lastTargetPos = targetPos;
        }

        Vector3 GetOffsetPos() {
            return TargetOffset;

            //Vector3 offset = TargetOffset;

            //Vector3 cameraForwardXZ = Math.VectorXZ(_camera.transform.forward);
            //Vector3 cameraRightXZ = Math.VectorXZ(_camera.transform.right);
            //Vector3 cameraUp = Vector3.up;

            //return cameraForwardXZ * offset.z +
            //       cameraRightXZ * offset.x +
            //       cameraUp * offset.y;
        }

        void UpdateYRotation() {
            if (!rotationInput && targetVelocity > 0.1f) {
                float yAngle = -rotY * Mathf.Rad2Deg;
                float targetYRot = DefaultYRotation;
                float rt = Mathf.Clamp01(rotationInputTimeout);
                float t = Mathf.Clamp01(targetVelocity * AutoYRotation * Time.deltaTime) * rt;
                yAngle = Mathf.Lerp(yAngle, targetYRot, t);
                rotY = -yAngle * Mathf.Deg2Rad;
            }
        }

        void LateUpdate() {
            UpdateFOV();
            RotateCamera();
            UpdateFollow();
            UpdateDistance();
            UpdateYRotation();
            UpdateDirection();

            if (CameraEffectManager.Instance)
                CameraEffectManager.Instance.PostUpdate();
            if (_lockOntoTarget || _forceLockOntoTarget)
                _camera.transform.forward = Valac.instance.transform.position - transform.position;

            //Debug.Log("distance: " + (transform.position - Target.transform.position + TargetOffset).magnitude);
        }

        void UpdateCollision() {
            Vector3 newTarget = targetPos + GetOffsetPos();
            collision.Process(newTarget, newTarget, _camera.transform.forward, Distance, out collisionDistance);
            //targetDistance = Math.Lerp(targetDistance, collisionDistance, targetDistance > collisionDistance ? 1.0f : 0.05f);
            targetDistance = Math.Lerp(Distance, collisionDistance, Distance > collisionDistance ? 1.0f : 0f);
        }

        void FixedUpdate() {
            targetFilter.AddSample(Target.position);
            UpdateCollision();

            targetPos = Vector3.SmoothDamp(targetPos, targetFilter.GetValue(), ref springVelocity, Spring);
            //targetPos = Vector3.SmoothDamp(targetPos, Target.position, ref springVelocity, Spring);
        }

        public Camera GetCamera() {
            return _camera;
        }

        public void ForceLockOnTarget(Transform p_transform) {
            SetLockTarget(p_transform);
            _forceLockOntoTarget = true;
        }

        public void RemoveForceLock() {
            _forceLockOntoTarget = false;
        }
    }
}