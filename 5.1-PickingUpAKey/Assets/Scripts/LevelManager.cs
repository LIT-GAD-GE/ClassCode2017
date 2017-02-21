using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public HeroController theHero;
	public KeyController theKey;

	// Variables to keep track of the "state" of various game Objects in the scene
	public bool keyPickedUp = false;

	// the following is called by the KeyController when the box collider of the key is triggered
	public void OnKeyTriggerEnter() {
		Debug.Log ("LevelManager:OnKeyTriggerEnter");

		if (keyPickedUp == false) {
			// Ok, someone (we assume the hero) has collided with the key. Lets
			// tell the Hero to add the key as a child. Notice that I am passing theKey
			// as an argument to the pickupKey function i.e. not only am I telling
			// theHero to pickup the key (by calling the pickupKey function) but I am
			// also giving theHero the key which I want it to pickup. While this may not be 
			// so impressive now (as I only have one key), if I add more keys this will
			// be handy
			theHero.pickupKey (theKey);
			keyPickedUp = true;
		} else {
			// The keyPickedUp variable is true but someone (presumably the Hero) has just
			// entered the Keys trigger. This is because the Hero has just dropped the
			// key but is still touching it. Rather than pick the key up again let's
			// just set keyPickedUp to false. This means that if the Here moves away from the
			// Key and then moves back and touches it, it will pick the key up again.
			keyPickedUp = false;
		}
	}
		

	// This is called by the InputManager
	public void OnXKeyPressed() {

		// If I have already picked up the key ...
		if (keyPickedUp == true){

			/* The dropKey function on the HeroController is going to remove the Hero as a parent
			 * of the key. This will instantly cause the OnTriggerEnter2D to be called on the 
			 * KeyController as the Hero will 'enter' the trigger box of the Key unless the key is
			 * dropped "away" from the Hero.
			 * 
			 * Remember, the OnTriggerEnter2D function is called by unity when an object FIRST
			 * enters the trigger box of another object i.e. it is not constantly called (as 
			 * opposed to OnTriggerStay2D which is). So when the Hero drops the Key, the Hero and
			 * the Key once again collide (assuming the Key has been dropped where the Hero is)
			 * and, as such, the OnTriggerEnter2D function on the KeyController will be called. The
			 * calling of OnTriggerEnter2D on the KeyController will result in OnKeyTriggerEnter to
			 * be called on this class, the LevelManager, which will in turn cause the key to be 
			 * picked up again - essentially resulting in me not being able to drop the key.
			 * 
			 * There are a few ways I could get over this:
			 * 	1. 	When I "drop" the key I could drop it away from the Hero so that the Keys' 
			 * 		OnTriggerEnter2D is not called.
			 * 	2. 	This solution requires me to add a boolean to the LevelManager called 
			 * 		keyPickedUp (or something similar) and initialise it to false. When the Hero
			 * 		picks up the Key I set keyPickedUp to true. When I (the LevelManager) tell the
			 * 		Hero to drop the key I DON'T set keyPickedUp to false. Instead, I wait for the
			 * 		OnKeyTriggerEnter function to be called and at that point I check to see if
			 * 		keyPickedUp is true and if so I set it to false.
			 */

			theHero.dropKey(theKey);

		}
		
	}
}
