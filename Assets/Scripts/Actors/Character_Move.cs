using UnityEngine;

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
	[SerializeField] KeyCode jumpKey;
	[SerializeField] KeyCode crouchKey;

	// Other variables
	bool isGrounded;
	bool isCrouching;
	float height;
	float crouchHeight;
	float moveForceMultiplier = 10f; // Multiplying the force added to movement with this.

	
	void Awake() {
		// Get components
		trans = transform;
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();

		rb.freezeRotation = true; // We don't want physics based rotation.
		height = col.height;
		crouchHeight = height / 2f;
	}

	void Update() {
		hori = Input.GetAxisRaw("Horizontal");
		vert = Input.GetAxisRaw("Vertical");

		Look();
	}

	void FixedUpdate() {
		// Check if player is grounded
		isGrounded = Physics.Raycast(groundCheck.position, -Vector3.up, .1f, groundMask); // ".2f" is how far the raycast should be fired.
		if(isGrounded) Jump();
		Crouch();

		// Move according to inputs, clamp at maxspeed.
		Move(hori, vert);
	}

	private void Move(float h, float v) {
		Vector3 newForce = (trans.forward * v * moveForceMultiplier) + (trans.right * h * moveForceMultiplier);

		if (rb.velocity.magnitude < maxMoveSpeed)
			rb.AddForce(newForce);
	}

	private void Look() {
		Vector3 horizontalRotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);
		Vector3 verticalRotation = new Vector3(-Input.GetAxisRaw("Mouse Y") + cam.rotation.eulerAngles.x, 0, 0);

		transform.rotation = Quaternion.Euler(horizontalRotation + transform.rotation.eulerAngles);
		cam.rotation = Quaternion.Euler(verticalRotation + transform.rotation.eulerAngles);
	}

	private void Jump() {
		if(Input.GetKeyDown(jumpKey)) {
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}

	private void Crouch() {
		if(Input.GetKey(crouchKey)) // While holding, crouch.
			col.height = crouchHeight;
		else if(Input.GetKeyUp(crouchKey)) // When releasing, stand up.
			col.height = height;

		// Set correct position of groundCheck to be able to jump whether or not you're crouching.
		groundCheck.transform.position = col.transform.position - new Vector3(0f, col.bounds.extents.y, 0f);
	}
}