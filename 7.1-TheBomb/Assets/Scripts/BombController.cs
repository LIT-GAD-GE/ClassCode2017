using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {
	public LevelManager theLevelManager;

	public float floorYPosition;

	void Awake() {
		floorYPosition = transform.position.y;
	}

	void OnTriggerEnter2D(Collider2D other) {
		theLevelManager.OnBombTriggerEnter ();
	}

	public void OnPickedUp() {
		// Do we want to do anything when we pick up this bomb
	}

	public void OnDropped() {
		Vector3 currentPos = transform.position;
		currentPos.y = floorYPosition;
		transform.position = currentPos;
	}

	public void explode() {
		Destroy (gameObject);
	}
}
