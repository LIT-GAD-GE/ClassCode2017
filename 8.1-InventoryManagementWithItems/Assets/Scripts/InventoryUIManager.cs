using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour {
	public Image cheeseImage;
	public Image orangeImage;
	public Image appleImage;

	public Text cheeseText;
	public Text orangeText;
	public Text appleText;

	private int cheeseCount = 0;
	private int orangeCount = 0;
	private int appleCount = 0;

	// Use this for initialization
	void Start () {
		cheeseImage.enabled = false;
		orangeImage.enabled = false;
		appleImage.enabled = false;

		cheeseText.text = orangeText.text = appleText.text = "";
	}
	
	public void addApple(int num=1) {
		appleCount += num;

		if (appleCount > 0) {
			appleImage.enabled = true;
		}

		appleText.text = appleCount.ToString ();
	}

	public void removeApple(int num=1) {
		appleCount -= num;
		appleText.text = appleCount.ToString ();

		if (appleCount == 0) {
			appleImage.enabled = false;
		}
	}

	public void addCheese(int num=1) {
		cheeseCount += num;

		if (cheeseCount > 0) {
			cheeseImage.enabled = true;
		}

		cheeseText.text = cheeseCount.ToString ();
	}

	public void removeCheese(int num=1) {
		cheeseCount -= num;
		cheeseText.text = cheeseCount.ToString ();

		if (cheeseCount == 0) {
			cheeseImage.enabled = false;
		}
	}

	public void addOrange(int num=1) {
		orangeCount += num;

		if (orangeCount > 0) {
			orangeImage.enabled = true;
		}

		orangeText.text = orangeCount.ToString ();
	}

	public void removeOrange(int num=1) {
		orangeCount -= num;
		orangeText.text = orangeCount.ToString ();

		if (orangeCount == 0) {
			orangeImage.enabled = false;
		}
	}
}
