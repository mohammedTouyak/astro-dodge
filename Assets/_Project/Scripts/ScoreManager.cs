using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private float currentScore = 0f; // why float ? Because later score may increase using time.
    [SerializeField] private float scoreRate = 10f;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Gameplay References")]
    [SerializeField] private PlayerController playerController;

    public float CurrentScore => currentScore;

    private void Start()
    {
        currentScore = 0f;
        UpdateScoreUI();
    }

    private void Update()
    {
        if (CanIncreaseScore())
        {
            IncreaseScoreOverTime();
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

    private void UpdateScoreUI()
    {
        if (scoreText == null)
        {
            return;
        }

        scoreText.text = "Score: " + Mathf.FloorToInt(currentScore);
    }
}