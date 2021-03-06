﻿using UnityEngine;
using System.Collections;

public class SwitchBehavior : MonoBehaviour {

	public bool switchOn = false;
	public float leverRotationSpeed;
	public GameObject otherSwitch;
	private bool playerNear = false;

	void Update(){

		if (Input.GetButtonDown("Use") && playerNear){
			if (switchOn == true) {
				switchOn = false;
			}
			else {
				switchOn = true;
			}
			otherSwitch.GetComponent<SwitchBehavior>().switchOn = switchOn;
		}

		RotateLever ();
	}

	void RotateLever(){
		
		if (switchOn) {
			if (transform.eulerAngles.z > 45){
				transform.Rotate(-Vector3.forward * leverRotationSpeed * Time.deltaTime);  
			}
		}
		else{
			if (transform.eulerAngles.z < 90){
				transform.Rotate(Vector3.forward * leverRotationSpeed * Time.deltaTime);  
			}
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player"){
			playerNear = true;
		}
	}

	void OnTriggerExit(Collider col){

		if (col.tag == "Player"){
			playerNear = false;
		}
	}
}
