using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Button startText;
	public GameObject quitMenu;
	public Button quitText;
	public GameObject creditsMenu;
	public Button creditsText;
	
	public void StartLevel() {
		SceneManager.LoadScene(1);
	}
	
	public void QuitGame() {
		Application.Quit();
	}

	public void GoToStoryboard() {
		SceneManager.LoadScene(22);
	}

	public void CreditsMenu(bool state) {
		creditsMenu.SetActive(state);
		startText.enabled = !state;
		quitText.enabled = !state;
		creditsText.enabled = !state;
	}

	public void QuitMenu(bool state) {
		quitMenu.SetActive(state);
		startText.enabled = !state;
		quitText.enabled = !state;
		creditsText.enabled = !state;
	}
}