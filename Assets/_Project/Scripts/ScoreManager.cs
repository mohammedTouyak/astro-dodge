using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private float currentScore = 0f; // why float ? Because later score may increase using time.
    [SerializeField] private float scoreRate = 10f;

    public float CurrentScore => currentScore;

    private void Start()
    {
        currentScore = 0f;
    }

    private void Update()
    {
        IncreaseScoreOverTime();
    }

    private void IncreaseScoreOverTime()
    {
        currentScore += scoreRate * Time.deltaTime;
    }
}