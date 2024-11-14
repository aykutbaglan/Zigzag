using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private int score = 0;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        GuncelleYuksekSkorText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            GuncelleSkorText();

            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
                GuncelleYuksekSkorText();
            }
        }
    }

    void GuncelleSkorText()
    {
        scoreText.text = "Score: " + score;
    }

    void GuncelleYuksekSkorText()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}
