using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	// The Level Manager needs to be connected with the following scrips. Note
	// that I have to set up these variables via the inspector

	// The SwitchController
	public SwitchController theSwitch;

	// The VaseController (I'll leave you finish this off)
	public VaseController theVaseController;

	// Variables to stote the state of various game objects in the scene
	public bool switchEnabled = false;
	public bool switchOn = false;
	public bool vaseOnLedge = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spacebarPressed() {
		if (switchEnabled == true) {

			if (switchOn == false) {
				theSwitch.turnOn ();
				switchOn = true;
				// Make the vase fall
				if (vaseOnLedge == true) {
					theVaseController.fall ();
					vaseOnLedge = false;
				}

			} else {
				theSwitch.turnOff ();
				switchOn = false;
			}

		}
	}

	public void onSwitchTriggerEnter() {
		switchEnabled = true;
	}

	public void onSwitchTriggerExit() {
		switchEnabled = false;
	}
}
