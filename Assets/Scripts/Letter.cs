using UnityEngine; using System.Collections;

public class Letter : MonoBehaviour {

	/*
		Put this script on a letter that is readable and has voice-over.
	*/
	
	public AudioClip voiceClip;
	public AudioSource playerAudioSource;

	private bool isReading = false;

	// As requested by Fredrik H., this will activate a trigger GameObject.
	[Header("Trigger GameObject:")]
	public GameObject triggerObject;
	public void TriggerObject() {
		triggerObject.SetActive(true);
	}

	public void ReadLetter() {
		if(isReading)
			return;
		if(playerAudioSource.clip != voiceClip)
			playerAudioSource.clip = voiceClip;
		StartCoroutine(ReadingLetter(voiceClip.length));
	}

	IEnumerator ReadingLetter(float clipDuration) {
		// Freeze player, bring up sprite, play clip.
		isReading = true;
		Player.PlayerMoveable = false;
		LetterInteraction.LetterSprite = true;
		playerAudioSource.Play();

		// Wait for input to resume gameplay.
		while(!Input.GetMouseButtonDown(0))
			yield return null;

		// Stop audio if playing, bring down sprite, unfreeze player.
		if(playerAudioSource.isPlaying)
			playerAudioSource.Stop();
		LetterInteraction.LetterSprite = false;
		Player.PlayerMoveable = true;
		isReading = false;
	}
}