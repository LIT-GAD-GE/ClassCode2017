using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	public void pickupKey(KeyController theChildKey){
		theChildKey.gameObject.transform.parent = transform;
		theChildKey.gameObject.transform.localPosition = new Vector3 (0.5f, -0.5f, 0);
		theChildKey.pickup ();
	}

	public void dropKey(KeyController theChildKey) {
		Debug.Log ("HeorController::dropChild");

		theChildKey.gameObject.transform.parent = null;
		theChildKey.drop ();
	}
}
