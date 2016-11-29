using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	// Components
	CharacterController controller;
	Transform trans;
	Transform cam;

	// Parameters
	public float moveSpeed = 2.5f;
	public float jumpSpeed = 6f;
	public float gravity = 20f;
	public float crouchSpeed = 4f;

	// Crouching parameters
	bool isCrouching;
	float height; // T
	float standHeight;
	float crouchHeight;
	float crouchLerp = 0f;

	// Input values
	float x = 0f;
	float y = 0f;
	Vector3 moveDir = Vector3.zero;

	void Start() {
		controller = GetComponent<CharacterController>();
		trans = transform;
		cam = trans.GetChild(0);
		height = controller.height;
		standHeight = height;
		crouchHeight = height / 2f;
	}

	void Update() {
		// Get input values
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
		if(controller.isGrounded) {
			moveDir = new Vector3(x, 0f, y); // Apply input values
			moveDir = transform.TransformDirection(moveDir); // Convert to world coordinates
			moveDir *= moveSpeed; // Multiply by speed
			if(Input.GetButton("Jump"))
				moveDir.y = jumpSpeed;
		}
		moveDir.y -= gravity * Time.deltaTime; // Apply gravity
		controller.Move(moveDir * Time.deltaTime); // Move the character.

		// Mouselook
		Look();

		// Crouch lerping.
		controller.height = Mathf.Lerp(standHeight, crouchHeight, crouchLerp);
		Crouch();
	}

	private void Crouch() {
		isCrouching = Input.GetButton("Crouch");
		if(isCrouching) {
			if(crouchLerp < 1)
				crouchLerp += crouchSpeed * Time.deltaTime;
			else
				crouchLerp = 1f;
		} else {
			if(crouchLerp == 0)
				return; // Cancel other if checks.
			if(crouchLerp > 0)
				crouchLerp -= crouchSpeed * Time.deltaTime;
			else if(crouchLerp < 0)
				crouchLerp = 0f;
		}
	}

	private void Look() {
		Vector3 horizontalRotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);
		Vector3 verticalRotation = new Vector3(-Input.GetAxisRaw("Mouse Y") + cam.rotation.eulerAngles.x, 0, 0);

		transform.rotation = Quaternion.Euler(horizontalRotation + transform.rotation.eulerAngles);
		cam.rotation = Quaternion.Euler(verticalRotation + transform.rotation.eulerAngles);
	}
}