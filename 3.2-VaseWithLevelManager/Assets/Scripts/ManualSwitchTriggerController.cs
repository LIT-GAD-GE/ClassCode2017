using UnityEngine;
using System.Collections;

public class ManualSwitchTriggerController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Someone entered the switch trigger");

		theLevelManager.manualSwitchTriggerEntered ();
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		theLevelManager.manualSwitchTriggerExited ();
	}
}
