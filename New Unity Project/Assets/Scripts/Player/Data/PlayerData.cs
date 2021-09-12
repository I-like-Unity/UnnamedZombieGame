using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public enum PlayerState { idle, walking, falling, flying, driving};
    public PlayerState playerState;

    public float groundSpeed;
    public float airSpeed;

    public float jumpHeight;

    public float forceMultiplier;

    public float groundDrag;
    public float airDrag;

    public float gravity;

    public LayerMask groundLayer;

    public float mouseSensitifty;
}
