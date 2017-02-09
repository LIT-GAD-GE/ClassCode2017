using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public bool switchEnabled = false;
	public DoorController theDoor;
	public bool doorOpen = false;
	public bool doorMoving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSwitchTriggerEnter() {
		switchEnabled = true;
	}

	public void OnSwitchTriggerExit() {
		switchEnabled = false;
	}

	public void OnSpacebarPressed() {
		if ((switchEnabled == true) && (doorOpen == false)) {
			theDoor.open ();
		} else if ((switchEnabled == true) && (doorOpen == true)) {
			theDoor.close ();
		}
	}

	public void OnDoorFullyOpen (){
		doorOpen = true;
		StartCoroutine ("doorCloseTimer");
	}

	public void OnDoorFullyClosed() {
		doorOpen = false;

	}

	private IEnumerator doorCloseTimer() {
		yield return new WaitForSeconds (0.5f);
		theDoor.close ();

	}

}

