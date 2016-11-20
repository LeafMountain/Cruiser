using UnityEngine;
using System.Collections;

public class StartState : IGameState {

    StateManager stateManager;

    public StartState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        Time.timeScale = 1;
    }

    public void StateUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            stateManager.ChangeState(new PlayState(stateManager));
    }
}
