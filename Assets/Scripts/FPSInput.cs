using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	// public variables
	public float speed = 9.0f;
	public float gravity = -9.8f;
    public float pushForce = 5.0f;
    private float jumpSpeed = 22.0f;
    private float terminalVel = -12.0f;
    private float minFall = -1.5f;

    private float vertSpeed;

	// private variables
	private CharacterController charController;

	// Use this for initialization
	void Start () {
		charController = GetComponent<CharacterController> ();
        vertSpeed = minFall;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxisRaw("Horizontal") * speed;
		float deltaZ = Input.GetAxisRaw("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		// Clamp magnitude for diagonal movement
		movement = Vector3.ClampMagnitude (movement, speed);

		// Apply gravity to the player
		movement.y = gravity;

		// Movement code Frame Rate Independent
		movement *= Time.deltaTime;

		// Convert Local to global coordinates
		movement = transform.TransformDirection (movement);

		charController.Move (movement);

		// transform.Translate (deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        if(charController.isGrounded) {
            if(Input.GetButtonDown("Jump")) {
                vertSpeed = jumpSpeed; // if player is grounded, apply jump
            } else {
                vertSpeed = minFall; // player not jumping, fall back to ground
            }
        } else {
            vertSpeed += gravity * 5 * Time.deltaTime; // player already in the air, apply gravity
            if (vertSpeed < terminalVel) {
                vertSpeed = terminalVel;
            }
        }

        movement.y = vertSpeed; // y movement now for jumping

        movement *= Time.deltaTime; // ensure it is all frame rate independent
        charController.Move(movement);
	}

    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;
        // does it have a rigidbody and is Physics enabled?
        if (body != null && !body.isKinematic) {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}
