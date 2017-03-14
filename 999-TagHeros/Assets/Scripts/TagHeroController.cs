using UnityEngine;
using System.Collections;

public class TagHeroController : MonoBehaviour {
	private SpriteRenderer mySpriteRenderer;
	private MovementController myMovementController;
	private Rigidbody2D myRigidBody;

	void Awake() {
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
		myMovementController = GetComponent<MovementController> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Hero") {

			if (mySpriteRenderer.enabled != true) {
				// Ok I'm the Hero that isn't visible
				mySpriteRenderer.enabled = true;
				myMovementController.enabled = true;
				myRigidBody.isKinematic = false;
			} else {
				// Ok I'm the Hero that is visible
				mySpriteRenderer.enabled = false;
				myMovementController.enabled = false;
				myRigidBody.velocity = new Vector2 (0, 0);
				myRigidBody.isKinematic = true;
			}

		}
	}
		
}
