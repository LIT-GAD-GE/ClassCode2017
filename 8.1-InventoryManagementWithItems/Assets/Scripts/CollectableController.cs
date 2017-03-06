using UnityEngine;
using System.Collections;

public class CollectableController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		theLevelManager.OnCollectableTriggerEnter (this, other);
	}

	void OnTriggerExit2D(Collider2D other) {
		theLevelManager.OnCollectableTriggerExit (this, other);
	}

	public void OnPickedUp() {
		// What do we want to do when this collectable is picked up
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		sr.enabled = false;
	}
}
