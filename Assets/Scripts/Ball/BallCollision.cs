using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private ScoreText scoreText;
    void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<IInteractable>(out var iInteractable))
        //{
        //    iInteractable.Interact();
        //}
        if (other.CompareTag("Ball"))
        {
            scoreText.score++;
            scoreText.UpdateScoreText();
            //Destroy(other.gameObject);

            if (scoreText.score > scoreText.highScore)
            {
                scoreText.highScore = scoreText.score;
                PlayerPrefs.SetInt("HighScore", scoreText.highScore);
                scoreText.UpdateHighScoreText();
            }
        }
    }
}