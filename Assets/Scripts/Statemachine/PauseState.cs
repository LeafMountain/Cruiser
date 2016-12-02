using UnityEngine;
using System.Collections;

public class PauseState : IGameState {

    StateManager stateManager;
    GameObject pauseMenu;

    public PauseState(StateManager stateManager)
    {
        this.stateManager = stateManager;
        Time.timeScale = 0;
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        pauseMenu.SetActive(true);
    }

	public void StateUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateManager.ChangeState(new PlayState(stateManager));
            pauseMenu.SetActive(false);
        }
    }
}
