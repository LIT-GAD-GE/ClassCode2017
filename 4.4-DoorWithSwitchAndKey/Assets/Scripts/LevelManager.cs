using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public SwitchController theSwitch;
	public DoorController theDoor;
	public KeyController theKey;

	public bool switchActive = false;
	public bool switchOn = false;
	public bool heroHasKey = false;

	public void OnSwitchTriggerEnter()
	{
		switchActive = true;	
	}

	public void OnSwitchTriggerExit() {
		switchActive = false;
	}

	public void spacebarPressed() {
		if ((switchActive == true) && (switchOn == false)) {
			if (heroHasKey == true) {
				theSwitch.turnOn ();
				switchOn = true;
				theDoor.open ();
			}
		} else if ((switchActive == true) && (switchOn == true)) {
			theSwitch.turnOff ();
			switchOn = false;
			theDoor.close ();
		}
	}

	public void OnKeyTriggerEnter() {
		theKey.OnPickUp ();
		heroHasKey = true;
	}



}
