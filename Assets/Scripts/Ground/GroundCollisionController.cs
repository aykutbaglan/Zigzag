using UnityEngine;

public class GroundCollisionController : MonoBehaviour/*, IInteractable*/
{
    [SerializeField] private ScoreText scoreText;
    [SerializeField] private GroundDataTransmitter groundDataTransmitter;
    private bool hasBeenTouched = false;
    private const string BALL_TAG = "Ball";

    private void Start()
    {
        scoreText = FindObjectOfType<ScoreText>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("MainGround"))
        {
            return;
        }
        if (other.gameObject.CompareTag(BALL_TAG) && !hasBeenTouched)
        {
            hasBeenTouched = true;
            scoreText.UpdateScore(1);
            if (scoreText.score > scoreText.highScore)
            {
                scoreText.highScore = scoreText.score;
                PlayerPrefs.SetInt("HighScore", scoreText.highScore);
                PlayerPrefs.Save();
                scoreText.UpdateHighScoreText();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(BALL_TAG))
        {
            groundDataTransmitter.SetGroundRigidbodyValues();
            hasBeenTouched = false;
        }
    }
}