using UnityEngine;
using System.Collections;

public class MovementController: MonoBehaviour {
	private bool left, right;
	private Rigidbody2D theRigidBody;
	public float xSpeed;

	// Use this for initialization
	void Start() 
	{
		left = right = false;
		theRigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() 
	{
		left = Input.GetKey(KeyCode.LeftArrow);
		right = Input.GetKey(KeyCode.RightArrow);
	}

	void FixedUpdate()
	{
		if (left)
		{
			theRigidBody.velocity = new Vector2(-xSpeed, 0);
		}

		if (right)
		{
			theRigidBody.velocity = new Vector2(xSpeed, 0);
		}

	}



	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("In collision");
	}
}