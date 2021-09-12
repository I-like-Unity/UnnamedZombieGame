using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private PlayerMovement movement;

    [SerializeField] private PlayerData data;

    private Camera cam;

    [SerializeField] private Transform playerTransform;

    public float xRotation = 0f;
    public float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        movement = GetComponentInParent<PlayerMovement>();

        cam = Camera.main;
    }

    private void Update()
    {
        LookAtCursor();
    }

    void LookAtCursor()
    {
        float x = Input.GetAxis("Mouse X") * data.mouseSensitifty * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * data.mouseSensitifty * Time.deltaTime;

        yRotation = y;

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerTransform.Rotate(Vector3.up * x);
    }
}
