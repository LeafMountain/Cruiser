using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Character_Move : MonoBehaviour {

	// Components
	Transform trans;
	CapsuleCollider col;
	Rigidbody rb;

	// Camera
	public Transform cam;
	public Transform groundCheck;

	// InputAxis
	float hori = 0f;
	float vert = 0f;

	// Inspector variables
	[Header("Parameters:")]
	[SerializeField] float maxMoveSpeed = 3f;
	[SerializeField] float jumpForce = 500f;
	[SerializeField] LayerMask groundMask;

	// Other variables
	bool isGrounded;

	
	void Awake() {
		// Get components
		trans = transform;
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();

		rb.freezeRotation = true; // We don't want physics based rotation.
	}

	void Update() {
		hori = Input.GetAxisRaw("Horizontal");
		vert = Input.GetAxisRaw("Vertical");
	}

	void FixedUpdate() {
		// Check if player is grounded
		isGrounded = Physics.Raycast(groundCheck.position, -Vector3.up, .2f, groundMask);
		Jump();

		// Move according to inputs, clamp at maxspeed.
		Move(hori, vert);
	}

	void Move(float h, float v) {
		Vector3 newForce = new Vector3(h, 0f, v);

		if (rb.velocity.magnitude < maxMoveSpeed)
			rb.AddForce(newForce, ForceMode.VelocityChange);
	}

	private void Jump() {
		if(isGrounded && Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}
}