using UnityEngine;
using System.Collections;

/* 
 * This script is attached to the Buld GameObject to control it
 */
public class BulbController : MonoBehaviour {
	// I need a variable to hold the bulb's animator
	private Animator bulbAnimator;

	// Use this for initialization
	void Start () {
		// Let's get the Animator component that is attached to this game object and
		// store it in our bulbAnimator. Getting it now, once, saves us having to get
		// it every time we need.
		bulbAnimator = gameObject.GetComponent<Animator> ();
	}
	
	public void turnOn() {
		// There is an Animator property called On which is used to transition
		// from the BulbOn state and the BuldOff state, let's set it to
		// true so that the BuldOn state becomes activate.
		bulbAnimator.SetBool ("On", true);
	}

	public void turnOff() {
		// Transitioin the Animator to the BuldOff state
		bulbAnimator.SetBool ("On", false);
	}

}
