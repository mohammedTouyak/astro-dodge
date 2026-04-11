using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public bool IsGameOver => isGameOver;

    private void Start()
    {
        isGameOver = false;
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
}