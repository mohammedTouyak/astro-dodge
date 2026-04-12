using System.Collections;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreResultText;
    [SerializeField] private float fadeDuration = 0.4f;

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

        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup is not assigned!");
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
            gameOverPanel.SetActive(true);
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
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
            StartCoroutine(FadeInGameOverUI());
            hasShownGameOver = true;
        }
    }

    private void UpdateScoreTexts()
    {
        if (scoreManager == null)
        {
            return;
        }

        finalScoreText.text = "FINAL SCORE: " + Mathf.FloorToInt(scoreManager.CurrentScore);
        bestScoreResultText.text = "BEST SCORE: " + Mathf.FloorToInt(scoreManager.BestScore);
    }

    private IEnumerator FadeInGameOverUI()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public IEnumerator FadeOutUI()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}