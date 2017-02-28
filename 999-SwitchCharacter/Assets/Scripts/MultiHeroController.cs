using UnityEngine;
using System.Collections;

public class MultiHeroController : MonoBehaviour {
	public GameObject HeroA;
	public GameObject HeroB;



	// Use this for initialization
	void Awake () {
		HeroB.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void switchHeros(string heroName) {

		if (heroName == HeroB.name) {
			HeroA.SetActive(false);
			HeroB.SetActive(true);
		}
	
		if (heroName == HeroA.name) {
			HeroB.SetActive(false);
			HeroA.SetActive(true);
		}

	}
}
