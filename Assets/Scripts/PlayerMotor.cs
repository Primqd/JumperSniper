using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float acceleration = 1f;
    public float friction = 0.1f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    //recieve inputs from inputmanger and apply them to character controller
    public void ProcessMove(Vector2 input)
    {
        // add 2d player input to velocity
        Vector3 accelDirection = transform.right * input.x + transform.forward * input.y; // transform local direction to world space- only for x and z
        playerVelocity.x += accelDirection.x * acceleration;
        playerVelocity.z += accelDirection.z * acceleration;

        // apply friction
        playerVelocity.x *= 1f - friction;
        playerVelocity.z *= 1f - friction;

        playerVelocity.y += gravity * Time.deltaTime;

        // process gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // reset y velocity
        }
        controller.Move(playerVelocity * Time.deltaTime);

        Debug.Log(playerVelocity);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            // v_i = sqrt(2gh) from kinematic
            playerVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }
    }

}
