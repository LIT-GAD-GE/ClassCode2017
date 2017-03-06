using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public InventoryUIManager theInventoryUIManager;

	public List<CollectableController> collectedApples = new List<CollectableController>();
	public List<CollectableController> collectedOranges = new List<CollectableController>();
	public List<CollectableController> collectedCheese = new List<CollectableController>();

	private CollectableController activeCollectible;

	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			pickupCollectable();
		}
	}

	public void OnCollectableTriggerEnter(CollectableController theCollectable, Collider2D other) {
		
		if (other.name == "Hero") {
			activeCollectible = theCollectable;
		}		
	}

	public void OnCollectableTriggerExit(CollectableController theCollectable,Collider2D other) {

		if (theCollectable.Equals(activeCollectible) && (other.name == "Hero")) {
			activeCollectible = null;
		}		
	}

	private void pickupCollectable () {
		if (activeCollectible != null) {
			if (activeCollectible.tag == "apple") {
				collectedApples.Add (activeCollectible);
				theInventoryUIManager.addApple ();
			} else if (activeCollectible.tag == "orange") {
				collectedOranges.Add (activeCollectible);
				theInventoryUIManager.addOrange ();
			} else if (activeCollectible.tag == "cheese") {
				collectedCheese.Add (activeCollectible);
				theInventoryUIManager.addCheese ();
			}
				
			activeCollectible.OnPickedUp ();
		}
	}
}
