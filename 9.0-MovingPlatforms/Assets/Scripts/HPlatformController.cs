﻿using UnityEngine;
using System.Collections;

/*
 * The approach here is pretty straight forward. We are going to store how fast (the speed)
 * we want the platform to move in a variable called HorizontalSpeed. We are going to store how 
 * far we want it to move (either left or right) from its starting position in a variable 
 * called HorizontalOffset.
 * 
 * In the Awake function (which is called once per script when the game is started) I am going 
 * to get a reference to the platform's RigidBody2D component (so that I can later set its
 * velocity) and I am going to initialise a Vector2 variable to be what the current position of
 * the platform is.
 * 
 * Also in the Awake function I create two Vector2 objects, one to represent the velocity of
 * the platform when moving right and one to represent the velocity of the platform when 
 * moving left. These two vectors are based on the value entered for HorizontalSpeed via the
 * inspector.
 * 
 * Finally in the Awake function I set the velovity of the platform to be equal to the rightVelocity
 * thereby setting the platform moving right.
 * 
 * Everytime the Update function is called I check if:
 * 		1. The current position of the platform is GREATER or equal to the platforms starting X 
 * 			position PLUS the HorizontalOffset. If so I set the velocity of the platform so that
 * 			it moves left.
 * 		2. 	The current position of the platform is LESS than or equal to the platforms starting X
 * 			position MINUS the HorizontalOffset. If so I set the velocity of the platform so that
 * 			it moves right.
 */



public class HPlatformController : MonoBehaviour {
	public float HorizontalSpeed;
	public float HorizontalOffset;

	private Rigidbody2D theRigidBody;
	private Vector2 startingPosition;
	private Vector2 rightVelocity;
	private Vector2 leftVelocity;

	// Use this for initialization
	void Awake () {
		theRigidBody = GetComponent<Rigidbody2D> ();
		startingPosition = theRigidBody.position;


		rightVelocity = new Vector2 (HorizontalSpeed, 0);
		leftVelocity = new Vector2 (-HorizontalSpeed, 0);

		// Set the platform moving right
		theRigidBody.velocity = rightVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (theRigidBody.position.x >= startingPosition.x + HorizontalOffset) {
			// ok we have gone all the way to the right, we need to start
			// heading left
			theRigidBody.velocity = leftVelocity;
		} else if (theRigidBody.position.x <= startingPosition.x - HorizontalOffset) {
			// ok we have gone all the way to the left, we need to start
			// heading right
			theRigidBody.velocity = rightVelocity;
		}
	}
		
}


