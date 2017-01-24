using UnityEngine;
using System.Collections;

/*
 * This class enables (activates) the switch so that the player can turn it on/off
 * by pressing the spacebar.
 */
public class SwitchEnabler : MonoBehaviour {
	// The following variable allows me to setup a reference to the Switch
	// gameObject via the inspector.
	public Switch theSwitch;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Enabling switch");

		if (theSwitch != null) {
			theSwitch.enableSwitch();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Disabling switch");

		if (theSwitch != null) {
			theSwitch.disableSwitch();
		}
	}
}
