using UnityEngine;
using System.Collections;

/*
 * It is worth noting that the Door game object that this DoorControler script component is attached has 
 * two Box Collider 2D components attached to it, one of which is a trigger. As such Unity will call the
 * following functions (these particular type of functions are known as messages, you can see a list of them
 * here on https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) if they are declared in the
 * script:
 * 		- OnCollisionEnter2D
 * 		- OnCollisionExit2D
 * 		- OnCollisionStay2D
 * 		- OnTriggerEnter2D
 * 		- OnTriggerExit2D
 * 		- OnTriggerStay2D
 * 
 * I am only interested in the onTriggerEnter2D and OnTriggerExit2D function so they are the only two I
 * declare below.
 * 
 *
 * So how do you open a door. Well there are a few ways we could do this, the way I have
 * chosen is to move the door up in the Y direction so many units until it reaches a certain
 * point. 
 * 
 * I am going to create a variable called moveStep which will contain the number of units
 * I want to move the door up by.The idea is I will continually move the door up by moveStep
 * units until it reaches a certain point which I consider open.
 * 
 * I am also going to create a variable called openYPos which is the Y position the door needs
 * to be at to be considered open.
 * 
 * I am going to create a variable called closedYPos which is the Y position the door needs to
 * be at to be considerd closed. I am going to initialise this to the starting Y position of the
 * door as I assume the door starts closed.
 * 
 * Finally I am going to create a variable called doorDelay which will dictate the speed at which the
 * door opens and closes.
 * 
 * As I need the door to open/close at the same time as the game is being played i.e. I don't want
 * the game to stop (e.g. not being able to move the Hero) while I am opening/closing the door, I am
 * going to write a coroutine to open/close the door.
 */
public class DoorController : MonoBehaviour {
	// A variable that stores a reference to a LevelManager. This needs to be "setup" in the
	// inspector
	public LevelManager theLevelManager;

	// Variable used to open and close the door.
	public float moveStep;
	public float openYPos;
	public float closedYPos;
	public float doorDelay;


	void Awake() {
		// I am going to initialise the closedYPos to the current Y position
		// of the door as I am assuming the door is closed.
		closedYPos = transform.position.y;

	}


	void OnTriggerEnter2D(Collider2D other) {
		// Let's notify the level manager
		theLevelManager.OnDoorTriggerEnter();
	}

	void OnTriggerExit2D(Collider2D other) {
		// Let's notify the level manager
		theLevelManager.OnDoorTriggerExit();
	}

	/*
	 * This function is called by the Level Manager to open the door.
	 * 
	 */
	 
	public void open() {
		StartCoroutine ("moveDoor", true);
	}

	public void close() {
		StartCoroutine ("moveDoor", false);
	}

	private IEnumerator moveDoor(bool openDirection) {
		if (openDirection == true) {
			// Ok we need to open the door

			// Get the doors current y position
			Vector2 currentPos = transform.position;

			while (currentPos.y < openYPos) {
				currentPos.y += moveStep;
				transform.position = currentPos;
				yield return new WaitForSeconds (doorDelay);
			}
		} else {
			// ok we are closing the door

			// Get the doors current y position
			Vector2 currentPos = transform.position;

			while (currentPos.y > closedYPos) {
				currentPos.y -= moveStep;
				transform.position = currentPos;
				yield return new WaitForSeconds (doorDelay);
			}
		}
	}
}
