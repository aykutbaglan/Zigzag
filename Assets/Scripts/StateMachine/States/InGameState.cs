using UnityEngine;

public class InGameState : State
{
    [SerializeField] private BallMovementController _moveController;
    public void StartGame()
    {
        base.OnEnter();
    }
    public override void OnEnter()
    {
        base.OnEnter();
        GameManager.GameResume();
        _moveController.ChangeGameStatus(true);
    }
}