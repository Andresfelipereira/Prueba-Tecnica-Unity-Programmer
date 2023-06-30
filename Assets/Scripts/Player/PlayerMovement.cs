using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public float playerSpeed = 5.0f;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            playerRigidBody.velocity = transform.forward * playerSpeed;
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            playerRigidBody.velocity = -transform.forward * playerSpeed;
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            playerRigidBody.velocity = transform.right * playerSpeed;
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            playerRigidBody.velocity = -transform.right * playerSpeed;
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(0, Time.deltaTime * -10f, 0);
        }
        if (Input.GetKey("e") || Input.GetKey("d"))
        {
            transform.Rotate(0, Time.deltaTime * 10f, 0);
        }
    }
}
