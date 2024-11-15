using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.SetInt("isGameStarted", 0);
    //    PlayerPrefs.DeleteKey("isGameRestarted");
    //}
    public static void GameResume()
    {
        Time.timeScale = 1.0f;
    }
    public static void GamePause()
    {
        Time.timeScale = 0f;
    }
}
