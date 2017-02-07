using UnityEngine;
using System.Collections;

public class VaseController : MonoBehaviour {
	private Rigidbody2D theRB;
	private Vector2 theForce;

	// Use this for initialization
	void Awake () {
		theRB = gameObject.GetComponent<Rigidbody2D> ();
		theForce = new Vector2 (5, 0);
	}

	public void fall() {

		theRB.AddForce (theForce, ForceMode2D.Impulse);

	}
}
