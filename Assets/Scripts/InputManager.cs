using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // other type of actions: performed, started, and canceled
        onFoot.Jump.performed += ctx => motor.Jump(); // ctx = callback context, lambda function sorta

        // lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

    // update called once per frame
    void FixedUpdate()
    {
        // read movement vector from movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
}
