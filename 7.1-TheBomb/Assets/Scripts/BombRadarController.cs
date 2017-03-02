using UnityEngine;
using System.Collections;

public class BombRadarController : MonoBehaviour {

	public LevelManager theLevelManager;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Hero") {
			theLevelManager.OnBombRadarTriggerEnter ();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Hero") {
			theLevelManager.OnBombRadarTriggerExit ();
		}
	}
}
