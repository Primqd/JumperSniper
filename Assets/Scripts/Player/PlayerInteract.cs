using UnityEngine;

// logic to detect and interact with interactible objects
public class PlayerInteract : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField] // make interactable in editor
    private float interactDistance = 3f;
    [SerializeField]
    private LayerMask mask;


    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCamera; // get camera component from PlayerLook script
    }

    void Update()
    {
        // ray from center of the camera forward
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        // store raycast interaction info
        RaycastHit hitInfo;

        // out = writes to hitInfo, returns boolean if it hits
        if (Physics.Raycast(ray, out hitInfo, interactDistance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactible>() != null) // has interactible component
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactible>().promptMessage);
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * interactDistance); // draw ray in scene editor
    }
}