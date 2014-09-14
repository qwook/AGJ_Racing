using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CPUCar : MonoBehaviour {

	public PathMaker path;

	bool hasFloor = false;

	// Use this for initialization
	void Start () {
	
	}

	void UpdateSettings() {

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isEditor) { UpdateSettings(); }
	
		if (hasFloor) {
			rigidbody.AddRelativeForce(Vector3.up*-500f, ForceMode.Acceleration);
			rigidbody.AddRelativeTorque(Vector3.forward*90f, ForceMode.Acceleration);
		}
	}

	void OnCollisionStay(Collision collisionInfo) {
		Vector3 upDir = transform.rotation * Vector3.forward;
		hasFloor = false;
		foreach(ContactPoint contact in collisionInfo.contacts) {
			float angle = Vector3.Angle(contact.normal, upDir);

			if (angle < 30.0f) {
				hasFloor = true;
			}
		}
	}
}
