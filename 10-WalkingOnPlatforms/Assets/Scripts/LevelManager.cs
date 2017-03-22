using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	[SerializeField] CharacterController theHero;

	public void MoveCharacter(float hAxisValue, bool doCrouch, bool doJump) {
		theHero.Move (hAxisValue, doCrouch, doJump);
	}
}
