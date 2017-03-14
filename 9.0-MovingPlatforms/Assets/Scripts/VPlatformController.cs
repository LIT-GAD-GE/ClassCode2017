using UnityEngine;
using System.Collections;

/*
 * The approach here is pretty straight forward. We are going to store how fast (the speed)
 * we want the platform to move in a variable called VerticalSpeed. We are going to store how 
 * far we want it to move (either up or down) from its starting position in a variable 
 * called VerticalOffset.
 * 
 * In the Awake function (which is called once per script when the game is started) I am going 
 * to get a reference to the platform's RigidBody2D component (so that I can later set its
 * velocity) and I am going to initialise a Vector2 variable to be what the current position of
 * the platform is.
 * 
 * Also in the Awake function I create two Vector2 objects, one to represent the velocity of
 * the platform when moving up and one to represent the velocity of the platform when 
 * moving down. These two vectors are based on the value entered for VerticalSpeed via the
 * inspector.
 * 
 * Finally in the Awake function I set the velovity of the platform to be equal to the upVelocity
 * thereby setting the platform moving up.
 * 
 * Everytime the Update function is called I check if:
 * 		1. The current position of the platform is GREATER or equal to the platforms starting Y 
 * 			position PLUS the VerticalOffset. If so I set the velocity of the platform so that
 * 			it moves down.
 * 		2. 	The current position of the platform is LESS than or equal to the platforms starting Y
 * 			position MINUS the VerticalOffset. If so I set the velocity of the platform so that
 * 			it moves up.
 */



public class VPlatformController : MonoBehaviour {
	public float VerticalSpeed;
	public float VerticalOffset;

	private Rigidbody2D theRigidBody;
	private Vector2 startingPosition;
	private Vector2 upVelocity;
	private Vector2 downVelocity;

	// Use this for initialization
	void Awake () {
		theRigidBody = GetComponent<Rigidbody2D> ();
		startingPosition = theRigidBody.position;


		upVelocity = new Vector2 (0, VerticalSpeed);
		downVelocity = new Vector2 (0, -VerticalSpeed);

		// Set the platform moving up
		theRigidBody.velocity = upVelocity;
	}

	// Update is called once per frame
	void Update () {
		if (theRigidBody.position.y >= startingPosition.y + VerticalOffset) {
			// ok we have gone all the way to the top, we need to start
			// heading down
			theRigidBody.velocity = downVelocity;
		} else if (theRigidBody.position.y <= startingPosition.y - VerticalOffset) {
			// ok we have gone all the way to the bottom, we need to start
			// heading up
			theRigidBody.velocity = upVelocity;
		}
	}

}


