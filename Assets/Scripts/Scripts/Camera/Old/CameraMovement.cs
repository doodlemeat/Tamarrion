using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject TargetObject;
    public float StandardDistanceMin = 4.5f;
    public float StandardDistanceMax = 5.5f;
    public float DistanceAdjustmentSpeed = 1.0f;
    public float RotationSensitivity = 8.0f;
    public float HeightOffset = 2.0f;

    private Vector3 TargetPosition;
    //private float DesiredAngle = 270;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        TargetPosition = TargetObject.transform.localPosition + new Vector3(0, HeightOffset, 0);
        KeyboardControls();
        GamepadControls();
        DistanceCorrection();
        transform.LookAt(TargetPosition);
    }

    void KeyboardControls()
    {
        if (Input.GetKey(KeyCode.J))
            transform.RotateAround(TargetPosition, Vector3.up, -100.0f * Time.deltaTime * RotationSensitivity);
        if (Input.GetKey(KeyCode.L))
            transform.RotateAround(TargetPosition, Vector3.up, 100.0f * Time.deltaTime * RotationSensitivity);
        if (Input.GetKey(KeyCode.I))
        {
            transform.RotateAround(TargetPosition, Vector3.Cross(transform.localPosition - TargetPosition, Vector3.up), 100.0f * Time.deltaTime * RotationSensitivity);
            //DesiredAngle = Vector3.Cross(transform.localPosition - TargetPosition, Vector3.up);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.RotateAround(TargetPosition, Vector3.Cross(transform.localPosition - TargetPosition, Vector3.up), -100.0f * Time.deltaTime * RotationSensitivity);
            //DesiredHeight = transform.localPosition.y;
        }
    }

    void GamepadControls()
    {
        transform.RotateAround(TargetPosition, Vector3.up, -Input.GetAxis("RightStick_Horizontal") * 100 * Time.deltaTime * RotationSensitivity);
        transform.RotateAround(TargetPosition, Vector3.Cross(transform.localPosition - TargetObject.transform.localPosition, Vector3.up), -Input.GetAxis("RightStick_Vertical") * 100 * Time.deltaTime * RotationSensitivity);
        //2DesiredAngle = Vector3.Cross(transform.localPosition - TargetPosition, Vector3.up);
    }

    void DistanceCorrection()
    {
        float fDistanceToTarget = Vector3.Distance(transform.localPosition, TargetPosition);
        //if (fDistanceToTarget < fMaxDistanceSmall && fDistanceToTarget > 0.1f)
        //{
        //    transform.localPosition = Vector3.MoveTowards(transform.localPosition, xTargetPosition, -fDistanceAdjustmentSpeed * (fDistanceToTarget / fMaxDistanceSmall) * Time.deltaTime);
        //    //transform.localPosition = new Vector3(transform.localPosition.x, fDesiredHeight, transform.localPosition.z);
        //}
        if (fDistanceToTarget > StandardDistanceMax)
        {
            //Debug.Log((fDistanceToTarget / StandardDistanceMax) * Time.deltaTime * DistanceAdjustmentSpeed);

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPosition, Time.deltaTime); //DistanceAdjustmentSpeed * (1 - StandardDistanceMax / fDistanceToTarget) *
            //transform.localPosition = new Vector3(transform.localPosition.x, DesiredHeight, transform.localPosition.z);
        }

        if (fDistanceToTarget < StandardDistanceMin && fDistanceToTarget > 1.0f)
        {
            //Debug.Log(-DistanceAdjustmentSpeed * Time.deltaTime);

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPosition, (StandardDistanceMax / fDistanceToTarget) * Time.deltaTime * -DistanceAdjustmentSpeed); // * (1 - StandardDistanceMin / fDistanceToTarget) 
            //transform.localPosition = new Vector3(transform.localPosition.x, DesiredHeight, transform.localPosition.z);
        }
    }
}