using UnityEngine;
using System.Collections;

/*
 * The LevelManager is the "brains" of the level. It implements the level game rules. When things
 * happen I am going to "tell" the LevelManager (by calling one of it's functions) and then the
 * LevelManager can decide what to do.)
 */
public class LevelManager : MonoBehaviour {
	// References to various game level object scripts. Notice that these are references to scripts
	// attached to game objects and not the game objects themselves.
	public BulbController theBulb;
	public SwitchController theAutoSwitch;
	public SwitchController theManualSwitch;


	// The Start functioin is used to iitialise class variables, i.e. those variables above, based
	// on the state of other objects in the scene AND/OR use the start function to set the state of
	// other objects in the scene, i.e. like I am doing below in this start function
	void Start () {
		// Lets initialise the game level objects to their starting state
		theBulb.turnOff();
		theAutoSwitch.turnOff();
		theManualSwitch.turnOff ();
	}

	public void autoSwitchTriggerEntered() {

		// Ok, the player has just triggered the switch, let's turn on
		// the switch and the buld
		theAutoSwitch.turnOn ();
		theBulb.turnOn ();

	}

	public void autoSwitchTriggerExited() {

		theAutoSwitch.turnOff ();
		theBulb.turnOff ();
	}

	public void manualSwitchTriggerEntered() {

		theManualSwitch.enableSwitch ();
	}

	public void manualSwitchTriggerExited() {

		theManualSwitch.disableSwitch ();
	}

	public void toggleSwitch() {
		theManualSwitch.toggleSwitch();

		if (theBulb.bulbOn == false) {
			theBulb.turnOn();
		} else {
			theBulb.turnOff();
		}
	}

	public void switchTriggerEntered(Collider2D other, GameObject gameObjectTriggered) {
		Debug.Log (other.name + " just collided with " + gameObjectTriggered.name);

		if (gameObjectTriggered.name == "AutoSwitchTrigger" && other.name == "Hero") {
			// Ok, the player has just triggered the switch, let's turn on
			// the switch and the buld
			theAutoSwitch.turnOn ();
			theBulb.turnOn ();
		}

		if (gameObjectTriggered.name == "ManualSwitchTrigger" && other.name == "Hero") {
			theManualSwitch.enableSwitch ();
		}
				
	}
}