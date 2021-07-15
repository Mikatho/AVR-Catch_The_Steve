using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject target;
	public float speedMod = 10.0f;
	private Vector3 point;
	private Vector3 lastPosition;

	void Start() {
		point = target.transform.position;
		lastPosition = target.transform.position;
		transform.LookAt (point);
	}

	void Update() {
		float horizontal = Input.GetAxis ("Horizontal");
		if (lastPosition != target.transform.position) {
			transform.position -= (lastPosition - target.transform.position);
			lastPosition = target.transform.position;
			point = lastPosition;
		}

		transform.RotateAround (point, new Vector3 (0.0f, 1f, 0f), horizontal * Time.deltaTime * speedMod);
		transform.LookAt (point);
	}



	/*
	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;

	void Start() {
		offset = target.transform.position - transform.position;
	}

	void LateUpdate() {
		float horizontal = Input.GetAxis ("Horizontal") * rotateSpeed; // Rotation of the Player //Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0, Space.World);

		//float desiredAngle = target.transform.eulerAngles.y;
		//Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

		//Vector3 direction = (target.transform.forward * -1);
		//direction.y = offset.y;

		//transform.position = target.transform.position - (direction * offset.magnitude); // (rotation * offset);

		transform.RotateAround (offset, target.transform.rotation.y);
		transform.LookAt(target.transform);
	} */
		
}
