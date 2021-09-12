using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;

    public Transform playerPos;

    void FixedUpdate()
    {
        transform.localEulerAngles = transform.position - playerPos.position;

        GetComponent<Rigidbody>().AddForce(transform.forward * speed * 10);
    }
}
