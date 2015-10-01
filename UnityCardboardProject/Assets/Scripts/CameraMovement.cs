﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private bool goingForward = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		const float step = 0.015f;

		if (Cardboard.SDK.VRModeEnabled) {
			if( goingForward ){
				transform.Translate (step * Vector3.forward);
				if( transform.position.y < 5.0f ){
					goingForward = false;
				}
			}else{
				transform.Translate (-step * Vector3.forward);
				if( transform.position.y > 10.0f ){
					goingForward = true;
				}
			}
		} else {
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (step * Vector3.forward);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (-step * Vector3.forward);
			}
		}
	}
}
