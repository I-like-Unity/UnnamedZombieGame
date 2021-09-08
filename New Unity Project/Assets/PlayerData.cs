using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    public enum PlayerState { idle, walking, falling, flying};
    public PlayerState playerState;

    public float speed;

    public float jumpHeight;

    public float forceMultiplier;

    public float groundDrag;
    public float airDrag;

    public LayerMask groundLayer;
}
