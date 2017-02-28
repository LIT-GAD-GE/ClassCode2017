using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This LevelManager demonstrates how to:
 * 	- track whether a number of switches are on or off
 *  - track the order in which the switches were turned on
 * 
 * For demonstration pruposes, if you turn on switch1 then switch3 then switch2 and then
 * press the spacebar a sound will be played. The sound will only be played if the switches
 * are all on and turned in the sequence listed above.
 * 
 * The way I am going to do this is to store the name of all the switches that are turned on (enabled)
 * in a List. As a switch it turned on I will add it to the List. If the list contains three 
 * names than all three switches must be on and if the order of the names in the List is 
 * Switch1, Switch3 and Switch3 then they have been turned on in the correct sequence.
 * 
 * When the Hero enters the trigger box of a switch I am going to register the fact that this
 * switch is active by storing the switch is a variable called currentActiveSwitch. 
 * 
 * If the user presses the Up Arrow (works similar for Down Arrow) I check to see if currentActiveSwitch
 * is not null i.e. it is storing a reference to some switch i.e. the Hero is currently the trigger of
 * some switch. If the currentActiveSwitch is not null the I "enable" the switch by adding its
 * name to the list of enabled switches (I also shrink the switch just so that we can visually see
 * it is enabled).
 * 
 */
public class LevelManager : MonoBehaviour {

	/*
	 * I have some options available as to how exactly I store the names of the switches in a List.
	 * The most obvious solution is to use an Array. Another option is to use an ArrayList and yet
	 * another option is to use a List. ArrayList and List are very similar and have some useful
	 * functions attached to them that make them a bit easier to use than Arrays. Really the only
	 * difference between ArrayList and List is when using a List you have to state what type the
	 * items are that you are going to put in the List e.g. string, int, float, SwitchController, etc.
	 * 
	 * For this project I am going to use a List. If you are going to use a List you must add
	 * 
	 * 		using System.Collections.Generic;
	 * 
	 * to the stop of your script (just like I have above).
	 * 
	 * As I am going to be storing strings it the list i.e. the names of switches I create my new
	 * List using:
	 * 		
	 * 		new List<string>()
	 * 
	 * BTW, the following variable doesn't have to be public (it really should be private) but I have
	 * made it public just so we can see it change in the inspector.
	 */
	public List<string> enabledSwitches = new List<string>();

	/*
	 * The following variable will contain a reference to the SwitchController whose trigger we the
	 * Hero is currently in.
	 */
	public SwitchController currentActiveSwitch;

	// The following two variables hold AudioSource components that contain audio clips. I set this
	// variables up in the inspector.
	public AudioSource victorySFX;
	public AudioSource failSFX;


	/*
	 * This function is called by one of the SwitchController objects attached to one of the Switch
	 * game objects. At the time of writing this function I don't know which SwitchController object
	 * is going to call this function (if any) but whichever one does passes the function a reference
	 * to itself. This reference is the first parameter of the function and I call it 'aSwitchController".
	 * The second parameter, called other, will contain a reference to a Collider2D object which is an
	 * object that contains information about the other object involved in the "collision" with the
	 * switches tribber collider.
	 */
	public void OnSwitchTriggerEnter(SwitchController aSwitchController, Collider2D other) {
		/*
		 * ok, some game object has just entered the "trigger box" of one of the switches. The first
		 * think I am going to do is check to see if the other game object that entered the trigger
		 * box was the Hero (if it wasn't I am going to do nothing).
		 */
		if (other.name == "Hero") {

			/* 
			 * aSwitchController contains a reference to the SwitchController object that is attached
			 * to the Switch game object that has just been triggered. Lets store this in the variable
			 * currentActiveSwitch.
			 * 
			 * The reason I need to store it in currentActiveSwitch is because currentActiveSwitch is
			 * know as a class variable i.e. it is a variable that is declared inside in a class (in
			 * this case the class is SwitchController) but outside all of the functions in the class.
			 * Such variables are like "global" variables for all the functions in the class i.e. all
			 * the functions in the class can access it. This is different to a variable that is 
			 * either passed into a function (like the variable aSwitchController that is passed into 
			 * this function) or a variable that is created within a function. Such variables are
			 * local to the function, that is, they can only be accessed by code within the function
			 * and not by any other functions. I need the OnUpArrow and OnDownArrow functions below
			 * to be able to access the SwitchController object that the Hero is currently standing
			 * in front of (i.e. triggered) and as such I need to store this object in a class variable.
			 */
			currentActiveSwitch = aSwitchController;

		}
	}

