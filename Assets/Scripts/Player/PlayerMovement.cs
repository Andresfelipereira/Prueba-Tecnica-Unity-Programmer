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
        //Controles del jugador -> Movimiento
        if (Input.GetKey("up"))
        {
            playerRigidBody.velocity = transform.forward * playerSpeed;
        }
        if (Input.GetKey("down"))
        {
            playerRigidBody.velocity = -transform.forward * playerSpeed;
        }
        if (Input.GetKey("right"))
        {
            playerRigidBody.velocity = transform.right * playerSpeed;
        }
        if (Input.GetKey("left"))
        {
            playerRigidBody.velocity = -transform.right * playerSpeed;
        }
        //Controles del jugador -> Rotacion
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, Time.deltaTime * -20f, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, Time.deltaTime * 20f, 0);
        }
        if (Input.GetKey("w"))
        {
            transform.Rotate(Time.deltaTime * -20f,0, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.Rotate(Time.deltaTime * 20f,0, 0);
        }
    }
}
