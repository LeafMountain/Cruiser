using UnityEngine;
using System.Collections;

public class CreditsState : IGameState {

    StateManager stateManager;

    public CreditsState(StateManager stateManager)
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