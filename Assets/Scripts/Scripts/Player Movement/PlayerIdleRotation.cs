using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerIdleRotation : MonoBehaviour
{
    bool m_legRotationLockOrdered = false;
    bool m_legRotationLocked = false;

    public float legLockTime = 0.1f;
    public float degreeLimit = 90f;
    public List<Transform> m_LockTransformRotations = new List<Transform>();
    public CharacterController m_playerController;
    public Animator m_playerAnimator;
    List<Quaternion> m_LockRotations = new List<Quaternion>();
    float m_lockDegrees = 0f;

    TopgunTimer m_legLockTimer = new TopgunTimer();

    void Start()
    {
        foreach (Transform trans in m_LockTransformRotations)
        {
            m_LockRotations.Add(trans.rotation);
        }
    }

    void Update()
    {
        if (m_playerController.velocity.magnitude < 0.1f && m_playerAnimator.GetBool("IsIdle"))
        {
            if (m_legRotationLockOrdered == false)
                OrderLock();

            m_legLockTimer.Update();
            if (m_legLockTimer.IsComplete && m_legRotationLocked == false)
                LockRotations();

            if(m_legRotationLocked)
            {
                float DegreeDifference = m_lockDegrees - m_playerController.transform.rotation.eulerAngles.y;
                //Debug.Log(DegreeDifference);

                //left
                if (DegreeDifference > degreeLimit)
                    StartStepLeft();
                //right
                else if (DegreeDifference < -degreeLimit)
                    StartStepRight();
            }
        }
        else if (m_legRotationLockOrdered || m_legRotationLocked)
            UnlockRotations();
    }

    void OrderLock()
    {
        m_legRotationLockOrdered = true;
        m_legLockTimer.StartTimerBySeconds(legLockTime);
    }

    void StartStepLeft()
    {
        UnlockRotations();
        m_playerAnimator.SetBool("RotateStepLeft", true);
        m_playerAnimator.SetBool("RotateStepRight", false);
    }

    void StartStepRight()
    {
        UnlockRotations();
        m_playerAnimator.SetBool("RotateStepRight", true);
        m_playerAnimator.SetBool("RotateStepLeft", false);
    }

    void LockRotations()
    {
        if (m_legRotationLocked == false)
        {
            m_legRotationLocked = true;
            for (int i = 0; i < m_LockTransformRotations.Count; ++i)
            {
                m_LockRotations[i] = m_LockTransformRotations[i].rotation;
            }
            m_lockDegrees = m_playerController.transform.rotation.eulerAngles.y;
        }
    }

    void UnlockRotations()
    {
        m_legRotationLocked = false;
        m_legRotationLockOrdered = false;
    }

    void LateUpdate()
    {
        if (m_legRotationLocked)
        {
            for (int i = 0; i < m_LockTransformRotations.Count; ++i)
            {
                m_LockTransformRotations[i].rotation = m_LockRotations[i];
            }
        }
    }
}
