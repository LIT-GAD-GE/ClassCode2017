using UnityEngine;
using System.Collections;

public class CollectableController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collectable trigger entered");
		theLevelManager.CollectableTriggerEntered (this, other);
	}
}
