using UnityEngine;

public class LetterInteraction : MonoBehaviour {

	private Transform cam;

	void Start() {
		cam = transform.GetChild(0);
	}

	void Update() {
		if(Input.GetKey(KeyCode.F)) {
			RaycastHit hitInfo;
			if(Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hitInfo)) {
				if(hitInfo.collider.CompareTag("Letter"))
					hitInfo.collider.GetComponent<Letter>().ReadLetter();
			}
		}
	}
}