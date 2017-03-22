
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControler : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool Dodge;
	bool attack;
	float move;
	Animator anim;
	Rigidbody2D rb;


	public float jumpforce = 700f;
	bool grounded = false;
	public Transform groundcheck;
	float groundRadious = 0.2f;
	public LayerMask whatIsGround;


	void Awake () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundcheck.position, groundRadious, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vspeed", rb.velocity.y);




	
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();


		move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y); 


	
		Dodge = Input.GetButton ("Fire1");

		if (Dodge == true) {
			anim.SetBool ("Duck", true);
		} else if (Dodge == false) {
			anim.SetBool ("Duck", false);
		} 


			   
		attack = Input.GetButtonDown ("Fire2");

		if (attack == true && Dodge == false && grounded == true && move == 0 && facingRight == true) {
			rb.AddForce (new Vector2 (100, 0), ForceMode2D.Impulse);
			anim.SetBool ("hit", true);
		} else if (attack == true && Dodge == false && grounded == true && move == 0 && !facingRight == true) {
			rb.AddForce (new Vector2 (-100, 0), ForceMode2D.Impulse);
			anim.SetBool ("hit", true);
		} else if (attack == true && Dodge == false && grounded == true && move > 0 && facingRight == true) {
				rb.AddForce (new Vector2 (300,0), ForceMode2D.Impulse);
				anim.SetBool ("hit", true);
		} else if (attack == true && Dodge == false && grounded == true && move < 0  && !facingRight == true) {
			rb.AddForce (new Vector2 (-300, 0), ForceMode2D.Impulse);
			anim.SetBool ("hit", true);
		} else if (attack == false) {
			rb.AddForce (new Vector2 (0, 0), ForceMode2D.Impulse);
			anim.SetBool ("hit", false);
		}

	}

	void Update () {

		if (grounded && Input.GetButtonDown ("Jump"))
			{
				anim.SetBool ("Ground", false);
				rb.AddForce(new Vector2(0, jumpforce));
			}

	}

		void Flip () {
			
			facingRight = !facingRight;
			
			Vector3 theScale = transform.localScale;
			
		theScale.x *= -1;
			
			transform.localScale = theScale;
			
		}


}
