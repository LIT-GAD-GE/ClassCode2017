using UnityEngine;
using System.Collections;

public class ChildTriggerController : MonoBehaviour {
	public CharacterController theCharacterController;

	void OnTriggerEnter2D(Collider2D other) {
		theCharacterController.OnChildTriggerEnter2D (this, other);
	}

	void OnTriggerExit2D(Collider2D other) {
		theCharacterController.OnChildTriggerExit2D (this, other);
	}
}
