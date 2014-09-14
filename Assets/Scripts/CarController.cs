using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float angle = 0.0f;

		if (Input.GetKey(KeyCode.A)) {
			angle = -5.0f;
		}
		if (Input.GetKey(KeyCode.D)) {
			angle = 5.0f;
		}

		if (Input.GetKey(KeyCode.W)) {
			rigidbody.AddRelativeForce(Vector3.forward*20.0f, ForceMode.Acceleration);
			rigidbody.AddRelativeTorque(Vector3.up*angle, ForceMode.Acceleration);
		}

		if (Input.GetKey(KeyCode.S)) {
			rigidbody.AddRelativeForce(Vector3.forward*-20, ForceMode.Acceleration);
			rigidbody.AddRelativeTorque(Vector3.up*-angle, ForceMode.Acceleration);
		}

	}
}
