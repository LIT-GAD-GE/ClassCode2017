using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	// Reference to the Level Manager which needs to be set via the inspector
	public LevelManager theLevelManager;

	/* Called by Unity when another game object (which has a 2D Collider component) enters
	 * the trigger collider of this game object/
 	 *
 	 * Notice that this function doesn't have an access modifier specified. An access modifier
 	 * is a keyword like 'public' or 'private' that is placed before the function definition and
 	 * which determines whether or not the function can be called by other scripts. All functions
 	 * that Unity call to notify you that something has happened (such functions are known as 
 	 * Message functions, see a list of MonoBehaviour Message functions here 
 	 * https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) don't have an access
 	 * modifies specified and, indeed, if you do they won't work.
 	 */
	void OnTriggerEnter2D(Collider2D other) {

		/*
		 * Notice when we call the function OnSwitchTriggerEnter below the first argument we
		 * pass is 'this'. 'this' is a special variable that is available in all scripts and it
		 * is a variable that holds a reference to an object of the script it is in i.e. an 
		 * object of this script. So in this script the 'this' variable holds a reference to 
		 * a SwitchCollider object.
		 * 
		 * The second argument is a variable called other, which is a reference to a Collider2D
		 * object, which Unity passed into this function when it called it. This 'other' ColliDer2D
		 * object contains a bunch of methods that we can call to find out more information about 
		 * the other game object that is envolved in this trigger collision. See the link below:
		 * https://docs.unity3d.com/ScriptReference/Collider2D.html.
		 * 
		 * The reason I am passing (giving) the OnSwitchTriggerEnter function these two arguments
		 * is so that the OnSwitchTriggerEnter can (a) use the reference to this object to figure
		 * out name of the Switch that called it and (b) find out some information about the 
		 * other game object in the collision if it needs to.
		 * 
		 * I could have done something like
		 * 
		 * 		theLevelManager.OnSwitchTriggerEnter("Switch1", other);
		 * 
		 * but then this wouldn't work for Switch2 or Switch3.
		 */

		theLevelManager.OnSwitchTriggerEnter(this, other);
	}

	void OnTriggerExit2D(Collider2D other) {
		theLevelManager.OnSwitchTriggerExit (this, other);
	}

	/*
	 * This function will scale the game object this script is attached to by the scaleFactor
	 * specified.
	 */
	public void scale(float scaleFactor) {

		// Get the current scale
		Vector3 currentScale = gameObject.transform.localScale;

		// Multiply the x, y, and z components by the scaleFactor
		currentScale.x *= scaleFactor;
		currentScale.y *= scaleFactor;
		currentScale.z *= scaleFactor;

		// overwrite the scale of the transform component
		gameObject.transform.localScale = currentScale;

	}
}
