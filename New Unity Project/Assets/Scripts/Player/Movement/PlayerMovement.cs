using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public PlayerData data;

    private float inputX;
    private float inputZ;

    private float drag;

    private bool inputY;

    public bool isGrounded;


    void Start()
    {
        drag = data.groundDrag;
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (isGrounded && inputY) Jump();

        if (!isGrounded) IncreaseGravity();
    }

    void IncreaseGravity()
    {
        if (rb.velocity.y < data.gravity * data.forceMultiplier) rb.AddForce(Vector3.down * data.gravity * data.forceMultiplier, ForceMode.Force);
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
        Vector3 moveVec = transform.forward * inputX + transform.right * inputZ;

        moveVec.Normalize();

        rb.AddForce(moveVec * data.groundSpeed * data.forceMultiplier, ForceMode.Acceleration);
    }
}
