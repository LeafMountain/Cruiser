using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WrightStory : MonoBehaviour {

	public GameObject poison;
	public GameObject water;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject == poison)
			SceneManager.LoadScene(22);
		else if(col.gameObject == water)
			SceneManager.LoadScene(23);
	}
}