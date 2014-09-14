using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointControl : MonoBehaviour {
	
	Transform myTransform;	
	float timer = 0.0f;
	int checkpointCounter = 0;		
	GameObject[] checkpointLocations;
	List<float> lapTimes = new List<float>();

	int currentLap = 1;
	int totalLaps = 2;


	// Use this for initialization
	void Start () {
		myTransform = transform;
		checkpointCounter = 0;	

		//get positions of possible checkpoint spawn locations
		checkpointLocations = GameObject.FindGameObjectsWithTag("Checkpoint");

		myTransform.position = checkpointLocations[Util.rand.Next(checkpointLocations.Length)].transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		//timer
			timer += Time.deltaTime;				


	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			col.GetComponent<CarControlScript>()._start_pos = myTransform.position;
			myTransform.position = checkpointLocations[Util.rand.Next(checkpointLocations.Length)].transform.position;
			return;
		}
	}

	/**
	void OnTriggerEnter(Collider col){

		if (col.tag == "Player") {
			
			
			myTransform.position = checkpointLocations[Util.rand.Next(checkpointLocations.Length)].transform.position;
			return;

			Debug.Log ("YOU HIT ME");

			if(checkpointCounter < checkpointLocations.Length){
				
				//move checkpoint to next location
				Vector3 newLocation = checkpointLocations[checkpointCounter].transform.position;
				
				transform.position = newLocation;
				Debug.Log ("Moved to: "+newLocation);
				
				checkpointCounter++;
			}else{ //Hit the last checkpoint
				currentLap++;
				float lapTime = timer;

				if(currentLap <= totalLaps){
					//Reset Checkpoints (Do another lap)
					checkpointCounter = 0;
					//Add lap time
					lapTimes.Add(lapTime);
					//Reset Timer;
					timer = 0.0f;

				}else{ //END GAME

					float totalTime = 0.0f;

					lapTimes.Add(lapTime);
					
					Debug.Log ("DONE!");

					//TODO: make a end screen for these results:
					foreach(float laptime in lapTimes){
						Debug.Log("lap score: "+laptime );
						totalTime += laptime;
					}

					Debug.Log ("Total Time: "+totalTime);

					Destroy(this);
				}
			}


		}
	}
	**/




		//Active a different checkpoint




}
	