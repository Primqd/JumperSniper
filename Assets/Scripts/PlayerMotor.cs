using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
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
        playerVelocity.x = input.x * speed;
        playerVelocity.z = input.y * speed;
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
