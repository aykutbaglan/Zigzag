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
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Ball Collided With : " +other.gameObject.name);
            scoreText.score++;
            scoreText.UpdateScoreText();
            
            //Destroy(other.gameObject);

            if (scoreText.score > scoreText.highScore)
            {
                scoreText.highScore = scoreText.score;
                PlayerPrefs.SetInt("HighScore", scoreText.highScore);
                scoreText.UpdateHighScoreText();
                Debug.Log("New High Score : " +  scoreText.highScore);
            }
        }
    }
}