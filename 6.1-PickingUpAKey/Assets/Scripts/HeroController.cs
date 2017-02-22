using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	public void pickupKey(KeyController theChildKey){
		// Set the parent of the transform of the key to be the transform of the game object
		// this script is attached to i.e. theHero
		theChildKey.gameObject.transform.parent = transform;

		// Set the "local" position of the key. By local I mean the position of the key
		// relative to it's parent. I'm setting the key to be 0.5 units right of the 
		// center of the key and 0.5 units down from the center of the key
		theChildKey.gameObject.transform.localPosition = new Vector3 (0.5f, -0.5f, 0);

		// Mmmm should theHero tell the key that is has been picked up or should the
		// LevelManager tell the key seeing as the LevelManager is the "brains" of the
		// operation. The rule of thumb I use is this: if you sometimes tell the key it has
		// been picked up and other times you don't (maybe depending on some game rule)
		// then you should put the code in the LevelManager. If on the other hand you
		// always tell the key it has been picked up then putting the code here is fine
		// i.e. it doesn't depend on some game rule.
		//
		// So I am putting the code here ....
		theChildKey.OnPickup ();
	}

	public void dropKey(KeyController theChildKey) {
		Debug.Log ("HeorController::dropChild");

		// Set the parent of the keys transform to null (nothing)
		theChildKey.gameObject.transform.parent = null;

		// Because you can't read and write to the position all in one
		// go like this:
		//
		// theChildKey.gameObject.transform.position.y = -1.78f;
		//
		// I first get the position and store it in a local variable, I then
		// modify this local variable and finally I overwrite the position
		// with the local variable
		//
		// BTW I am setting the y position to -1.78 because having looked at the 
		// y value in the inspector when the key is on the ground I know this is
		// what it needs to be.
		Vector3 currentPos = theChildKey.gameObject.transform.position;
		currentPos.y = -1.78f;
		theChildKey.gameObject.transform.position = currentPos;

		// Inform the key it has been dropped
		theChildKey.OnDrop ();
	}
}
