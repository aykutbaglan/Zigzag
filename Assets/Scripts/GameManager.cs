using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public static void GameResume()
    {
        Time.timeScale = 1.0f;
    }
    public static void GamePause()
    {
        Time.timeScale = 0f;
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}