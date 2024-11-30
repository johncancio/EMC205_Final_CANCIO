using UnityEngine;

public class Door : InteractableBase
{
    private bool isOpen;

    public override string GetTooltipMessage() => "Press E to Open Door";

    public override void Interact()
    {
        isOpen = !isOpen;
        gameObject.SetActive(!isOpen);
    }
}
