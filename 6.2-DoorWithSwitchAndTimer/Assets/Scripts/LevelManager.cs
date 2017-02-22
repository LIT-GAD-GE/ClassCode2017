using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// References to various game objects in the scene
	public DoorController theDoor;

	// Variable to keep track of various game state
	public bool switchEnabled = false;

	// I am tracking if the door is closed or not because I want to disable use
	// of the spacebar to open the door if the the door is already open
	public bool doorClosed = true;

	public void OnSpacebarPressed() {
		Debug.Log ("LevelManager:OnSpacebarPressed");

		if ((switchEnabled == true) && (doorClosed == true)){
			doorClosed = false;
			theDoor.open ();
		}
	}

	// This function gets called by the SwitchController
	public void OnSwitchTriggerEnter() {
		Debug.Log ("LevelManager:OnSwitchTriggerEnter");

		// Let's enable the switch
		switchEnabled = true;
	}

	// This function gets called by the SwitchController
	public void OnSwitchTriggerExit() {
		Debug.Log ("LevelManager:OnSwitchTriggerExit");

		// Let's disable the switch
		switchEnabled = false;
	}

	// This function is called by the SwitchController once it has fully opened the
	// door. 
	public void OnDoorFullyOpen() {
		// Ok the door is fully open. I am going to wait 1 second and then 
		// close
		StartCoroutine("doorCloseTimer");
	}

	// This function is called by the SwitchController once it has fully closed the
	// door.
	public void OnDoorFullyClosed() {
		doorClosed = true;
	}

	private IEnumerator doorCloseTimer() {
		yield return new WaitForSeconds(1);

		// Ok the delay has passed, let's close the door
		theDoor.close();

	}
}
