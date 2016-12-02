using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public void Resume()
    {
        StateManager stateManager = GetComponentInParent<StateManager>();
        stateManager.ChangeState(new PlayState(stateManager));
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
