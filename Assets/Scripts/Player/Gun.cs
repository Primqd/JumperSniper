using UnityEngine;

public class Gun : MonoBehaviour
{
    public float recoil = 5f;
    private PlayerMotor playerMotor;
    private Camera playerCamera;

    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
        playerCamera = GetComponent<PlayerLook>().playerCamera;
    }

    public void Shoot()
    {
        Vector3 recoilVelocity = playerCamera.transform.forward * -recoil;
        playerMotor.airVelocity += recoilVelocity;
    }
}
