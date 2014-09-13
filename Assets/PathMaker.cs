using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathMaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	List<Transform> children;
	void UpdateSettings() {
		children = new List<Transform>();

		foreach (Transform child in transform) {
			children.Add(child);
		}
		Debug.Log(children.Count);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isEditor) { UpdateSettings(); }
	}

	void OnDrawGizmos() {
		if (Application.isEditor) { UpdateSettings(); }

		for (int i = 0; i < children.Count; i++) {
			Transform child = children[i];
			var nextChild = children[(i+1) % children.Count];

	        Gizmos.color = Color.yellow;
	        Gizmos.DrawLine(child.position, nextChild.position);

	        var delta = nextChild.position - child.position;
	        var midPoint = child.position + delta/2;

	        Gizmos.DrawSphere(midPoint, 1);
	        Gizmos.DrawSphere(midPoint - delta.normalized*1, 1);
		}
	}
}
