using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    public void StartGame()
    {
        GameManager.GameResume();
        base.OnEnter();
    }
}
