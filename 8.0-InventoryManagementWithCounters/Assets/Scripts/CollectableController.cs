using UnityEngine;
using System.Collections;

/* 
 * This script could be attached to any GameObject that is a collectable. The script notifies the LevelManager when the
 * items trigger box is entered and exited. The Levelmanager notifies the collectable when it is collected by calling the
 * function OnCollected.
 * 
 * When notifying the LevelManager that this Collectable's trigger box has been entered/exited, the CollectableController
 * calls the function OnCollectableTriggerEnter/OnCollectableTriggerExit on the LevelManager. Both these functions take
 * two arguments, the first is the variable 'this' which is a reference to "this CollectableController component" (remember there can
 * be many CollectableController components (objects) in the scene i.e. one attached to each collectable game object), and the
 * second argument is the Collider2D object that Unity passes into the OnTriggerEnter2D/OnTriggerEnter2D function. The
 * LevelManager can use these arguments to determine what game object triggered what collectable.
 * 
 */
public class CollectableController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		theLevelManager.OnCollectableTriggerEnter (this, other);
	}

	void OnTriggerExit2D(Collider2D other) {
		theLevelManager.OnCollectableTriggerExit (this, other);
	}

	public void OnCollected() {
		// What do we want to do when collected. For prototyping purposes I'm simple disable the
		// SpriteRender and the Trigger box

		// Get the SpriteRender component
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		// Set enable to false
		sr.enabled = false;

		BoxCollider2D bc = GetComponent<BoxCollider2D> ();
		bc.enabled = false;
	}
}
