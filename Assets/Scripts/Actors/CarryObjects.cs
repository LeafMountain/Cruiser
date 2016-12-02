using UnityEngine; using System.Collections;

public class CarryObjects : MonoBehaviour {

	public KeyCode pickUpItemKey = KeyCode.F;
	public KeyCode letGoKey = KeyCode.F;
	public LayerMask layerOfObjects;
	public float floatingDistance = 1f;

	private static Transform currentItem;
	float rayDistance = 3f;
	private Transform player;
	private Transform playerCam;
	private static bool isCarrying = false;

	void Start() {
		player = transform;
		playerCam = player.GetChild(0);
	}

	IEnumerator DoorClose(Transform door) {
		door.Rotate(Vector3.up * 80f, Space.World);
		door.gameObject.GetComponent<AudioSource>().Play();
		Player.PlayerMoveable = false;
		yield return new WaitForSeconds(1f);
		UnityEngine.SceneManagement.SceneManager.LoadScene(28);
	}

	void Update() {
		if(!isCarrying) {
			if(Input.GetKeyDown(pickUpItemKey)) {
				RaycastHit hitInfo;
				if(Physics.Raycast(playerCam.position, playerCam.TransformDirection(Vector3.forward), out hitInfo, rayDistance, layerOfObjects)) {
					if(hitInfo.transform.tag == "ErinDoor") {
						StartCoroutine(DoorClose(hitInfo.transform));
						return;
					}
					currentItem = hitInfo.transform;
					currentItem.GetComponent<Rigidbody>().isKinematic = true;
					isCarrying = true;
				}
			}
		} else {
			if(Input.GetKeyDown(letGoKey)) {
				currentItem.GetComponent<Rigidbody>().isKinematic = false;
				isCarrying = false;
				currentItem = null;
			}
		}
	}

	void FixedUpdate() {
		if(!isCarrying) return;

		Vector3 newPosition = playerCam.position + playerCam.TransformDirection(Vector3.forward * floatingDistance);
		currentItem.position = newPosition;
	}

	public static bool IsCarrying {
		get {
			return isCarrying;
		}
	}

	public static Transform CurrentItem {
		get {
			return currentItem;
		}
	}

}