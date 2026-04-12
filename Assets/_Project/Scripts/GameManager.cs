using UnityEngine;
using UnityEngine.SceneManagement; //This gives access to scene loading functions.
using System.Collections;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    private bool isTransitioning = false;

    private GameOverUI gameOverUI;

    public bool IsGameOver => isGameOver;

    private void Awake()
    {
        gameOverUI = FindFirstObjectByType<GameOverUI>();

        if (gameOverUI == null)
        {
            Debug.LogError("GameOverUI not found in scene!");
        }
    }

    private void Update()
    {
        if (!isGameOver || isTransitioning)
        {
            return;
        }


        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void TriggerGameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;
        Debug.Log("Game Over triggered.");
    }

    public void RestartGame()
    {
        if (isTransitioning)
        {
            return;
        }

        StartCoroutine(RestartGameRoutine());
    }

    public void LoadMainMenu()
    {
        if (isTransitioning)
        {
            return;
        }

        StartCoroutine(LoadMainMenuRoutine());
    }

    private IEnumerator RestartGameRoutine()
    {
        isTransitioning = true;

        if (gameOverUI != null)
        {
            yield return StartCoroutine(gameOverUI.FadeOutUI());
        }

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private IEnumerator LoadMainMenuRoutine()
    {
        isTransitioning = true;

        if (gameOverUI != null)
        {
            yield return StartCoroutine(gameOverUI.FadeOutUI());
        }

        SceneManager.LoadScene("MainMenu");
    }
}