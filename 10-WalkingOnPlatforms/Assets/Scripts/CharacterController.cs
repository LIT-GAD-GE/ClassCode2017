using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	/* 
	 * Using the Attribute SerializeField before a private class variable declaration allows the variable
	 * to be accessed via the inspector WITHOUT having to make it public.
	 */
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
	[SerializeField] [Range(0, 1)] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	[SerializeField] private bool platformOverhead = false;	// True of the child CeilingCheckCollider's trigger enters a platform

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
			if (colliders [i].gameObject != gameObject) {
				
				m_Grounded = true;

				gameObject.transform.parent = colliders [i].gameObject.transform;

			}
			
        }

		if (!m_Grounded) {
			gameObject.transform.parent = null;
		}

        m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }


    public void Move(float move, bool doCrouch, bool doJump)
    {
        /* if doCrouch is set to true then I have been asked to crouch (i.e. the player has pressed the
         * 'crouch' key). But is doCrouch is false then my Hero needs to be standing up. 
         * 
         * If doCrouch is false but I am currently crouching then lets check to see if I can stand up i.e.
         * there is not a platfrom over my head. If there is then set doCrouch to true so that the Hero stays
         * crouching.
         * 
         * To determine if I am currently crouching I am going to get the bool property called "Crouch" off
         * the animator as it is set to true whenever I am crouching.
         */
		bool currentlyCrouching = m_Anim.GetBool ("Crouch");

		if (doCrouch == false && currentlyCrouching)
        {
			// ok, I am crouching but the player wants me to stand up (i.e. they are not pressing the 'crouch'
			// key. Let's see if I can i.e. there is nothing over my head.

            /*
             * Below is coded two solutions to how to figure out if a platform is over the head of the Character/Hero
             * 
             * The first one uses Physics2D.OverlapCircle which checks to see if a collider (for example the Box Collider
             * 2D component around a platform), on a specified Layer, is within a circular area. The specified Layer is
             * stored in the variable m_WhatIsGround which is set via the Inspector to "Ground". All platforms are in 
             * this layer.
             * 
             * The second solution uses a variable that is set when a child object, called CeilingCheckCollider, trigger
             * enters the collider of a platform. When this happens the variable platformOverhead is set to true.
             * 
             */

			/*
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
				doCrouch = true;
            }
            */

			if (platformOverhead == true) {
				doCrouch = true;
			}

        }

        // Set whether or not the character is crouching in the animator
		m_Anim.SetBool("Crouch", doCrouch);

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
			move = (doCrouch ? move*m_CrouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
			m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
		if (m_Grounded && doJump && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


	/*
	 * The following two methods are called by the child object CeilingCheckCollider
	 */

	public void OnChildTriggerEnter2D(ChildTriggerController childTrigger, Collider2D other) {

		Debug.Log ("OnChildTriggerEnter2D: " + childTrigger.name + " collided with " + other.tag);

		if (childTrigger.name == "CeilingCheckCollider") {
			
			if (other.tag == "Platform") {
				platformOverhead = true;
			}
		}
	}


	public void OnChildTriggerExit2D(ChildTriggerController childTrigger, Collider2D other) {

		Debug.Log ("OnChildTriggerExit2D: " + childTrigger.name + " collided with " + other.tag);

		if (childTrigger.name == "CeilingCheckCollider") {

			if (other.tag == "Platform") {
				platformOverhead = false;
			}
		}
	}
}
