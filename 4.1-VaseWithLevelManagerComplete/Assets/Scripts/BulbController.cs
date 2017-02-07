using UnityEngine;
using System.Collections;

/* 
 * This script is attached to the Buld GameObject to control it
 */
public class BulbController : MonoBehaviour {
	// I need a variable to hold the bulb's animator
	private Animator bulbAnimator;

	// I need to add variable to keep track of the state of the buld so that
	// the InputManager knows if the buld is on or not so it can toggle it
	public bool bulbOn;

	void Awake () {
		// Let's get the Animator component that is attached to this game object and
		// store it in our bulbAnimator. Getting it now, once, saves us having to get
		// it every time we need.
		bulbAnimator = gameObject.GetComponent<Animator> ();

		// Let's turn off the bulb initially
		turnOff ();
	}
		
	
	public void turnOn() {
		// There is an Animator property called On which is used to transition
		// from the BulbOn state and the BuldOff state, let's set it to
		// true so that the BuldOn state becomes activate.
		bulbAnimator.SetBool ("On", true);

		bulbOn = true;
	}

	public void turnOff() {
		// Transitioin the Animator to the BuldOff state
		bulbAnimator.SetBool ("On", false);

		bulbOn = false;
	}

}
