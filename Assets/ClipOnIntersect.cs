using UnityEngine;
using System.Collections.Generic;

public class ClipOnIntersect : MonoBehaviour {
	public Dictionary<int,string> _instanceid_to_collision_normal = new Dictionary<int, string>();
	void OnTriggerEnter(Collider collider) {
		_instanceid_to_collision_normal[collider.GetInstanceID()] = collider.gameObject.name;
	}

	void OnTriggerExit(Collider collider) {
		if (_instanceid_to_collision_normal.ContainsKey(collider.GetInstanceID()))
			_instanceid_to_collision_normal.Remove(collider.GetInstanceID());
	}

	void Update() {
		bool clip = false;
		foreach(string name in _instanceid_to_collision_normal.Values){
			if (name == "world") clip = true;
		}
		if (clip) {
			this.gameObject.GetComponent<Camera>().nearClipPlane = 23;
		} else {
			this.gameObject.GetComponent<Camera>().nearClipPlane = 0.1f;
		}
	}
}
