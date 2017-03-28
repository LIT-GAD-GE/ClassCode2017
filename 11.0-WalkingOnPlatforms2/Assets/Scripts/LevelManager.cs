using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public SimpleControler theHero;

	/*
	 * Because these private variables have the [SerializeField] attribute in front of them
	 * it means that while they are still private (i.e. can't be accessed via another script)
	 * they can be accessed via the inspector (handy during development).
	 */
	[SerializeField] private bool haveJumpPowers;
	[SerializeField] private bool haveDuckPowers;
	[SerializeField] private float powerUpTime;
	[SerializeField] private int numStars;
	[SerializeField] private bool pause;

	void Awake() {
		pause = false;
	}

	public void MoveCharacter(float hAxisValue, float vAxisValue, bool doJump, bool doDuck) {

		if (!haveJumpPowers) {
			doJump = false;
		}

		if (!haveDuckPowers) {
			doDuck = false;
		}

		theHero.Move (hAxisValue, vAxisValue, doJump, doDuck);
	}

	public void starCollected() {

		// Increment the number of stars I have
		numStars++;

		// If the player has three or more stars then give them jump powers
		if (numStars >= 3) {
			haveJumpPowers = true;
		}

		// If the player has six or more starts then give the, duck powers
		if (numStars >= 6) {
			haveDuckPowers = true;
		}

	}

	public void OnPowerUp() {
		
		// You can only powerUp if you have 9 or more stars
		if (numStars >= 9) {
			// Call the setCanMoveInAir function on theHero SimpleController and pass it the
			// value true
			theHero.setCanMoveInAir (true);

			// Start a coroutine
			StartCoroutine ("powerUpTimer");
		}
	}

	public void OnPowerCancel() {
		StopCoroutine ("powerUpTime");
		powerDown ();
	}

	private void powerDown() {
		theHero.setCanMoveInAir (false);
	}

	private IEnumerator powerUpTimer() {
		yield return new WaitForSeconds (powerUpTime);
		powerDown ();
	}

	public void resetLevel() {
		haveJumpPowers = haveDuckPowers = false;
		numStars = 0;
		theHero.setCanMoveInAir (false);
	}

	public void pauseGame() {

		pause = !pause;

		if (pause) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}
		
}
