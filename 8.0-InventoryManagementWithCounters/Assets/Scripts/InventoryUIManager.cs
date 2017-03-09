using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This script is attached to the InventoryPanel. It is responsible for updating the inventory UI
 */
public class InventoryUIManager : MonoBehaviour {
	/* 
	 * Each inventory item has:
	 * 	- an image
	 *  - a piece ot text (containing a number that represents how many of this item has been collected)
	 *  - a number (count) that represents how many of this item has been collected
	 * 
	 * I have created a UI Panel for each item. The variables below point to the appropriate component
	 * within the appropriate UI Panel. These need to be set up via the inspector.
	 */
	public Image cheeseImage;
	public Image orangeImage;
	public Image appleImage;

	public Text cheeseText;
	public Text orangeText;
	public Text appleText;

	/* 
	 * The following variables keep track of the, count, number of collectables collected. I will later 
	 * convert these numbers to strings to display in the Text conpmonent. I'm going to initialise
	 * tham all to 0.
	 */
	private int cheeseCount = 0;
	private int orangeCount = 0;
	private int appleCount = 0;

	// Use this for initialization
	void Start () {
		// Disable all the images so tha twe don;t see anything
		cheeseImage.enabled = false;
		orangeImage.enabled = false;
		appleImage.enabled = false;

		// Set the text to blank
		cheeseText.text = orangeText.text = appleText.text = "";
	}

	/*
	 * All of the following add??? methods follow the same format. Increase the count of the collectible
	 * by one, if the count is equal to 1 enable the image so that we can see it, convert the count number to 
	 * text and assign it to the text component of the UI.
	 */
	public void addApple() {
		appleCount++;

		if (appleCount == 1) {
			appleImage.enabled = true;
		}

		appleText.text = appleCount.ToString ();
	}

	/*
	 * All of the remove??? functions also follow the same format. Decrement the count of the collectable,
	 * if the count is 0 hide the image, update the text component to match the count.
	 */
	public void removeApple() {
		appleCount--;
		appleText.text = appleCount.ToString ();

		if (appleCount == 0) {
			appleImage.enabled = false;
		}
	}

	public void addCheese() {
		cheeseCount++;

		if (cheeseCount == 1) {
			cheeseImage.enabled = true;
		}

		cheeseText.text = cheeseCount.ToString ();
	}

	public void removeCheese() {
		cheeseCount--;
		cheeseText.text = cheeseCount.ToString ();

		if (cheeseCount == 0) {
			cheeseImage.enabled = false;
		}
	}

	public void addOrange() {
		orangeCount++;

		if (orangeCount == 1) {
			orangeImage.enabled = true;
		}

		orangeText.text = orangeCount.ToString ();
	}

	public void removeOrange() {
		orangeCount--;
		orangeText.text = orangeCount.ToString ();

		if (orangeCount == 0) {
			orangeImage.enabled = false;
		}
	}
}
