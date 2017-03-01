using UnityEngine;
using System.Collections;
using UnityEditor.VersionControl;
using System.Collections.Generic;
using System.ComponentModel;

public class LevelManager : MonoBehaviour {
	public HeroController theHero;

	public bool bombPickedUp = false;
	public List<CollectableController> collectedItems = new List<CollectableController> ();

	public void OnCollectableTriggerEnter(CollectableController theCollectable, Collider2D other) {
		if ((theCollectable.tag == "Bomb") && (other.name = "Hero")) {

			if (collectedItems.Contains(theCollectable) == false) {
				theHero.pickupCollectable (theCollectable);
				collectedItems.Add (theCollectable);
			} else {
				collectedItems.Remove (theCollectable);
			}
		}
	}

	public void OnXKeyPresses() {
		if (collectedItems.Count != 0) {
			theHero.dropCollectable (collectedItems [collectedItems.Count]);
		}
	}
}
