using UnityEngine;
using System.Collections;

public class ChildTriggerController : MonoBehaviour {
	public SimpleControler theHeroController;

	void OnTriggerEnter2D(Collider2D other) {
		theHeroController.OnChildTriggerEnter2D (this, other);
	}

	void OnTriggerExit2D(Collider2D other) {
		theHeroController.OnChildTriggerExit2D (this, other);
	}
}
