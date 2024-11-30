using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractableBase
{
    public List<GameObject> coinPrefabs;
    public Transform spawnLocation;
    private bool isInteracted;

    public override string GetTooltipMessage() => "Press E to Open Chest";

    public override void Interact()
    {
        if (isInteracted) return;

        isInteracted = true;
        Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Count)], spawnLocation.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
