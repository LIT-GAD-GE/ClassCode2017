using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	public void pickupCollectable(CollectableController theCollectable){
		
		theCollectable.gameObject.transform.parent = transform;

		theCollectable.gameObject.transform.localPosition = new Vector3 (0.5f, -0.5f, 0);

		theCollectable.OnPickedUp();
	}

	public void dropCollectable(CollectableController theCollectable) {

		theCollectable.gameObject.transform.parent = null;

		theCollectable.OnDropped ();
	}
}
