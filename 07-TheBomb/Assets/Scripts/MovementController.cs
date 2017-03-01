using UnityEngine;
using System.Collections;

/*
 * This is a really simple MovementController. It works fine for horizontal movement
 * but needs work for jumps etc
 */
public class MovementController: MonoBehaviour {
	// A variable to hold the game objects rigidbofy component. We need this as it is on
	// this we set the velocity.
	private Rigidbody2D theRigidBody;

	// The maximum horizontal speed the object can go
	public float maxHorixontalSpeed;

	// The speedMultiplier will be set to a value between -1 and 1 and then multiplied
	// by maxHorizontalSpeed.
	private float speedMultiplier;

	// Use this for initialization
	void Start() 
	{
		theRigidBody = GetComponent<Rigidbody2D>();
	}

	// Please be aware of the difference between Update and FixedUpdate
	void Update()
	{
		// Get the value of the Horizontal axis (a value between -1 and 1)
		speedMultiplier = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate()
	{
		// Set the velocity of the object
		theRigidBody.velocity = new Vector2 (maxHorixontalSpeed * speedMultiplier, theRigidBody.velocity.y);
	}


}