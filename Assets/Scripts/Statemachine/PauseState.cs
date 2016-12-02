using UnityEngine;
using System.Collections;

public class PauseState : IGameState {

    StateManager stateManager;

    public PauseState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        Time.timeScale = 0;
        stateManager.pauseMenu.SetActive(true);
    }

	public void StateUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateManager.ChangeState(new PlayState(stateManager));
            stateManager.pauseMenu.SetActive(false);
        }
    }
}
