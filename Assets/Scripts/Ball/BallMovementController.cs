using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private BallDataTransmiter ballDataTransmiter;
    [SerializeField] private float ballMoveSpeed;

    private bool isGameStarted = false;
    private void Update()
    {
        if (isGameStarted)
        {
            SetBallMovement();
        }
    }
    private void SetBallMovement()
    {
        transform.position += ballDataTransmiter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }
    public void ChangeGameStatus(bool startStatus)
    {
        isGameStarted = startStatus;
    }
}