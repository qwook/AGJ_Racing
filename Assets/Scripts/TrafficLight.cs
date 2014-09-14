using UnityEngine;
using System.Collections;

public class TrafficLight : MonoBehaviour {

	float timer = 1.1f;
	float delayTime = 1.0f;
	int counter = 0;
	public bool gameStart = false;
	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject green2;
	public GameObject yellow2;
	public GameObject red2;

	// Use this for initialization
	void Start () {
		red.SetActive (true);
		yellow.SetActive (false);
		green.SetActive (false);
		red2.SetActive (true);
		yellow2.SetActive (false);
		green2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			timer = delayTime;
			counter++;
		}

		if (counter == 1) {
			red.SetActive (false);
			yellow.SetActive (true);
			red2.SetActive (false);
			yellow2.SetActive (true);
		} else if (counter == 2) {
			yellow.SetActive (false);
			green.SetActive (true);
			yellow2.SetActive (false);
			green2.SetActive (true);
		} else if (counter == 3) {
			green.SetActive(false);
			green2.SetActive(false);
			gameStart = true;
			gameObject.SetActive(false);
		} 
						
	}
}
