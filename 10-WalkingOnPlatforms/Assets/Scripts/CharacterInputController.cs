using System;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
	[SerializeField] LevelManager theLevelManager;
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
    }


    private void FixedUpdate()
    {
		float hMovement = Input.GetAxis("Horizontal");

        // Pass all parameters to the character control script.
		theLevelManager.MoveCharacter(hMovement, jump);

		// Reset the jump boolean
		jump = false;
    }
}

