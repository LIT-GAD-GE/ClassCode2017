using UnityEngine;
using System.Collections;

public class AutoSwitchTriggerController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Someone entered the switch trigger");

		theLevelManager.autoSwitchTriggerEntered ();
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Someone left the switch trigger");

		theLevelManager.autoSwitchTriggerExited ();
	}
}
