using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject car;

	// Somehow to get value(steering) from playerControl
	public float steering = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Simulating steering wheel's value
		if (Input.GetKey ("7")) {
				steering = 360.0f;
		} else if (Input.GetKey ("8")) {
				steering = 180.0f;
		} else if (Input.GetKey ("9")) {
				steering = -180.0f;
		} else if (Input.GetKey ("0")) {
				steering = -360.0f;
		} else {
				steering = 0;
		}

		// when the car reduces speed, the camera zoom in
		if (steering > 20.0f || steering < -20.0f) {
						
		} else {

		}
	}
}
