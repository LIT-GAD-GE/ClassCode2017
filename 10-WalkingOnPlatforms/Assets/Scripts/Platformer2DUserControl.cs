using System;
using UnityEngine;

/*
 * Read more about RequiredComponent at:
 * https://docs.unity3d.com/ScriptReference/RequireComponent.html
 * 
 * RequiredComponent is what is known as an Attribute. Watch a tutorial on
 * Attributes here https://unity3d.com/learn/tutorials/topics/scripting/attributes
 * 
 * When you add a script which uses RequireComponent to a GameObject, the required component 
 * will automatically be added to the GameObject. This is useful to avoid setup errors. For 
 * example a script might require that a Rigidbody is always added to the same GameObject. 
 * Using RequireComponent this will be done automatically, thus you can never get the setup wrong.
 *
 * The RequiredComponent attribute will ensure that when this script is added to a GameObject so
 * to will PlatformerCharacter2D script if it is not already a component of the GameObject.
 * 
 */
[RequireComponent(typeof (CharacterController))]
public class Platformer2DUserControl : MonoBehaviour
{
    private CharacterController m_Character;
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
        bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}

