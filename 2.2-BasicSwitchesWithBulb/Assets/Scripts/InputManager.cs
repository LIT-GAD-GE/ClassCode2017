using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	// Set up a reference to the Switch via the inspector. Things are starting to get
	// a little out of hand now. This is the 3rd script that has a reference to the Switch.
	// What's going to happen when we have multiple Switches and Doors etc.....
	public SwitchController theSwitch;

	// We need a reference to the BulbController so we can turn the Buld on/off
	public BulbController theBulb;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) == true) {
			if (theSwitch != null) {
				if (theSwitch.toggleSwitch () == true) {
					// Ok, the toggleSwitch function returned true so that means it
					// toggled the switch so now we need to toggle the bulb. I have
					// added a buldOn property to the BulbController so that I can tell 
					// if the bulb is on or off so that I can toggle it
					if (theBulb.bulbOn == true) {
						theBulb.turnOff ();
					} else {
						theBulb.turnOn ();
					}
				}
			}
		}
	}
}
