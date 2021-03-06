﻿using UnityEngine;
using System.Collections;

public class MainmenuButtonPressed : MonoBehaviour {
	
	void Update () {
		EditorCheck ();
	}
	
	void AndroidCheck() {
		if (Input.GetTouch(0).phase == TouchPhase.Ended) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null && hit.collider != null) {
				switch (hit.collider.name) {
				case "Play":
					Application.LoadLevel("Beginning");
					break;
				case "Thanks":
					Application.LoadLevel("ThanksMenu");
					break;
				case "Exit":
					Application.Quit();
					break;
				case "HowToPlay":
					Application.LoadLevel("HowToPlayMenu");
					break;
				}
			}
		}
	}
	
	void EditorCheck() {
		if (Input.GetMouseButtonUp(0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null && hit.collider != null) {
				switch (hit.collider.name) {
				case "Play":
					Application.LoadLevel("Beginning");
					break;
				case "Thanks":
					Application.LoadLevel("ThanksMenu");
					break;
				case "Exit":
					Application.Quit();
					break;
				case "HowToPlay":
					Application.LoadLevel("HowToPlayMenu");
					break;
				}
			}
		}
	}
}

