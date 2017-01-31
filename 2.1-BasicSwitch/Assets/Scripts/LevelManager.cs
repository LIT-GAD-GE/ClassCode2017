using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	// References to various game level objects
	public BulbController theBulb;
	public Switch theSwitch;


	// Use this for initialization
	void Start () {
		// Lets initialise the game level objects to their starting state
		theBulb.turnOff();
		theSwitch.turnOff();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchTriggerEntered() {
		// Ok, the player has just triggered the switch, let's turn on
		// the switch and the buld
		theSwitch.turnOn();
		theBulb.turnOn();
	}

	public void switchTriggerExited() {
		theSwitch.turnOff ();
		theBulb.turnOff ();
	}
}
