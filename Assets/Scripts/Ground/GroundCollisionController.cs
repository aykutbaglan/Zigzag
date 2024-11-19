using Unity.VisualScripting;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour/*, IInteractable*/
{
    [SerializeField] private GroundDataTransmitter groundDataTransmitter;
    public  ScoreText scoreText;

    private const string BALL_TAG = "Ball";

    private void Start()
    {
        scoreText = FindObjectOfType<ScoreText>();
    }
    public void Interact()
    {

        //Debug.Log("ASDFLKHDSAJKLGDLHD");
        //scoreText.score++;
        //scoreText.UpdateScore(1);
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(BALL_TAG))
        {
            groundDataTransmitter.SetGroundRigidbodyValues();
           // scoreText.score++;
            scoreText.UpdateScore(1);
            if (scoreText.score > scoreText.highScore)
            {
                scoreText.highScore = scoreText.score;
                PlayerPrefs.SetInt("HighScore",scoreText.highScore);
                PlayerPrefs.Save();
                scoreText.UpdateHighScoreText();
            }
        } 
    }
}