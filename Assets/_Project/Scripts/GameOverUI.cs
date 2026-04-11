using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreResultText;

    private GameManager gameManager;
    private ScoreManager scoreManager;
    private bool hasShownGameOver = false;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        scoreManager = FindFirstObjectByType<ScoreManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in scene!");
        }

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in scene!");
        }

        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel is not assigned!");
        }

        if (finalScoreText == null)
        {
            Debug.LogError("Final Score Text is not assigned!");
        }

        if (bestScoreResultText == null)
        {
            Debug.LogError("Best Score Result Text is not assigned!");
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
            UpdateScoreTexts();
            ShowGameOverUI();
        }
    }

    private void UpdateScoreTexts()
    {
        if (scoreManager == null)
        {
            return;
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "FINAL SCORE: " + Mathf.FloorToInt(scoreManager.CurrentScore);
        }

        if (bestScoreResultText != null)
        {
            bestScoreResultText.text = "BEST SCORE: " + Mathf.FloorToInt(scoreManager.BestScore);
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