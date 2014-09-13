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
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isEditor) { UpdateSettings(); }
	}

	// Modified Bezier Curve
	List<Vector3> Curve(Vector3 start, Vector3 end, Vector3 third) {
		List<Vector3> points = new List<Vector3>();

		for (int i = 1; i < sectors; i++) {
			float interval = (float)i / (float)sectors;

			Vector3 a = Vector3.Lerp( start, third, interval );
			Vector3 b = Vector3.Lerp( third, end, interval );

			Vector3 c = Vector3.Lerp(a, b, interval);

			points.Add(c);
		}
		points.Add(end);

		return points;
	}

	static int sectors = 10;
	void DrawCurve(Vector3 start, Vector3 end, Vector3 thirdChild) {
		List<Vector3> points = Curve(start, end, thirdChild);

		Vector3 lastPoint = start;
		foreach (Vector3 point in points) {
			Gizmos.DrawLine(lastPoint, point);
			lastPoint = point;
		}
	}

	void OnSceneGUI() {

	}

	void OnDrawGizmos() {
		if (Application.isEditor) { UpdateSettings(); }

		for (int i = 0; i < children.Count; i++) {
			Transform child = children[i];

			var nextChild = children[(i+1) % children.Count];
			var thirdChild = child.Find("CurveControl");

	        Gizmos.color = Color.yellow;
	        // Gizmos.DrawLine(child.position, nextChild.position);

	        var delta = thirdChild.position - child.position;

	        Vector3 up = new Vector3(0, 1, 0);
	        Vector3 perp = Vector3.Cross(delta, up).normalized;

	        Gizmos.DrawLine(child.position, child.position - delta.normalized*1 + perp);
	        Gizmos.DrawLine(child.position, child.position - delta.normalized*1 - perp);

			DrawCurve(child.position, nextChild.position, thirdChild.position);
		}
	}
}
