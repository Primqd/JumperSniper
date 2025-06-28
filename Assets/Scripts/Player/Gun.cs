using UnityEngine;

public class Gun : MonoBehaviour
{
    public float recoil = 5f;
    private PlayerMotor playerMotor;

    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    public void Shoot()
    {
        Vector3 recoilVelocity = transform.forward * -recoil;
        playerMotor.playerVelocity += recoilVelocity;
    }
}
