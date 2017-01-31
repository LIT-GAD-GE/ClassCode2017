using UnityEngine;
using System.Collections;

public class ManualSwitchTriggerController : MonoBehaviour {
	// Here I have a reference to the ScitchController so that I can enable/disable the switch
	public SwitchController theSwitch;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Someone entered the switch trigger");

		theSwitch.enableSwitch ();
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		theSwitch.disableSwitch ();
	}
}
