using UnityEngine;

public abstract class Interactible : MonoBehaviour // base class for all interactible objects
{
    // message displayed when looking at an interactible
    public string promptMessage;

    // function to be called by player
    public void BaseInteract()
    {
        Interact();
    }

    // method called when player interacts with object
    protected virtual void Interact() { }
}
