using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";

    [Header("Score Settings")]
    [SerializeField] private float currentScore = 0f;
    [SerializeField] private float bestScore = 0f;
    [SerializeField] private float scoreRate = 10f;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private GameManager gameManager;
    private bool hasSavedBestScore = false;

    public float CurrentScore => currentScore;
    public float BestScore => bestScore;

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
        currentScore = 0f;
        LoadBestScore();
        UpdateScoreUI();
        UpdateBestScoreUI();
    }

    private void Update()
    {
        if (gameManager != null && gameManager.IsGameOver)
        {
            SaveBestScoreIfNeeded();
            return;
        }

        IncreaseScoreOverTime();
        UpdateScoreUI();
        UpdateBestScoreUI();
    }

    private void IncreaseScoreOverTime()
    {
        currentScore += scoreRate * Time.deltaTime;
    }

    private void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetFloat(BestScoreKey, 0f);
    }

    private void SaveBestScoreIfNeeded()
    {
        if (hasSavedBestScore)
        {
            return;
        }

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat(BestScoreKey, bestScore);
            PlayerPrefs.Save();
        }

        UpdateBestScoreUI();
        hasSavedBestScore = true;
    }

    private void UpdateScoreUI()
    {
        if (scoreText == null)
        {
            return;
        }

        scoreText.text = "SCORE: " + Mathf.FloorToInt(currentScore);
    }

    private void UpdateBestScoreUI()
    {
        if (bestScoreText == null)
        {
            return;
        }

        bestScoreText.text = "BEST: " + Mathf.FloorToInt(bestScore);
    }
}