using UnityEngine;
using System.Collections;

/*
 * The approach here is pretty straight forward. We are going to store how fast (the speed)
 * we want the platform to move in a variable called HorizontalSpeed. We are going to store how 
 * far we want it to move (either left or right) from its starting position in a variable 
 * called HorizontalOffset.
 * 
 * In the Awake function (which is called once per script when the game is started) I am going to 
 * initialise a Vector2 variable to be what the current position of the platform is, another Vector2
 * variable to store furthest right position of the platfrom and another Vectors2 variable to
 * store the furthest left position.
 *
 * 
 * Everytime the Update function is called I check if:
 * 		1. 	The current position is equal to either the righ position or the left position and if so
 * 			I toggle (reverse) the value of goingRight.
 * 		2.	I then use the Vector2 MoveTowards function to move either left or right
 * 
 * Note about Unity units: 
 * -----------------------
 * 2D physics uses MKS i.e. Meters (Distance), Kilograms (Mass) & Seconds (Time) for absolute values.  
 * 
 * A Colldier2D size is in Meters (m), its area in Meters-Squared (m2). A Rigidbody2D mass is in Kilograms (Kg),
 * its linear-velocity is Meters/Second (m/s), its angular-velocity is in Degrees/Sec (deg/s), Linear forces are 
 * in Newton-Metres (N-m) and Angular impulses are in Kilogram-Meter-Square/Second (Kg*m2/s), Rotational Inertia 
 * is (Kg*m2) and the physics-system updates n-times/sec.
 * 
 * 
 * So ......
 * 
 * If I set the HorizontalSpeed below to be 5 what I am actually setting it to 5 meters/second.Lets assume that
 * the game is running at 10 frames per second, so update will get called every .1 of a second.
 * 
 * The Vector2.MoveTowards function takes three arguments:
 * 		1.	It the starting position
 * 		2.	Is the target position
 * 		3. 	Is the maximum distance (in meters) that you are allowed to move towards the target position
 * 
 * It you were the last parameter, maxDistance, to 5 then the object would instantle move 5 meters towards the
 * target position. If you so this on every update and update is being called 10 times per second, then you 
 * would have moved 50 meters in a second (i.e. your spped would be 50 m/s).
 * 
 * If your were to set the last parameter to 5 * 0.1 (becaause the game is running at 10 frames per second and update
 * is called every frame, so will be called 1/10 = 0.1) then the object will move 0.5 meters ever frame and after
 * 10 frames (i.e. 1 second) the object would have moved 5 meters (i.e. your spped would be 5m/s).
 * 
 * To get how many times per second update is called use Time.deltaTime.
 */



public class HPlatformController : MonoBehaviour {
	public float HorizontalSpeed;
	public float HorizontalOffset;

	private Vector2 startingPosition;
	private Vector2 rightPosition;
	private Vector2 leftPosition;

	private bool goingRight = true;

	// Use this for initialization
	void Awake () {
		startingPosition = transform.position;
		rightPosition = new Vector2 (startingPosition.x + HorizontalOffset, startingPosition.y); 
		leftPosition = new Vector2 (startingPosition.x - HorizontalOffset, startingPosition.y);
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);


		if ((currentPosition == rightPosition) || (currentPosition == leftPosition)) {
			goingRight = !goingRight;
		}

		if (goingRight) {
			transform.position = Vector2.MoveTowards (currentPosition, rightPosition,  HorizontalSpeed * Time.deltaTime); 
		} else {
			transform.position = Vector2.MoveTowards (currentPosition, leftPosition, HorizontalSpeed * Time.deltaTime);
		}
	}
		
}


