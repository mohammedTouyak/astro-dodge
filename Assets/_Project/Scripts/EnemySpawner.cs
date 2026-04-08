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
}