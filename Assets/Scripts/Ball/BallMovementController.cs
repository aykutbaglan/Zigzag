using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private BallDataTransmiter ballDataTransmiter;
    [SerializeField] private float ballMoveSpeed;
    [SerializeField] private float speedIncreaseRate = 0.09f;
    [SerializeField] private float maxSpeed = 8f;

    private bool isGameStarted = false;
    private void Update()
    {
        if (isGameStarted)
        {
            SetBallMovement();
            SpeedIncrease();
        }
    }
    private void SetBallMovement()
    {
        transform.position += ballDataTransmiter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }
    private void SpeedIncrease()
    {
        if (ballMoveSpeed < maxSpeed)
        {
            ballMoveSpeed += speedIncreaseRate * Time.deltaTime;
        }
    }
    public void ChangeGameStatus(bool startStatus)
    {
        isGameStarted = startStatus;
    }
}