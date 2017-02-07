using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public LevelManager theLevelManager;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) == true) {
			theLevelManager.spacebarPressed ();
		}
	}
}
