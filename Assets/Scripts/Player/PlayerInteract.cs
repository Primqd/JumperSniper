using UnityEngine;

// logic to detect and interact with interactible objects
public class PlayerInteract : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField] // make interactable in editor
    private float interactDistance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;


    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCamera; // get camera component from PlayerLook script
        playerUI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        // ray from center of the camera forward
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        // store raycast interaction info
        RaycastHit hitInfo;

        playerUI.UpdateText(string.Empty); // reset ui text when not looking at anything

        // out = writes to hitInfo, returns boolean if it hits
        if (Physics.Raycast(ray, out hitInfo, interactDistance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactible>() != null) // has interactible component
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactible>().promptMessage);
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * interactDistance); // draw ray in scene editor
    }
}