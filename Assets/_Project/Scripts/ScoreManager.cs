using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private float currentScore = 0f; // why float ? Because later score may increase using time.

    public float CurrentScore => currentScore;

    private void Start()
    {
        currentScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}