using UnityEngine;
using System.Collections;

public class AutoSwitchTriggerController : MonoBehaviour {
	// Here I have a reference to the ScitchController so that I can turn on and off the switch
	public SwitchController theSwitch;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Someone entered the switch trigger");

		theSwitch.turnOn ();
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		theSwitch.turnOff ();
	}
}
