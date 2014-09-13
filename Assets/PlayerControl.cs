using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	GameObject userInterface;
	SteeringUI steeringUI;
	float steering;

	// Use this for initialization
	void Start () {
		userInterface = GameObject.Find("UnityWatermark-small");
	}
	
	// Update is called once per frame
	void Update () {

		steeringUI = userInterface.GetComponent<SteeringUI>();
		steering = steeringUI.angle;

		//  Key Control
		if (Input.GetKey ("w")) {
			transform.Translate(0, 0, 10.0f);
		}
		if (Input.GetKey ("s")) {
			transform.Translate(0, 0, -10.0f);
		}
		if (Input.GetKey ("d") && (Input.GetKey ("w") || Input.GetKey ("s"))) {
			transform.Rotate(0, 5.0f, 0);
		}
		if (Input.GetKey ("a") && (Input.GetKey ("w") || Input.GetKey ("s"))) {
			transform.Rotate(0, -5.0f, 0);
		}

		// Simulating steering wheel's value
//		if (Input.GetKey ("7")) {
//				steering = 360.0f;
//		} else if (Input.GetKey ("8")) {
//				steering = 180.0f;
//		} else if (Input.GetKey ("9")) {
//				steering = -180.0f;
//		} else if (Input.GetKey ("0")) {
//				steering = -360.0f;
//		} else {
//			steering = 0;		
//		}

		// Wheel Control
		if (steering > 0 && (Input.GetKey ("w") || Input.GetKey ("s"))) {
			transform.Rotate(0, 5.0f * steering / 360, 0);
		}
		if (steering < 0 && (Input.GetKey ("w") || Input.GetKey ("s"))) {
			transform.Rotate(0, 5.0f * steering / 360, 0);
		}

	}
}
