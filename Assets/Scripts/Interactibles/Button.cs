using UnityEngine;

public class Button : Interactible // inherit from interactble
{

    // interaction code
    void Start()
    {
        // No need to assign transform; it's inherited from MonoBehaviour
    }

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        transform.Translate(Vector3.up * 100f * Time.deltaTime);
    }
}