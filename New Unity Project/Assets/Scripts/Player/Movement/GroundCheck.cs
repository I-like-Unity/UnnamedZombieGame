using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] Transform groundOrgin;
    [SerializeField] PlayerData data;

    private PlayerMovement movement;

    private void Start()
    {
        movement = player.GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        CheckForGround();
    }

    void CheckForGround()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(groundOrgin.position, -player.transform.up, out hitInfo, data.groundLayer))
        {
            if (hitInfo.distance <= 0.2f && rb.velocity.x + rb.velocity.z <= 0.1f)
            {
                data.playerState = PlayerData.PlayerState.idle;
                movement.isGrounded = true;
            }
            else if (hitInfo.distance <= 0.2f && rb.velocity.x + rb.velocity.z > 0.1f)
            {
                data.playerState = PlayerData.PlayerState.walking;
                movement.isGrounded = true;
            }
            else if (hitInfo.distance > 0.2f && rb.velocity.x + rb.velocity.z <= 0.1f)
            {
                data.playerState = PlayerData.PlayerState.falling;
                movement.isGrounded = false;
            }
            else if (hitInfo.distance > 0.2f && rb.velocity.x + rb.velocity.z > 0.1f)
            {
                data.playerState = PlayerData.PlayerState.flying;
                movement.isGrounded = false;
            }
        }
    }
}
