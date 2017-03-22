using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	public float maxSpeed = 6f;
	bool facingRight = true;
	float move;
	Animator anim;
	Rigidbody2D rb;




	// Use this for initialization
	void Awake () {
		
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		anim.SetFloat ("hspeed", Mathf.Abs (rb.velocity.x));
	


		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();



		move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y); 

	}


	void Flip () {

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;

	}
}



