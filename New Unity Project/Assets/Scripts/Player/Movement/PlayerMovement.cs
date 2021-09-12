using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerData data;

    private float inputX;
    private float inputZ;

    private float drag;

    private bool inputY;

    public bool isGrounded;

    void Start()
    {

    }

    void Update()
    {
        GetInput();
        SetDrag();
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (isGrounded && inputY) Jump();
    }

    void SetDrag()
    {
        if (isGrounded) drag = data.groundDrag;
        else drag = data.airDrag;

        rb.drag = drag;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * data.jumpHeight * data.forceMultiplier, ForceMode.Impulse);
    }

    void GetInput()
    {
        inputX = Input.GetAxisRaw("Vertical");
        inputZ = Input.GetAxisRaw("Horizontal");

        inputY = Input.GetKeyDown(KeyCode.Space);
    }

    void MovePlayer()
    {
        float speed;

        if (isGrounded) speed = data.groundSpeed;
        else speed = data.airSpeed;

        Vector3 moveVec = transform.forward * inputX + transform.right * inputZ;

        moveVec.Normalize();

        rb.AddForce(moveVec * speed * data.forceMultiplier, ForceMode.Acceleration);
    }
}
