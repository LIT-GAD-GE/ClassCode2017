using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {
	// switchAnimator will hold the gameobjects Animator
	private Animator switchAnimator;

	// The Awake function of each class is called before the Start function. It is
	// here you should initialise class properties/variables like those above.
	void Awake() {
		// Get the Animator off the game object this script is attached to as
		// we'll need it later
		switchAnimator = gameObject.GetComponent<Animator> ();

		// Let's turn off the switch to start with
		turnOff();
	}

	public void turnOn() {
		switchAnimator.SetBool("SwitchOff", false);
	}

	public void turnOff() {
		switchAnimator.SetBool("SwitchOff", true);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		
	}

	public void OnTriggerExit2D(Collider2D other {
		
	}
}
