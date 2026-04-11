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
    [SerializeField] private float initialSpawnInterval = 2f;// This defines how often an asteroid should spawn. 2f means every 2 seconds
    [SerializeField] private float minimumSpawnInterval = 0.6f;
    [SerializeField] private float difficultyIncreaseRate = 0.05f;

    private float currentSpawnInterval;
    private float spawnTimer;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in scene!");
        }
    }

   private void Start()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogWarning("EnemySpawner: Asteroid Prefab is not assigned.");
            enabled = false;
            return;
        }

        // InvokeRepeating(nameof(SpawnAsteroid), 0f, initialSpawnInterval); // Start() says: “Unity, please call SpawnAsteroid() every 2 seconds”
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    private void Update()
    {
        if (gameManager != null && gameManager.IsGameOver)
        {
            return;
        }

        HandleSpawning();
        IncreaseDifficulty();
    }

   private void HandleSpawning()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnAsteroid();
            spawnTimer = currentSpawnInterval;
        }
    }

    private void IncreaseDifficulty()
    {
        if (currentSpawnInterval > minimumSpawnInterval)
        {
            currentSpawnInterval -= difficultyIncreaseRate * Time.deltaTime;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minimumSpawnInterval);
        }
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