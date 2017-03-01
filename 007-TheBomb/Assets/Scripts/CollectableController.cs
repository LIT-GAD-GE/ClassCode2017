using UnityEngine;
using System.Collections;

public class CollectableController : MonoBehaviour {
	public LevelManager theLevelManager;

	public float floorYPosition;

	void Awake() {
		floorYPosition = transform.position.y;
	}

	void OnTriggerEnter(Collider2D other) {
		theLevelManager.OnCollectableTriggerEnter (this, other);
	}

	public void OnPickedUp() {
		// Do we want to do anything when we pick up this collectable
	}

	public void OnDropped() {
		Vector3 currentPos = transform.position;
		currentPos.y = floorYPosition;
		transform.position = currentPos;
	}
}
