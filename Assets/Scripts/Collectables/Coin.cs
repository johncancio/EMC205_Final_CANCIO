using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction player))
        {
            FindFirstObjectByType<GameStateManager>().CollectCoin(points);

            Destroy(gameObject);
        }
    }
}
