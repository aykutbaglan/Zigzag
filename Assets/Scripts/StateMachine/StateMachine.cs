using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    [SerializeField] private State[] states;
    private int stateNum;

    private void Start()
    {

        Debug.Log(PlayerPrefs.GetInt("isGameRestarted") + "aaaaaaaaaaaaaa");
        if (PlayerPrefs.GetInt("isGameRestarted") == 0)
        {
            TransitionToNextState();
        }
        else
        {
            PlayerPrefs.SetInt("isGameRestarted", 0);
            TransitionToSpesificState(1);
        }
    }
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
        Debug.Log(currentState.name);
    }
    public void TransitionToNextState()
    {
        if (stateNum < states.Length)
        {
            ChangeState(states[stateNum]);
            stateNum++;
        }
    }
    public void TransitionToSpesificState(int stateid)
    {
        ChangeState(states[stateid]);
        stateNum = stateid + 1;
    }
    public void CloseAllState()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].OnExit();
        }
    }
}