	public void OnSwitchTriggerExit(SwitchController aSwitchController, Collider2D other) {

		if (other.name == "Hero") {
			// the Hero has left the trigger of a switch, let's set currentActiveSwitch to
			// null.
			currentActiveSwitch = null;
		}

	}


	// Gets called by the Input Manager
	public void OnUpArrow() {

		// Check to make sure the currentActiveSwitch is not null i.e. is equal to some object i.e. the
		// Hero is in the trigger of some switch
		if (currentActiveSwitch != null) {

			/*
			 * I am going to use a switch statement here. For a refresher on switch statements 
			 * see https://unity3d.com/learn/tutorials/topics/scripting/switch-statements
			 * 
			 * I could have used an if statement, which I do in the OnDownArrow function just to
			 * show you what that would look like.
			 * 
			 * What I am doing here is testing to see what the name of the currentActiveSwitch is.
			 */
			switch (currentActiveSwitch.name) {
			case "Switch1":
				/* ok, the name of the currentActiveSwitch is Switch1. If Switch1 is not already
				 * turned on, and I can check this by checking if it is in the list of enabled
				 * switches or not, then turn it on/
				 */
				if (enabledSwitches.Contains ("Switch1") == false) {
					// The switch hasn't been enabled. Lets add its name to the list of enabled switches.
					enabledSwitches.Add ("Switch1");

					/* I have written a function on the SwitchController script called scale which 
					 * scales the game object the script is attached to by the specified amount. I
					 * am now going to call this function on the active switch and pass it 0.5 which
					 * will have the effect of shrinking it by half.
					 * I do this just so we can see that the switch has been enabled. Another way of
					 * doing this would be to play an animation.
					 */
					currentActiveSwitch.scale (0.5f);
				}
				break;
			case "Switch2":
				if (enabledSwitches.Contains ("Switch2") == false) {
					enabledSwitches.Add ("Switch2");
					currentActiveSwitch.scale (0.5f);
				}
				break;
			case "Switch3":
				if (enabledSwitches.Contains ("Switch3") == false) {
					enabledSwitches.Add ("Switch3");
					currentActiveSwitch.scale (0.5f);
				}
				break;
			default:
				// This is a Switch whose name I don't know. I'm going to do nothing.
				break;
			}
		}
	}

	public void OnDownArrow() {
		if (currentActiveSwitch != null) {
			// I am using an if statement in stead of a switch just for demonstration
			// purposes. Either works.
			if (currentActiveSwitch.name == "Switch1") {
				if (enabledSwitches.Contains ("Switch1") == true) {
					// ok lets disable the switch
					enabledSwitches.Remove ("Switch1");
					currentActiveSwitch.scale (2.0f);
				}
			} else if (currentActiveSwitch.name == "Switch2") {
				if (enabledSwitches.Contains ("Switch2") == true) {
					enabledSwitches.Remove ("Switch2");
					currentActiveSwitch.scale (2.0f);
				}
			} else if (currentActiveSwitch.name == "Switch3") {
				if (enabledSwitches.Contains ("Switch3") == true) {
					enabledSwitches.Remove ("Switch3");
					currentActiveSwitch.scale (2.0f);
				}
			}


		}
	}

	public void OnSpacebarDown() {
		if (enabledSwitches.Count == 3) {
			// Ok I have three switches in the list. Now to see if they are in order.
			// The order needs to be switch1 then switch3 then switch2
			if ((enabledSwitches [0] == "Switch1") && (enabledSwitches [1] == "Switch3") && (enabledSwitches [2] == "Switch2")) {
				victorySFX.Play ();
			} else {
				failSFX.Play ();
			}
		}
	}

}
