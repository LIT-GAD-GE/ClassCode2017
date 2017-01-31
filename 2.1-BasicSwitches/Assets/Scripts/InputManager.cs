using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	// Set up a reference to the Switch via the inspector. Things are starting to get
	// a little out of hand now. This is the 3rd script that has a reference to the Switch.
	// What's going to happen when we have multiple Switches and Doors etc.....
	public SwitchController theSwitch;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) == true) {
			if (theSwitch != null) {
				theSwitch.toggleSwitch ();
			}
		}
	}
}
