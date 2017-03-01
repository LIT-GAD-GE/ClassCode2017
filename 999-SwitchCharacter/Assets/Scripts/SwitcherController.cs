using UnityEngine;
using System.Collections;

public class SwitcherController : MonoBehaviour {
	/*
	 * This is a reference to the MultiHeroController which must be set in the inspector
	 */
	public MultiHeroController theMultiHeroController;

	/*
	 * This is a reference to the currentlyActiveHero which must be initially set
	 * via the inspector. Thereafter it will be updated automatically when Heros
	 * get switched.
	 */
	public GameObject currentlyActiveHero;


	void OnTriggerEnter2D(Collider2D other) {
		/*
		 * I have to do it this way so as to ensure don't constantly switch from one
		 * to the other when you initiate an initial switch/
		 */

		if ((other.name == "HeroA") && (currentlyActiveHero.name == "HeroA")) {
			/* HeroA has just walked into the swwitcher trigger and it is HeroA that
			 * I have registered as the currently active hero so lets switch heros
			 * but DON'T register that our new active hero is HeroB, we'll do this
			 * when HeroB enters the trigger due to the fact that its been switched 
			 * in.
			 */
			theMultiHeroController.switchHeros ();
		} 
		else if ((other.name == "HeroA") && (currentlyActiveHero.name != "HeroA")) {
			/* HeroA has entered the trigger YET I don't have HeroA registered as
			 * the currently active hero. This is because I have just switched to
			 * HeroA and didn't set it as the currently active hero. I was waiting
			 * until now to do so.
			 */
			currentlyActiveHero = other.gameObject;
		}
		else if ((other.name == "HeroB")  && (currentlyActiveHero.name == "HeroB")){
			/* HeroB has just walked into the swwitcher trigger and it is HeroB that
			 * I have registered as the currently active hero so lets switch heros
			 * but DON'T register that our new active hero is HeroA, we'll do this
			 * when HeroA enters the trigger due to the fact that its been switched 
			 * in.
			 */
			theMultiHeroController.switchHeros ();
		} 
		else if ((other.name == "HeroB") && (currentlyActiveHero.name != "HeroB")) {
			/* HeroB has entered the trigger YET I don't have HeroA registered as
			 * the currently active hero. This is because I have just switched to
			 * HeroB and didn't set it as the currently active hero. I was waiting
			 * until now to do so.
			 */
			currentlyActiveHero = other.gameObject;
		}

	}

}
