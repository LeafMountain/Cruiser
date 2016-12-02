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
        if (stateManager.pauseMenu.active)
            stateManager.pauseMenu.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
            stateManager.ChangeState(new PauseState(stateManager));
	}
}
