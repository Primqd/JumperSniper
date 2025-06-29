using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public Vector3 externalVelocity;
    private bool isGrounded;
    public float speed = 1f;
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
    // TODO: adjust friction to be more lenient, also vertical drag
    public void ProcessMove(Vector2 input)
    {
        // set player velocity to input velocity
        Vector3 moveDirection = transform.right * input.x + transform.forward * input.y; // transform local direction to world space- only for x and z
        playerVelocity.x = moveDirection.x * speed; playerVelocity.z = moveDirection.z * speed;

        // process gravity
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // reset y velocity
        }
        controller.Move(playerVelocity * Time.deltaTime + externalVelocity * Time.deltaTime);

        // Debug.Log(playerVelocity);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            // v_i = sqrt(2gh) from kinematic
            playerVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);

            // transfer playerVelocity x and z components to externalVelocity
            externalVelocity.x += playerVelocity.x; playerVelocity.x = 0;
            externalVelocity.z += playerVelocity.z; playerVelocity.z = 0;

        }
    }

}
