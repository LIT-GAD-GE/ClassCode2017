using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		theLevelManager.OnKeyTriggerEnter ();
	}
		

	public void OnPickUp() {
		Debug.Log ("Destroying key");
		Destroy (gameObject);
	}
}
