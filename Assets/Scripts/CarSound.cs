using UnityEngine;
using System.Collections;

public class CarSound : MonoBehaviour {

	public Rigidbody _body;
	public AudioClip drive;
	public AudioClip curve;
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	public SteeringUI steeringUI;

	// Use this for initialization
	void Start () {
		audioSource1.clip = drive;
		audioSource2.clip = curve;
		_body = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && !audioSource1.isPlaying) {
			audioSource1.Play();		
		}

		float steering = steeringUI.angle;

		if (Mathf.Abs (steering) > 50 && _body.velocity.magnitude > 0) {
			audioSource2.Play ();		
		} else if (Mathf.Abs (steering) < 10) {
			audioSource2.Stop ();
		}
	}
}
