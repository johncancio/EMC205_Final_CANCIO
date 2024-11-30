using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public TooltipManager tooltipManager;
    private PlayerInteraction playerInteraction;

    private void OnCollisionEnter(Collision collision)
    {
        playerInteraction = collision.gameObject.GetComponent<PlayerInteraction>();
        if (playerInteraction != null)
        {
            tooltipManager.ShowTooltip(GetTooltipMessage());
            playerInteraction.SetInteractable(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (playerInteraction != null && collision.gameObject.GetComponent<PlayerInteraction>() == playerInteraction)
        {
            tooltipManager.HideTooltip();
            playerInteraction.SetInteractable(null);
            playerInteraction = null;
        }
    }

    public abstract string GetTooltipMessage();
    public abstract void Interact();
}
