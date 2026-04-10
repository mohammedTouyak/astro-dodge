using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";
    [Header("Score Settings")]
    [SerializeField] private float currentScore = 0f; // why float ? Because later score may increase using time.
    [SerializeField] private float bestScore = 0f;
    [SerializeField] private float scoreRate = 10f;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Gameplay References")]
    [SerializeField] private PlayerController playerController;

    private bool hasSavedBestScore = false;


    public float CurrentScore => currentScore;
    public float BestScore => bestScore;

    private void Start()
    {
        currentScore = 0f;
        // PlayerPrefs.DeleteKey(BestScoreKey);
        LoadBestScore();
        UpdateScoreUI();
    }

    private void Update()
    {
        if (CanIncreaseScore())
        {
            IncreaseScoreOverTime();
        }
        else
        {
            SaveBestScoreIfNeeded();
        }

        UpdateScoreUI();
    }

    private bool CanIncreaseScore()
    {
        if (playerController == null)
        {
            return false;
        }

        return playerController.IsAlive;
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
}