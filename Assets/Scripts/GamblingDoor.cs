using UnityEngine;

public class GamblingDoor : MonoBehaviour {

	public GameObject doorToClose;
	public AudioClip doorSlamClip;
	public float doorRotationDegrees = 42f;

	private AudioSource playerAudioSource;
	private bool hasClosed = false;

	void CloseDoor() {
		if(hasClosed) return;

		hasClosed = true;
		doorToClose.transform.Rotate(Vector3.up * doorRotationDegrees, Space.World);
		playerAudioSource.clip = doorSlamClip;
		playerAudioSource.Play();
	}

	void OnTriggerEnter(Collider col) {
		if(col.CompareTag("Player")) {
			playerAudioSource = col.GetComponent<AudioSource>();
			CloseDoor();
		}
	}

}