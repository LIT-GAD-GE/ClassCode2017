using UnityEngine;
using System.Collections;

public class AutoSwitchTriggerController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		// Notify the Level Manager
		theLevelManager.switchTriggerEntered (other, gameObject);
		theLevelManager.autoSwitchTriggerEntered ();
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		theLevelManager.autoSwitchTriggerExited ();
	}
}
