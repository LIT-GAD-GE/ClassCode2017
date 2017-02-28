using UnityEngine;
using System.Collections;

public class SwitcherController : MonoBehaviour {
	public MultiHeroController theMultiHeroController;

	public GameObject currentlyActiveHero;


	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "HeroA") {
			Debug.Log ("Entered Switcher - switching to B");
			theMultiHeroController.switchHeros ("HeroB");
		}
		else if (other.name == "HeroB")
		{
				Debug.Log ("Entered Switcher - switching to a");
				theMultiHeroController.switchHeros ("HeroA");
		}
	}

}
