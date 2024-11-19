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
        if (other.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
            scoreText.score += 30;
            scoreText.UpdateScoreText();
        }
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Ball Collided With : " +other.gameObject.name);
            scoreText.score++;
            scoreText.UpdateScoreText();
            Debug.Log("Current Score: " + scoreText.score);
        }
    }
}