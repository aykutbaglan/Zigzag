using UnityEngine;
using DG.Tweening;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private ScoreText scoreText;
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
    }
}