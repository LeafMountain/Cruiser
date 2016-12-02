using UnityEngine;
using System.Collections;

public class ErinStory : MonoBehaviour {

	public GameObject waterBottle;
	public AudioClip voiceClip;

	private bool hasPlayed = false; // Only allow this event to occur once per gameplay.
	private AudioSource playerAudioSource;

	void OnTriggerEnter(Collider col) {
		if(hasPlayed) return;

		if(col.CompareTag("Player")) {
			PickUpObject carriedObject = col.gameObject.GetComponent<PickUpObject>();
			if(carriedObject.carrying && carriedObject.carriedObject == waterBottle) {
				hasPlayed = true;
				Destroy(waterBottle);
				carriedObject.carriedObject = null;
				carriedObject.carrying = false;
				playerAudioSource = col.gameObject.GetComponent<AudioSource>();
				PlayClip();
			}
		}
	}

	void PlayClip() {
		playerAudioSource.clip = voiceClip;
		playerAudioSource.Play();
	}
}