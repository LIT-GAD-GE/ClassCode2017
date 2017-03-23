using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public SimpleControler theHero;

	public void MoveCharacter(float hAxisValue, bool doJump) {

		theHero.Move (hAxisValue, doJump);
	}
}
