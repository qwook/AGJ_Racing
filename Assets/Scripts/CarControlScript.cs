using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarControlScript : MonoBehaviour {

	public Rigidbody _body;
	public GameObject _backwards, _up;
	public Vector3 _start_pos;
	public SteeringUI steeringUI;

	bool hasFloor;

	public bool HasFloor() {
		return hasFloor;
	}

	void Start () {
		_body = gameObject.GetComponent<Rigidbody>();
		_backwards = Util.FindInHierarchy(this.gameObject,"Backwards");
		_up = Util.FindInHierarchy(this.gameObject,"Up");
	}


	void Update () {
		float steering = steeringUI.angle;

		if (hasFloor) {
			if (Input.GetKey(KeyCode.Space)) {
				rigidbody.AddRelativeForce(Vector3.up*-100, ForceMode.Acceleration);
				rigidbody.AddRelativeTorque(Vector3.forward*steering*0.15f, ForceMode.Acceleration);
			}
		}

		if (Input.GetKey(KeyCode.R)) {
			this.transform.position = _start_pos;
			this.transform.eulerAngles = new Vector3(270,0,0);
			_body.angularVelocity = Vector3.zero;
			_body.velocity = Vector3.zero;
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