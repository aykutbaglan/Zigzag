using UnityEngine;
using DG.Tweening;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private ScoreText scoreText;
    private Tween crystalTextTween;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
            scoreText.score += 30;
            scoreText.UpdateScoreText();
            scoreText.crystalScore = 30;
            scoreText.CrystalScore();
            scoreText.CrystalTween();
        }
        if (other.CompareTag("Ground"))
        {
            //Debug.Log("Ball Collided With : " +other.gameObject.name);
            //scoreText.score++;
            //scoreText.UpdateScoreText();

            //if (scoreText.score > scoreText.highScore)
            //{
            //    scoreText.highScore = scoreText.score;
            //    PlayerPrefs.SetInt("HighScore", scoreText.highScore);
            //    scoreText.UpdateHighScoreText();
            //    Debug.Log("New High Score : " +  scoreText.highScore);
            //}
        }
    }
}