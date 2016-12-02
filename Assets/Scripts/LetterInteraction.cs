using UnityEngine; using UnityEngine.UI;

public class LetterInteraction : MonoBehaviour {
	
	private Transform cam;
	Canvas canvas;
	static Image letterSprite;

	void Start() {
		cam = transform.GetChild(0);
		canvas = transform.GetChild(1).GetComponent<Canvas>();
		letterSprite = canvas.transform.GetChild(0).GetComponent<Image>();
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

	public static bool LetterSprite {
		set {
			letterSprite.enabled = value;
		}
	}
}