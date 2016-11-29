using UnityEngine; using System.Collections;

public class Letter : MonoBehaviour {

	/*
		Put this script on a letter that is readable and has voice-over.
	*/
	
	public AudioClip voiceClip;
	public AudioSource playerAudioSource;
	public Texture letterTexture;

	private bool isReading = false;

	public void ReadLetter() {
		if(isReading)
			return;
		if(playerAudioSource.clip != voiceClip)
			playerAudioSource.clip = voiceClip;
		StartCoroutine(ReadingLetter(voiceClip.length));
	}

	IEnumerator ReadingLetter(float clipDuration) {
		isReading = true;
		// Bring up texture
		playerAudioSource.Play();
		yield return new WaitForSeconds(clipDuration);
		// Take down texture
		isReading = false;
	}
}