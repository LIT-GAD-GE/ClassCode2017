using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {
	// The following variable allows me to setup a reference to the Switch
	// gameObject via the inspector.
	public Switch theSwitch;


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Someone entered the switch trigger");

		if (theSwitch != null) {
			// Cool, theSwitch property has been set. I can safely call the turnOn function
			theSwitch.turnOn();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		// The following code demonstrates how I can get the Switch script component
		// from the parent gameObject without using theSwitch property tha was set via
		// the inspector.

		// First lets get the parent transform, that is the transform of the
		// gameObject that is the parent of this gameObject
		Transform parentT = transform.parent;

		// We better check that parentT is not null. It will be null if the
		// gameObject this script is attached doesn't have a parent game object.
		// If parentT is not null then lets get the gameObject the transform belongs to
		// and the Switch (script) component of that gameObject

		if (parentT != null) {
			// Ok we have a parent
			Switch s = parentT.gameObject.GetComponent<Switch>();

			// Maybe for some reason the parent gameObject doesn't have a
			// Switch component attached to it (in which case s would be null)

			if (s != null) {
				// Cool, all is as expected and we have the Switch component (script) so 
				// now all that's left to do is call the turnOff function on it.
				s.turnOff();
			}
		}

	}
}
