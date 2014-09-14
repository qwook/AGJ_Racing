using UnityEngine;
using System.Collections;

public class PeddleUI : MonoBehaviour {

	public Texture texture;
	public float peddle;

	bool peddling = false;
	Vector2 startCursorPosition;
	float startPeddle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Settings
	Rect rect;
	Rect screen;
	void UpdateSettings() {
		rect = new Rect(0, 0, 100, 100);
		screen = new Rect(400, 250, 500, 500);

		ProcessedSettings();
	}

	// Variables processed from settings
	// Vector2 pivot;
	void ProcessedSettings() {
		// pivot = new Vector2(rect.x+rect.width/2, rect.y+rect.height/2);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isEditor) { UpdateSettings(); }
	}

	// Draw GUI	
	void OnGUI () {
		GUI.BeginGroup(screen);
		Vector2 cursorPosition = Event.current.mousePosition;

		if (Input.GetMouseButtonDown(0)) {
			if (rect.Contains(cursorPosition)) {
				peddling = true;
				startCursorPosition = cursorPosition;
				startPeddle = peddle;
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			peddling = false;
		}

		if (peddling) {
			Vector2 deltaCursorPosition = cursorPosition - startCursorPosition;
			peddle = (startPeddle + deltaCursorPosition.y) / 50.0f;

			if (peddle > 1) {
				peddle = 1;
			}
		} else {
			if (peddle > 0) {
				peddle -= Time.deltaTime*2;
				if (peddle < 0) {
					peddle = 0;
				}
			}
		}

		rect.y = peddle*25;
		rect.height = 100-peddle*25;

		GUI.color = new Color(1.0f-peddle/2f, 1.0f-peddle/2f, 1.0f-peddle/2f, 1.0f); 

		GUI.DrawTexture(rect, texture);

		GUI.EndGroup();
	}

}
