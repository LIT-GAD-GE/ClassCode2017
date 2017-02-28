using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// A reference the the LevelManager which needs to be set via the inspector
	public LevelManager theLevelManager;

	// Update is called once per frame
	void Update () {

		/* Notice in the if statement below I don't write it as
		 * 
		 * 	if (Input.GetKeyDown(KeyCode.Soace) == true)
		 * 
		 * I ommit the " == true " part. This is fine as all expressions by
		 * default will be evaluated against true (unless you specifically say 
		 * otherwise).
		 */
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			theLevelManager.OnUpArrow ();
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			theLevelManager.OnDownArrow ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			theLevelManager.OnSpacebarDown ();
		}
	}
}
