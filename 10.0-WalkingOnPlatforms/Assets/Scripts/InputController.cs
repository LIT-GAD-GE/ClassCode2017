using System;
using UnityEngine;

/* 
 * The InputController is a script that can be attached to any gameobject in the scene (I usually attach
 * it to the LevelManager). It is responsible for detecting all button presses/controller interactions and
 * notifying the LevelManager.
 * 
 */
public class InputController : MonoBehaviour
{
	public LevelManager theLevelManager;

	/* 
	 * The jump variable has to be declared here as it is set in one function, the Update function, and
	 * used in another function, the FixedUpdate function.
	 */
    private bool jump;


    private void Update()
    {
		/*
		 * I am checking if the Jump button is pressed in the Update function rather
		 * than the FixedUpdate function as the Update function is called more frequently
		 * and as such the Jump presses won't be missed.
		 */
		if (!jump)
        {
			jump = Input.GetButtonDown("Jump");
        }

		// The following keys SIMULATE different things happening. 
		if (Input.GetKeyDown (KeyCode.S)) {
			theLevelManager.starCollected ();
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			theLevelManager.OnPowerUp ();
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			theLevelManager.OnPowerCancel ();
		}

		// Key to pause the game
		if (Input.GetKeyDown (KeyCode.Return)) {
			theLevelManager.pauseGame ();
		}

		// Key to reset the level
		if (Input.GetKeyDown (KeyCode.Escape)) {
			theLevelManager.resetLevel ();
		}


    }

	/*
	 * The reason I get some Inputs in the FixedUpdate function is because I need to call the MoveCharacter
	 * function on the LevelManager from within the FixedUpdate function and I need these Inputs so that I 
	 * can pass them to the MoveCharacter function. the reason I need to call the MoveCharacter function from
	 * within the FixedUpdate function is because it this function, in turn, calls the Move function on the
	 * SimpleController attached to the Hero which in turn uses physics (velocity and force) to move the 
	 * character. All functions that use functions should be called from within a FixedUpdate function.
	 * 
	 */
    private void FixedUpdate()
    {
		// Read the input from the Horizontal axis
		float hMovement = Input.GetAxis("Horizontal");

		// Read the input from the Fire3 key which I am mapping to Duck
		bool duck = Input.GetButton("Fire3");

        // Pass all parameters to the character control script.
		theLevelManager.MoveCharacter(hMovement, jump, duck);

		// Reset the jump boolean
		jump = false;
    }
}

