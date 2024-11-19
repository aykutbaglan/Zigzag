using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public int score = 0;
    public int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ball"))
    //    {
    //        score++;
    //        UpdateScoreText();
    //        //Destroy(other.gameObject);

    //        if (score > highScore)
    //        {
    //            highScore = score;
    //            PlayerPrefs.SetInt("HighScore", highScore);
    //            UpdateHighScoreText();
    //        }
    //    }
    //}
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = "HighScore:" + highScore;
    }

    internal void UpdateScore(int v)
    {
        score += v;
        scoreText.text = "Score: " + score;
    }
}