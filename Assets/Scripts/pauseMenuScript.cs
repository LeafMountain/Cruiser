using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour {

    public Transform canvas;
    public Transform player;
    public Canvas PauseMenu;
    public Canvas exitToMainMenu;
    public Canvas exitToDesktop;
    public Button resumeText;
    public Button exitToMainMenuText;
    public Button exitToDesktopText;


    void Start()
    {
        canvas.gameObject.SetActive(false);
        exitToMainMenu = exitToMainMenu.GetComponent<Canvas>();
        exitToDesktop = exitToDesktop.GetComponent<Canvas>();
        resumeText = resumeText.GetComponent<Button>();
        exitToMainMenuText = exitToMainMenuText.GetComponent<Button>();
        exitToDesktopText = exitToDesktopText.GetComponent<Button>();
        exitToMainMenu.enabled = false;
        exitToDesktop.enabled = false;
    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused();
        }
	
	}
    public void paused()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
    public void ExitToMainYes()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGameYes()
    {
        Application.Quit();
    }
    public void ExitToMain()
    {
        exitToMainMenu.enabled = true;
        resumeText.enabled = false;
        exitToDesktopText.enabled = false;
        exitToMainMenuText.enabled = false;
    }
    public void ExitToMainNo()
    {
        exitToMainMenu.enabled = false;
        resumeText.enabled = true;
        exitToDesktopText.enabled = true;
        exitToMainMenuText.enabled = true;
    }
    public void ExitGame()
    {
        exitToDesktop.enabled = true;
        resumeText.enabled = false;
        exitToDesktopText.enabled = false;
        exitToMainMenuText.enabled = false;
    }
    public void ExitGameNo()
    {
        exitToDesktop.enabled = false;
        resumeText.enabled = true;
        exitToDesktopText.enabled = true;
        exitToMainMenuText.enabled = true;
    }
}
