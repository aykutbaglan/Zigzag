using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameState : State
{
    public float fallLimit = -3f;
    [SerializeField] private Button restartButton;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private StateMachine stateMachine;

    private void Update()
    {
        if (ballTransform.position.y < fallLimit)
        {
            GameOver();
        }
    }
    private void OnEnable()
    {
        restartButton.onClick.AddListener(RestartButtonOnClick);
    }
    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(RestartButtonOnClick);
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    public void GameOver()
    {
        stateMachine.TransitionToNextState();
        GameManager.GamePause();
    }
    public void RestartButtonOnClick()
    {
        PlayerPrefs.SetInt("isGameRestarted", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.GameResume();
    }
}
