using UnityEngine;
using System.Collections;

public class MultiHeroController : MonoBehaviour {

	/*
	 * References to the two child Heros. Make sure that only one of them
	 * is initially active. You do this via the inspector.
	 * 
	 * Notice for demonstration purposes I have set the x and y scale of HeroB
	 * to be 0.5 i.e. made it smaller than HeroA.
	 */
	public GameObject HeroA;
	public GameObject HeroB;


	public void switchHeros() {

		/*
		 * if HeroA is active switch to HeroB and vias versa
		 */
		if (HeroA.activeSelf) {
			HeroA.SetActive (false);
			HeroB.SetActive (true);
		} 
		else {
			HeroB.SetActive(false);
			HeroA.SetActive(true);
		}
	}
}
