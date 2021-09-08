using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] Transform groundOrgin;
    [SerializeField] PlayerData data;

    private PlayerMovement movement;

    private void FixedUpdate()
    {
        CheckForGround();

        movement = player.GetComponent<PlayerMovement>();
    }

    void CheckForGround()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(groundOrgin.position, -player.transform.up, out hitInfo, data.groundLayer))
        {
            if (hitInfo.distance <= 0.2f && rb.velocity.x + rb.velocity.z <= 0.1f)
            {
                data.playerState = PlayerData.PlayerState.idle;
                
            }
            else if (hitInfo.distance <= 0.2f && rb.velocity.x + rb.velocity.z > 0.1f)
            {
                data.playerState = PlayerData.PlayerState.walking;
            }
            else if (hitInfo.distance > 0.2f && rb.velocity.x + rb.velocity.z <= 0.1f)
            {
                data.playerState = PlayerData.PlayerState.falling;
            }
            else if (hitInfo.distance > 0.2f && rb.velocity.x + rb.velocity.z > 0.1f)
            {
                data.playerState = PlayerData.PlayerState.flying;
            }
        }
    }
}
