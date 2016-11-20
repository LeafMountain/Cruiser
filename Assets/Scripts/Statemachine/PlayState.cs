using UnityEngine;
using System.Collections;

public class PlayState : IGameState {

    StateManager stateManager;

    public PlayState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        Time.timeScale = 1;
    }

	public void StateUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            stateManager.ChangeState(new PauseState(stateManager));
	}
}
