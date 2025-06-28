using UnityEngine;

public class Button : Interactible // inherit from interactble
{
    // interaction code
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}