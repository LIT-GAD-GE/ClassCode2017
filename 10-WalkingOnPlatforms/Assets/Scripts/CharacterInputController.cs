using System;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    private CharacterController m_Character;
	[SerializeField] LevelManager theLevelManager;
    private bool m_Jump;


    private void Awake()
    {
		m_Character = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
			m_Jump = Input.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftShift);
		float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
		theLevelManager.MoveCharacter(h, crouch, m_Jump);
        m_Jump = false;
    }
}

