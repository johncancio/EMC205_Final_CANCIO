using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public IInteractable interactable;

    private void Update()
    {
        if (interactable != null && Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact();
        }
    }

    public void SetInteractable(IInteractable newInteractable)
    {
        interactable = newInteractable;
        Debug.Log($"Interactable set to: {interactable}");
    }
}
