using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public int spawnCount;
    public Vector2 randomXRange;
    public Vector2 randomZRange;
    public List<GameObject> coinPrefabs;
    public Transform coinParent;
    public LayerMask groundLayerMask;

    private void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        for (int i = 0; i < spawnCount;)
        {
            float x = Random.Range(randomXRange.x, randomXRange.y);
            float z = Random.Range(randomZRange.x, randomZRange.y);
            Vector3 spawnPosition = new Vector3(x, 10, z);

            if (Physics.Raycast(spawnPosition, Vector3.down, out RaycastHit hit, 100, groundLayerMask))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, 2);
                if (colliders.Length == 1)
                {
                    Instantiate(
                        coinPrefabs[Random.Range(0, coinPrefabs.Count)],
                        new Vector3(hit.point.x, 1, hit.point.z),
                        Quaternion.identity,
                        coinParent
                    );
                    i++;
                }
            }
        }
    }
}
