using UnityEngine;
using System.Collections;

public class CarSound : MonoBehaviour {

	public AudioClip drive;
	public AudioClip curve;
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	public SteeringUI steeringUI;

	// Use this for initialization
	void Start () {
		audioSource1.clip = drive;
		audioSource2.clip = curve;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && !audioSource1.isPlaying) {
			audioSource1.Play();		
		}

		float steering = steeringUI.angle;

		if (Mathf.Abs (steering) > 50 && rigidbody.velocity.magnitude > 0) {
			audioSource2.Play();		
			
		} 
	}
}
