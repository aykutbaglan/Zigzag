using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameState : State
{
    [SerializeField] private Button startButton;
    [SerializeField] private StateMachine stateMachine;
    private const int IN_GAME_STATE_INDEX = 1;

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartButtonOnClick);
    }
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartButtonOnClick);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        if (PlayerPrefs.GetInt("isGameRestarted",0) == 1)
        {
            GameManager.GameResume();
            stateMachine.TransitionToSpesificState(IN_GAME_STATE_INDEX);
            return;
        }
        GameManager.GamePause();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    private void StartButtonOnClick()
    {
        PlayerPrefs.SetInt("isGameStarted", 1);
        PlayerPrefs.Save();
        base.OnExit();
        GameManager.GameResume();
        stateMachine.TransitionToNextState();
    }
}
