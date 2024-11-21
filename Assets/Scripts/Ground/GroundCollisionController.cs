using Unity.VisualScripting;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour/*, IInteractable*/
{
    private ScoreText scoreText;
    [SerializeField] private GroundDataTransmitter groundDataTransmitter;
    private bool hasBeenTouched = false;
    private const string BALL_TAG = "Ball";

    private void Start()
    {
        scoreText = FindObjectOfType<ScoreText>();
    }
    //public void Interact()
    //{
    //    //Debug.Log("ASDFLKHDSAJKLGDLHD");
    //    //scoreText.score++;
    //    //scoreText.UpdateScore(1);
    //}
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
        }
    }
}