using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public LevelManager thelevelManager;

	// Variable used to open and close the door.
	public float moveStep;
	public float openYPos;
	public float closedYPos;
	public float doorDelay;

	// Sound Effect. I have set this up via the inspector.
	public AudioSource movingSFX;


	void Awake() {
		// I am going to initialise the closedYPos to the current Y position
		// of the door as I am assuming the door is closed.
		closedYPos = transform.position.y;
	}

	// This is a public function that gets called by the LevelManager when it wants
	// to open the door
	public void open() {
		Debug.Log ("DoorController:open");

		// Start a coroutine to continuously move the door, Pass the 
		// coroutine, called moveDoor, the boolean value true which indicates to the
		// coroutine that the door should be moved up
		StartCoroutine ("moveDoor", true);

		// Play the moving sound effect
		movingSFX.Play ();
	}
		
	// This is public function that gets called by the LevelManager when it wants 
	// to close the door
	public void close() {
		Debug.Log ("DoorController:close");

		// Start a coroutine to continuously move the door, Pass the 
		// coroutine, called moveDoor, the boolean value false which indicates to the
		// coroutine that the door should be not be moved up i.e. should be moved down
		StartCoroutine ("moveDoor", false);

		// Play the moving sound effect
		movingSFX.Play ();
	}

	// Note that this is a private function. I have made it private so that other scripts, such
	// as the LevelManager, can't call the function. It's not the end of the world if I make it 
	// public but my intention is for it to be only used within this script and not by other scripts
	// so making it private enforces that.
	//
	// This function is called by the moveDoor cooroutine after it has fully opened the door.
	private void OnFullyOpen() {
		// Notify the level manager that the door is fully open. the level manager needs to know 
		// the door is open so that it can start a timer, after which it will close the door
		// again.
		thelevelManager.OnDoorFullyOpen ();

		// Stop the movinf sound from playing
		movingSFX.Stop ();
	}


	// This function is similar to OnFullyOpen above. Note it is also private for the same
	// reasoons as OnFullyOpen.
	private void OnFullyClosed() {
		thelevelManager.OnDoorFullyClosed ();
		movingSFX.Stop ();
	}

	// This is a cooroutine that moves the door. If the upDirection argument that is passed
	// to it is true then the door is moved up, otherwise it is moved down.
	private IEnumerator moveDoor(bool upDirection) {
		if (upDirection == true) {
			// Ok we need to open the door

			// Get the doors current y position
			Vector2 currentPos = transform.position;

			while (currentPos.y < openYPos) {
				currentPos.y += moveStep;
				transform.position = currentPos;
				yield return new WaitForSeconds (doorDelay);
			}

			// Ok, at this point the door should be fully opened. We have gone through the
			// while loop above opening the door bit by bit. Let's call the OnFullyOpen function.
			OnFullyOpen();

		} else {
			// ok we are closing the door

			// Get the doors current y position
			Vector2 currentPos = transform.position;

			while (currentPos.y > closedYPos) {
				currentPos.y -= moveStep;
				transform.position = currentPos;
				yield return new WaitForSeconds (doorDelay);
			}

			// At this point the door is fully closed. 
			OnFullyClosed();
		}
	}
}
