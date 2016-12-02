using UnityEngine; using UnityEngine.SceneManagement; using System.Collections;

public class ErinStory : MonoBehaviour {
	
	public AudioClip voiceClip;
	private AudioSource audioSource;
	private bool onlyOnce = false;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider col) {
		if(onlyOnce) return;
		if(col.gameObject.layer == LayerMask.NameToLayer("Pickupable")) {
			onlyOnce = true;
			StartCoroutine(PlayClipAndSwitchScene());
		}
	}

	IEnumerator PlayClipAndSwitchScene() {
		audioSource.clip = voiceClip;
		audioSource.Play();
		yield return new WaitForSeconds(voiceClip.length);
		SceneManager.LoadScene(29);
	}
}