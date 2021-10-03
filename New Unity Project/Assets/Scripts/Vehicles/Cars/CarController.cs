using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;
    private float currentBreakForce;
    private float steerAngle;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;

    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backLeftTransform;
    [SerializeField] private Transform backRightTransform;

    void FixedUpdate()
    {
        GetInput();

        HandleMotor();

        HandleSteering();

        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Camera.main.GetComponent<CarCamera>().enabled = false;
            Camera.main.GetComponent<CameraBehavior>().enabled = true;

            Camera.main.GetComponent<CameraChange>().data.cameraState = CameraData.CameraState.player;
        } 
    }

    private void HandleMotor()
    {
        frontLeftCollider.motorTorque = verticalInput * motorForce;
        frontRightCollider.motorTorque = verticalInput * motorForce;

        currentBreakForce = breakForce = isBreaking ? breakForce : 0f;

        if (isBreaking)
        {
            frontLeftCollider.brakeTorque = currentBreakForce;
            frontRightCollider.brakeTorque = currentBreakForce;
            backLeftCollider.brakeTorque = currentBreakForce;
            backRightCollider.brakeTorque = currentBreakForce;
        }
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;

        frontLeftCollider.steerAngle = steerAngle;
        frontRightCollider.steerAngle = steerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(backLeftCollider, backLeftTransform);
        UpdateSingleWheel(backRightCollider, backRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        rot.eulerAngles -= new Vector3(0f, 0f, 90f);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Camera.main.GetComponent<CarCamera>().enabled = true;
            Camera.main.GetComponent<CameraBehavior>().enabled = false;

            Camera.main.GetComponent<CameraChange>().data.cameraState = CameraData.CameraState.car;
        }
    }
}
