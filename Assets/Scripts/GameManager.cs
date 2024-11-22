using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void GameResume()
    {
        Time.timeScale = 1.0f;
    }
    public static void GamePause()
    {
        Time.timeScale = 0f;
    }
}