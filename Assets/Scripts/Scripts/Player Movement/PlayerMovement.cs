using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float _gravity = 20.0f;
    public float _rotationSpeed = 10.0f;
    public bool _inverted = false;
    public float m_strafeSpeedMod = 0.5f;
    public float m_backwardsSpeedMod = 0.5f;
    public float m_baseMoveSpeed = 1.0f;

    [Header("Strafe rotation transforms")]
    public float rotationAdjustmentDegrees = 30;
    public List<Transform> rotationTransforms = new List<Transform>();

    float m_currentMoveSpeed = 1.0f;
    bool m_forceDirectionActive = false;
    bool InMenu = false;
    bool m_strafingLeft = false,
        m_strafingRight = false,
        m_movingBackwards = false;

    List<string> rotateBlockers = new List<string>();
    List<string> moveBlockers = new List<string>();

    Animator _animator;
    Vector3 _moveDirection;
    Vector2 _input;
    Vector3 _inputDirection;
    public CharacterController _controller;
    PlayerStats _playerStats;

    Vector3 forcedMoveDirection = Vector3.zero;
    bool m_freeRotationEnabled = false;
    Vector3 m_freeRotationCameraStartPos;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (Application.loadedLevelName == "main_menu")
        {
            InMenu = true;
            AddMoveBlock("main_menu_scene");
        }

        _animator = Player.player.GetComponentInChildren<Animator>();
        _moveDirection = Vector3.zero;
        _inputDirection = Vector2.zero;
        _playerStats = Player.player.GetComponent<PlayerStats>();
    }

    void /*Fixed*/Update()
    {
        if (InMenu)
            return;

        if (PlayerStats.instance.m_stat["health"] <= 0)
            return;

        if (MoveEnabled())
            _inputDirection = GetInputDirection();
        else
            _inputDirection = new Vector3(0, 0, 0);

        CheckFreeRotation();

        Quaternion direction = transform.rotation;

        _moveDirection.x = _inputDirection.x;
        _moveDirection.z = _inputDirection.z;

        _moveDirection.y -= _gravity * Time.deltaTime;

        m_forceDirectionActive = forcedMoveDirection != Vector3.zero;
        if (m_forceDirectionActive)
        {
            _moveDirection.x = forcedMoveDirection.x;
            _moveDirection.z = forcedMoveDirection.z;
        }

        Vector2 XZ_plane = new Vector2(_moveDirection.x, _moveDirection.z);
        XZ_plane.Normalize();
        XZ_plane *= _playerStats.m_stat["movement_speed"];
        _moveDirection.x = XZ_plane.x;
        _moveDirection.z = XZ_plane.y;

        Vector3 rotation_XZplane = (!m_freeRotationEnabled ? CameraController.instance.transform.forward : _controller.transform.forward);
        rotation_XZplane.y = 0;

        if (!rotation_XZplane.Equals(Vector3.zero))
        {
            direction = Quaternion.LookRotation(rotation_XZplane);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, _rotationSpeed * Time.deltaTime);
        }
        
        _animator.SetFloat("Speed", XZ_plane.magnitude);

        UpdateAnimatorMoveVariables(_input);

        if (MoveEnabled())
        {
            m_currentMoveSpeed = m_baseMoveSpeed;
            if (m_forceDirectionActive == false)
            {
                if (m_movingBackwards)
                    m_currentMoveSpeed *= m_backwardsSpeedMod;
                else if (m_strafingLeft || m_strafingRight)
                    m_currentMoveSpeed *= m_strafeSpeedMod;
            }

            _controller.Move(_moveDirection * Time.deltaTime * m_currentMoveSpeed);
        }
        else
            _controller.Move(new Vector3(0.0f, _moveDirection.y, 0.0f) * Time.deltaTime);
    }

    void CheckFreeRotation()
    {
        if (Input.GetButton("FreeRotation"))
        {
            if (!m_freeRotationEnabled)
            {
                AddMoveBlock("FreeRotation");
                m_freeRotationEnabled = true;
                m_freeRotationCameraStartPos = CameraController.instance.gameObject.transform.position;
            }
        }
        else if (m_freeRotationEnabled)
        {
            RemoveMoveBlock("FreeRotation");
            m_freeRotationEnabled = false;
            CameraController.instance.gameObject.transform.position = m_freeRotationCameraStartPos;
            CameraController.instance.gameObject.transform.LookAt(CameraController.instance.Target.transform.position);
        }
    }

    void LateUpdate()
    {
        RotateTransformsToLegRotation();
    }

    public void forceDirection(Vector3 forcedDirection)
    {
        forcedMoveDirection = forcedDirection;
        forcedMoveDirection.y = 0;
    }

    public Vector3 GetMoveDirection()
    {
        return _moveDirection;
    }

    public Vector2 GetInput()
    {
        return _input;
    }

    public bool IsMoving()
    {
        Vector3 direction = _moveDirection;
        direction.y = 0;

        if (direction.magnitude > 0)
            return true;
        return false;
    }

    public Vector3 GetInputDirection()
    {
		if ( Camera.main != null ) {
			Vector3 cameraForward = Vector3.Scale (Camera.main.transform.forward, new Vector3 (1, 0, 1)).normalized;
			Vector3 cameraRight = Vector3.Scale (Camera.main.transform.right, new Vector3 (1, 0, 1)).normalized;

			// Get input vector
			_input.x = Input.GetAxisRaw ("Horizontal") * (_inverted ? -1 : 1);
			_input.y = Input.GetAxisRaw ("Vertical") * (_inverted ? -1 : 1);

			return _input.x * cameraRight + _input.y * cameraForward;
		}

		return Vector3.zero;
    }

    void UpdateAnimatorMoveVariables(Vector3 p_relativeDirection)
    {
        SetStrafeLeft(IsStrafingLeft(p_relativeDirection));
        SetStrafeRight(IsStrafingRight(p_relativeDirection));
        SetBackwards(IsMovingBackwards(p_relativeDirection));
        UpdateStrafeAnimatorVariables(p_relativeDirection);
    }

    bool IsMovingForwards(Vector3 p_relativeDirection)
    {
        return (p_relativeDirection.y > 0);
    }

    bool IsStrafingLeft(Vector3 p_relativeDirection)
    {
        return (p_relativeDirection.x < 0);
    }

    bool IsStrafingRight(Vector3 p_relativeDirection)
    {
        return (p_relativeDirection.x > 0);
    }

    bool IsMovingBackwards(Vector3 p_relativeDirection)
    {
        return (p_relativeDirection.y < 0);
    }

    void SetStrafeLeft(bool p_state)
    {
        m_strafingLeft = p_state;
        //_animator.SetBool("MovingLeft", p_state);
    }

    void SetStrafeRight(bool p_state)
    {
        m_strafingRight = p_state;
        //_animator.SetBool("MovingRight", p_state);
    }

    void SetBackwards(bool p_state)
    {
        m_movingBackwards = p_state;
    }

    public void AddRotationBlock(string p_sourceName)
    {
        if (!rotateBlockers.Contains(p_sourceName))
            rotateBlockers.Add(p_sourceName);
    }

    public void RemoveRotationBlock(string p_sourceName)
    {
        rotateBlockers.Remove(p_sourceName);
    }

    public bool RotationEnabled()
    {
        return rotateBlockers.Count == 0;
    }

    public void AddMoveBlock(string p_sourceName)
    {
        //Debug.Log("move block: " + p_sourceName);

        if (!moveBlockers.Contains(p_sourceName))
            moveBlockers.Add(p_sourceName);
    }

    public void RemoveMoveBlock(string p_sourceName)
    {
        //Debug.Log("REMOVE move block: " + p_sourceName);

        moveBlockers.Remove(p_sourceName);
    }

    public bool MoveEnabled()
    {
        return moveBlockers.Count == 0;
    }

    void UpdateStrafeAnimatorVariables(Vector3 p_relativeDirection)
    {
        _animator.SetBool("MovingLeft", (!IsMovingForwards(p_relativeDirection) && IsStrafingLeft(p_relativeDirection)));
        _animator.SetBool("MovingRight", (!IsMovingForwards(p_relativeDirection) && IsStrafingRight(p_relativeDirection)));
        _animator.SetBool("MovingBackwards", IsMovingBackwards(p_relativeDirection));
    }

    void RotateTransformsToLegRotation()
    {
        foreach (Transform trans in rotationTransforms)
        {
            if (m_strafingRight && !m_movingBackwards)
                trans.RotateAround(trans.position, Vector3.up, rotationAdjustmentDegrees);
            else if (m_strafingRight && m_movingBackwards)
                trans.RotateAround(trans.position, Vector3.up, -rotationAdjustmentDegrees);
            else if (m_strafingLeft && !m_movingBackwards)
                trans.RotateAround(trans.position, Vector3.up, -rotationAdjustmentDegrees);
            else if (m_strafingLeft && m_movingBackwards)
                trans.RotateAround(trans.position, Vector3.up, rotationAdjustmentDegrees);
        }
    }

    public Vector3 GetForcedDirection()
    {
        return forcedMoveDirection;
    }
}
