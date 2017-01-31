using UnityEngine;
using System.Collections;

public class DumbSwitchTrigger : MonoBehaviour {
	// I need a reference to the LevelManager so that I can notify it whenever
	// this Trigger is activaated/deactiavted. The LevelManager is the "brains"
	// of the operation.
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Someone entered the switch trigger");

		// I'm not going to do anything other than notify the LevelManager. It can
		// decide what to do.
		theLevelManager.switchTriggerEntered();
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		theLevelManager.switchTriggerExited();
	}
}
