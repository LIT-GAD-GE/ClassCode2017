using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	// A reference to the Level Manager. The variable is setup via the inspector
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		// Notify the Level Manager the a game object has entered the trigger collider
		// of the switch
		theLevelManager.OnSwitchTriggerEnter ();
	}

	void OnTriggerExit2D(Collider2D other) {
		theLevelManager.OnSwitchTriggerExit ();
	}
}
