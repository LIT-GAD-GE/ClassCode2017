using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	public void pickupBomb(BombController theBomb){
		
		theBomb.gameObject.transform.parent = transform;

		theBomb.gameObject.transform.localPosition = new Vector3 (0.5f, -0.5f, 0);

		theBomb.OnPickedUp();
	}

	public void dropBomb(BombController theBomb) {

		theBomb.gameObject.transform.parent = null;

		theBomb.OnDropped ();
	}

	public void explode() {
		// I am just going to destroy the Hero gameobject. Really I should play some
		// explosion animations and sounds etc
		Destroy (gameObject);
	}
}
