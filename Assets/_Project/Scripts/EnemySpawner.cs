using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefab")]
    [SerializeField] private GameObject asteroidPrefab;

    [Header("Spawn Position")]
    [SerializeField] private float spawnY = 6f;
    [SerializeField] private float minSpawnX = -8f;
    [SerializeField] private float maxSpawnX = 8f;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnInterval = 2f; // This defines how often an asteroid should spawn. 2f means every 2 seconds

   private void Start()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogWarning("EnemySpawner: Asteroid Prefab is not assigned.");
            return;
        }

        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnInterval);
    }


    private void SpawnAsteroid()
    {

        float spawnX = Random.Range(minSpawnX, maxSpawnX);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity); // This creates a copy of the prefab in the scene.
                                                                        // - asteroidPrefab = what to spawn
                                                                        // - spawnPosition = where to spawn it
                                                                        // - Quaternion.identity = no rotation
    }
}