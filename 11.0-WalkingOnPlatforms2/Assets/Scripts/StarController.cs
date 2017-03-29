using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {
	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			theLevelManager.starCollected ();

			// I am assuming that once a star is collected it is always
			// destroyed, i.e. there is no game rule effecting this, so
			// I am going to destroy now
			GameObject.Destroy (gameObject);
		}
	}
}
