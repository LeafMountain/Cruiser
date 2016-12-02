using UnityEngine;

public class WrightTriggers : MonoBehaviour {
	void OnTriggerExit(Collider col) {
		if(col.CompareTag("Player"))
			UnityEngine.SceneManagement.SceneManager.LoadScene(24);
	}
}