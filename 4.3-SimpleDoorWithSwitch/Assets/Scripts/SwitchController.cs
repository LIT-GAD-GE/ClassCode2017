using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		theLevelManager.OnSwitchTriggerEnter ();
	}

	void OnTriggerExit2D(Collider2D other) {
		theLevelManager.OnSwitchTriggerExit ();
	}
}
