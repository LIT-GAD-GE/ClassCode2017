using UnityEngine;
using System.Collections;
using UnityEditor.VersionControl;
using System.Collections.Generic;
using System.ComponentModel;

/* 
 * This LevelManager is pretty much the same as the LevelManager we used to pickup
 * a key.The Only real difference, with the exception of changing the names of some 
 * variables, is the BombTimer function.
 */
public class LevelManager : MonoBehaviour {
	/*
	 * Here I store a reference to the two gameobjects in the scene. This way of
	 * doing it will become a bit messy if I had, for example, 20 bombs. What I would
	 * do in such a scenario is rather than create a variable that can hold a
	 * BombController I would have a List that could hold many BombControllers.
	 */
	public HeroController theHero;
	public BombController theBomb;

	/*
	 * The following variables are used to represent the game state.
	 */

   /* This variable wil be set true when the Hero enters the bombs range. I have creates
	* an empty game object called BombRadar that is a child of the Bomb game object. It
	* has a Circle Collider 2D trigger component and a script called BombRadarController.
	* When the Hero enters and exits the BombRadar trigger it notifies the LevelManager
	* by calling the functions OnBombRadarTriggerEnter and OnBombRadarTriggerExit which
	* in turn set variable below, HeroInBombRange, to true or false.
	*/
	public bool HeroInBombRange = false;

	// This is set to true if the Hero has picked up the Bomb otherwise its false. 
	public bool bombPickedUp = false;

	/*
	 * This function gets called by the BombController when the Hero enters the Bomb trigger.
	 * This function causes the Hero to pichup the Bomb.
	 * 
	 */
	public void OnBombTriggerEnter() {
		Debug.Log ("OnBombTriggerEnter");

		if (bombPickedUp == false) {

			// Ok, someone (we assume the hero) has collided with the Bomb. Lets
			// tell the Hero to add the Bomb as a child. Notice that I am passing theBomb
			// as an argument to the pickupBomb function i.e. not only am I telling
			// theHero to pickup the Bomb (by calling the pickupBomb function) but I am
			// also giving theHero the Bomb which I want it to pickup. While this may not be 
			// so impressive now (as I only have one Bomb), if I add more Bombs this will
			// be handy
			theHero.pickupBomb (theBomb);

			// Set bombPickedUp to true to indicate that the Bomb is picked up.
			bombPickedUp = true;

			// Lets start a "Timer" after which the bomb will explode
			StartCoroutine("BombTimer");

		} else if (bombPickedUp == true) {
			/* I am here because the Hero has entered the Bombs trigger YET the variable
			 * bombPickedUp is true.
			 * 
			 * How can that be? If the Hero has picked up the Bomb then it can't enter its
			 * trigger because the Bomb would be a child of the Hero and parents don't enter
			 * the triggers of their children. YET, if I can only get to this point in the 
			 * code if the Hero enters the trigger of the Bomb (which causes this function
			 * to be called) and bombPickedUp is true.
			 * 
			 * This is not a mistake, I purposely coded it this way. When the Hero picks up
			 * the Bomb I set bombPickedUp to true BUT when the Hero drops the Bomb I don't
			 * set bombPickedUp to false. This is because the moment I drop the bomb in front
			 * of the Hero the Hero will enter the Bombs trigger because the Bomb is no
			 * longer a child of the Hero. This in turn will cause this function to be called
			 * and IF I had set bombPickedUp to false than the computer would execute the if 
			 * branch above and the Hero would pick up the bomb again. Essentially the Hero
			 * wouldn't be able to drop the Bomb because every time it did it would pick it up
			 * again.
			 * 
			 * So instead of setting bombPickedUp to false, when the Hero drops the Bomb, I 
			 * leave it at false KNOWING that the Hero is going to enter the Bombs trigger
			 * as soon as the Bomb is dropped. Now, however, the computer won't execute the
			 * above if branch (which would cause the Hero to pick the Bomb up again) but 
			 * instead will execute this if branch and it is now I set bombPickedUp to false.
			 */
			bombPickedUp = false;
		}

	}

	/* 
	 * This function gets called by the BombRadarController.
	 */
	public void OnBombRadarTriggerEnter() {
		Debug.Log ("OnBombRadarTriggerEnter");
		HeroInBombRange = true;
	}

	/* 
	 * This function gets called by the BombRadarController.
	 */
	public void OnBombRadarTriggerExit() {
		HeroInBombRange = false;
	}

	/*
	 * This function gets called by the Input manager.
	 */
	public void OnXKeyPressed() {

		// Only tell the Hero to drop the Bomb if we have already picked
		// up the Bomb.
		if (bombPickedUp == true) {
			theHero.dropBomb (theBomb);
		}
	}

	/*
	 * This is a corouting that gets started when the Bomb is picked up. It waits for
	 * 3 seconds then tells the Bomb to explode. If the bomb is picked up (i.e. the
	 * Hero is holding the Bomb) OR the Hero is within the Bombs range, we tell the
	 * Hero to explode.
	 */
	private IEnumerator BombTimer() {
		yield return new WaitForSeconds (3);

		// Ok, time to blow up the Bomb
		theBomb.explode();

		if ((bombPickedUp == true) || (HeroInBombRange == true)){
			theHero.explode ();
		}
	}
}
