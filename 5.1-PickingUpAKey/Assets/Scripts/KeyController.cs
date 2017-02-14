using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {
	public LevelManager theLevelManager;

	/* 
	 * The key GameObject has two audio files associated with it, one called pickup
	 * and the other called drop. The variables below are used to store these two
	 * AudioSource components.
	 * 
	 * Read the API: https://docs.unity3d.com/ScriptReference/AudioSource.html
	 */
	private AudioSource pickupSFX;
	private AudioSource dropSFX;

	void Awake() {
		// Get the array of all AudioSource components attached to thisGameObject.
		AudioSource[] allAudio = GetComponents<AudioSource> ();

		// Loop through the allAudio array, starting at index (position) 0, continue
		// while the index is less than the length of the array, and after every
		// interation of the loop increase the index by 1
		for (int i= 0; i < allAudio.Length; i++) {
			// Declare a variable that can hold an AudioSource
			AudioSource sourceAtcurrentArrayIndex;

			// Declare a variable that can hold an AudioClip
			AudioClip clipAtCurrentArrayIndex;

			// Get the AudioSource component at the current index i
			sourceAtcurrentArrayIndex = allAudio [i];

			// Get the AudioClip attached to the AudioSource
			clipAtCurrentArrayIndex = sourceAtcurrentArrayIndex.clip;

			// If the name of this audioClip is pickup then set the pickupSFX variable
			// otherwise, if the name is equal to drop then set the dropSFX variable

			if (clipAtCurrentArrayIndex.name == "pickup") {
				// Set pickupSFX to be equal to sourceAtcurrentArrayIndex
				pickupSFX = sourceAtcurrentArrayIndex;
			}else if (allAudio [i].clip.name == "drop") {
				// Set dropSFX to be equal to sourceAtcurrentArrayIndex
				dropSFX = sourceAtcurrentArrayIndex;
			}
		}


		/*
		 	Note: I would usually write all the above code as follows (i.e. I wouldn't
		 	have declared sourceAtcurrentArrayIndex and clipAtCurrentArrayIndex variables):

			for (int i = 0; i < allAudio.Length; i++) {
				if (allAduio[i].clip.name == "pickup") {
					pickupSFX = allAudio[i];
				} else if (allAudio[i].clip.name == "drop") {
					dropSFX = allAudio[i];
				}
			}
		*/
	}

	void OnTriggerEnter2D(Collider2D other) {
		theLevelManager.OnKeyTriggerEnter ();
	}

	public void pickup() {
			pickupSFX.Play ();
	}


	public void drop() {
			dropSFX.Play ();
	}

}
