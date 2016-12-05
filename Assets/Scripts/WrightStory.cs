using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WrightStory : MonoBehaviour {

	public GameObject poison;
	public GameObject water;
	public AudioSource wrightSource;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject == poison || col.gameObject == water) {
			StartCoroutine(WrightThanks(col.gameObject == poison));
		}
	}

	IEnumerator WrightThanks(bool poison) {
		wrightSource.Play();
		yield return new WaitForSeconds(wrightSource.clip.length);
		SceneManager.LoadScene(poison ? 22 : 23);
	}
}