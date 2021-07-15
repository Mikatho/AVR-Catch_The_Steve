using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public GameObject mainCamera;
	private float fallingForce = 0f;
	private float force = 8f;

	// Use this for initialization
	void Start () {
	}
	
	// FixedUpdate so it doesnt shoot the ball away after paused
	void FixedUpdate () {
		//float moveHorizontal = Input.GetAxis ("Horizontal"); // Rotation of the Player
		float moveVertical = Input.GetAxis ("Vertical"); // Forward/Backwards movement

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Vector3 direction = mainCamera.transform.forward.normalized;
		direction.y = fallingForce;
		//GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().AddForce (direction * moveVertical * force);
	}
}
