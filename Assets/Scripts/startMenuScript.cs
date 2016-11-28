using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class startMenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button quitText;
    public Canvas creditsMenu;
    public Button creditsText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        creditsMenu = creditsMenu.GetComponent<Canvas>();
        creditsText = creditsText.GetComponent<Button>();
        quitMenu.enabled = false;
        creditsMenu.enabled = false;
	}
	
    public void ExitPress() //öppen quit menu
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
        creditsText.enabled = false;
    }

    public void NoPress() //stänga quit menu
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
        creditsText.enabled = true;
    }

    public void StartLevel() //starta spelet
    {
        SceneManager.LoadScene(1); //Om scenen man försöker ladda har ett namn, ange det här mellan "" istället för int-värdet
    }

    public void QuitGame() //stänga av spelet
    {
        Application.Quit ();
    }

    public void creditPress() //öppna credits
    {
        creditsMenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
        creditsText.enabled = false;
    }
    public void creditsCancelPress() //stänga credits
    {
        creditsMenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
        creditsText.enabled = true;
    }
}
