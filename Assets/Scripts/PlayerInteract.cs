using UnityEngine;

// logic to detect and interact with interactible objects
public class PlayerInteract : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField] // make interactable in editor
    private float interactDistance = 3f;


    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCamera; // get camera component from PlayerLook script
    }

    void Update()
    {
        // ray from center of the camera forward
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction * interactDistance); // draw ray in scene editor
    }
}