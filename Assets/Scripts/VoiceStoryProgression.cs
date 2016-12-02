using UnityEngine;

public class VoiceStoryProgression : MonoBehaviour {

	public GameObject day2VoiceProgression;
	private GameObject[] day2voice;
	private int currentIndex;
	private int currentScene;

	void Start() {
		currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if(currentScene == 2) {
			day2voice = new GameObject[day2VoiceProgression.transform.childCount];
			for(int i = 0; i < day2VoiceProgression.transform.childCount; i++) {
				day2voice[i] = day2VoiceProgression.transform.GetChild(i).gameObject;
				day2voice[i].SetActive(false);
			}
			currentIndex = 0;
			day2voice[currentIndex].SetActive(true);
		}
	}

	void OnTriggerEnter(Collider col) {
		if(currentScene == 2) {
			if(col.CompareTag("VoiceProgression")) {
				if(col.GetComponent<BoxCollider>().enabled == true) {
					if(currentIndex+1 < day2voice.Length)
						day2voice[++currentIndex].SetActive(true);
				}
			}
		}
	}
}