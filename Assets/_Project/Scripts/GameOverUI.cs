using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private GameManager gameManager;
    private bool hasShownGameOver = false;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in scene!");
        }

        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel is not assigned!");
        }
    }

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (hasShownGameOver)
        {
            return;
        }

        if (gameManager != null && gameManager.IsGameOver)
        {
            ShowGameOverUI();
        }
    }

    private void ShowGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        hasShownGameOver = true;
    }
}