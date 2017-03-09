using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*
 * This LevelManager can not only keep track of how many of a particular Collectable has been collected but
 * it also stores the Collectable in a List. This probably isn't required for 99% of use cases but here is
 * how you would do it just in case.
 * 
 */
public class LevelManager : MonoBehaviour {

	/*
	 * This is a reference to the InventoryUIManager, a script I wrote and attached to the InventoryPanel (which
	 * is a child of Canvas). This variable needs to be set via the inspector.
	 */
	public InventoryUIManager theInventoryUIManager;

	/*
	 * Below are three int's that keep track of number of collectables that have been collected. There is an int
	 * for each collectable type (i.e. apple, orange, cheese). Note that the InventoryUIManager also keeps a count
	 * of what has been collected so that it can update the UI. There is an argument that we only need either
	 * the LevelManager Or the InventoryUIManager to keep track of the count but I have placed a count in both
	 * places just to keep things simple.
	 */
	public int collectedApples = 0;
	public int collectedOranges = 0;
	public int collectedCheese = 0;

	/*
	 * A reference to the "active" collectable. the active collectable is the collectable the Hero is "standing in 
	 * front of" i.e. triggered. Note this solution would start to break down if two collectables were close 
	 * togeather and the Hero could be triggering both at the same time.
	 */
	private CollectableController activeCollectible;

	/* For this example I have decided to incorporate the code that I usually put in an InputManager script here
	 * into the LevelManager. These keeps everything in the one place.
	 */
	void Update () {
		// If the player presses P then call pickupCollectable
		if (Input.GetKeyDown(KeyCode.P)) {
			pickupCollectable();
		}
	}

	public void OnCollectableTriggerEnter(CollectableController theCollectable, Collider2D other) {
		
		// If it is the Hero that has triggered the Collectable then make the Collectable the
		// active collectable
		if (other.name == "Hero") {
			activeCollectible = theCollectable;
		}		
	}

	public void OnCollectableTriggerExit(CollectableController theCollectable,Collider2D other) {

		// If the Hero has just exited the trigger box os a collectable and the collectable is
		// the active collectible, then set the active collectable to null (nothing)
		if ((other.name == "Hero") && (theCollectable.Equals(activeCollectible))) {
			activeCollectible = null;
		}		
	}

	/*
	 * This function first checks that the activeCollectable is set to something and if it is
	 * it increments that collectables count based on the collectables tag. It 
	 * then updates the UI and notifies the collectable that it has been collected.
	 */
	private void pickupCollectable () {
				
		if (activeCollectible != null) {
			if (activeCollectible.tag == "apple") {
				collectedApples++;
				theInventoryUIManager.addApple ();
			} else if (activeCollectible.tag == "orange") {
				collectedOranges++;
				theInventoryUIManager.addOrange ();
			} else if (activeCollectible.tag == "cheese") {
				collectedCheese++;
				theInventoryUIManager.addCheese ();
			}
				
			// Notify the collectable that it has been collected
			activeCollectible.OnCollected ();

			// Set activeCollectible to null
			activeCollectible = null;
		}
	}
}
