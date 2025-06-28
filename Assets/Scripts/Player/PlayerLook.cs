using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    private float xRot = 0f;

    public float xSens = 30f;
    public float ySens = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // calculate camera rot for looking up and down
        // xRot = rotation around x axis = pitch = up and down rotation, hence we use mouseY
        xRot -= mouseY * ySens * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // apply to camera transform
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        // rotate player to look left and right
        // vector3.up = (0,1,0): rotationg around y axis = left and right rotation, hence mouseX
        transform.Rotate(Vector3.up * mouseX * xSens * Time.deltaTime);
    }
}
