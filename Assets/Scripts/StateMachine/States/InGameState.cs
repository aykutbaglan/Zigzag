using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("On Enter In Game");
        base.OnEnter();
        //StartCoroutine(StartGameAfterDelay());
        GameManager.GameResume();
        _moveController.ChangeGameStatus(true);
    }
    //IEnumerator StartGameAfterDelay()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    GameManager.GameResume();
    //}
}
