using UnityEngine;
using UnityEngine.SceneManagement; //This gives access to scene loading functions.

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public bool IsGameOver => isGameOver;

    private void Update()
    {
        if (!isGameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
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

    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}