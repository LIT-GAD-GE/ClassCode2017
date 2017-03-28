
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControler : MonoBehaviour
{
	/* 
	 * All public variables can be accessed by other scripts and via the inspector
	 */
	public float maxSpeed = 10f;
	public float jumpforce = 700f;
	public Transform groundcheck;
	public LayerMask whatIsGround;

	/*
	 * All private variables can only be accessed in this script.
	 */
	private bool facingRight = true;
	private float move;
	private Animator anim;
	private Rigidbody2D rb;
	private bool grounded = false;
	private float groundRadious = 0.2f;

	/*
	 * Variables that have the [SerializeField] attribute before can be accessed via the
	 * inspector. 
	 */
	[SerializeField] private bool platformOverhead;
	[SerializeField] private bool canMoveInAir;

	void Awake ()
	{

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

	}


	void FixedUpdate ()
	{

		// Let's assume I am not grounded
		grounded = false;

		/*
		 * Physics2D.OverlapCircle returns true is any collider falls within the specified circle
		 * and is on the specified layer.
		 * 
		 * Physics2D.OverlapCircleAll will return the list of all colliders that fall within the
		 * specified circle and are on the specified layer. This is the function I am going to use
		 * because it is not enough for me to simply know a collider is within my circle, I actually
		 * need to get the game object that collider belongs to and check to see if it is
		 * a moving platform because if it is I want to make the "Hero" a child of the platform.
		 * 
		 * I declare an array variable called listOfColliders that can hold an array of Collider2D
		 * objects. When I declare an array I am not actually creating the array, I am creating a
		 * variable that can hold an array. The array is actually created by Physics2D.OverlapCircleAll
		 * function which returns the array to me and then I save in the listOfColliders variable.
		 * 
		 * Notice too that I am calling the function OverlapCircleAll on the Class Physics2D. Usually 
		 * you call functions on Objects and not on Classes. 
		 * 
		 * Remember a Class is like a design for a house and an Object is like a house you built from 
		 * that design. So an Object is built using a Class (as its desing). Just like you can have 
		 * many houses built from the same design, you can have many Objects created from the same 
		 * Class. All the houses build from the same design have the same properties and functions 
		 * but the values of the properties can be different. Every house, for example, has an address 
		 * property but the values of this property will be different for every house. Every house may 
		 * have a property to indicate whether the front door is open or not but, again, the value of this 
		 * property may be different for different houses. 
		 * 
		 * A Class defines the properties and functions every object created from the Class will have but 
		 * the values of the properties on the different Objects can be different.
		 * 
		 * What functions do are generally dependent on the value of the Objects properties. For example,
		 * if all House Objects had a function howFarAreYouFromLITClonmel, what the function returns would
		 * depend on the value of the address property of that particular object. Even though all house
		 * Objects were built using the same House Class (design), and as such all houses have the same properties
		 * and functions, the value returned by each houses' howFarAreYouFromLITClonmel function would be
		 * different. It doesn't make sense to ask the House Class howFarAreYouFromLITClonmel, it only makes
		 * sense for you to ask the house Objects. The only time it would make sense to 
		 * ask the Class anything, i.e. call a function on the Class, is if the answer was not dependent
		 * on the values of any of the Object properties. Calling the function howFarAreYouFromLITClonmel on the
		 * House Class wont work because the value is dependent on the value of the address property which is
		 * only set when you create a House Object. On the other hand, if there was a function called 
		 * whoDesignedYou then it would make sense if you could call this on the House Class as the answer
		 * doesn't depend on any Object properties (the answer is the same for every house Object built using
		 * the same Class). 
		 * 
		 * Using the Physics2D class you can create many Physics2D objects:
		 * 		Physics2D obj1 = new Physics2D();
		 * 		Physics2D obj2 = new Physics2D();
		 * 		Physics2D obj3 = new Physics2D();
		 * 
		 * However Physics2D is a strange type of class as none of its functions depend on the value of
		 * Object properties. As such, the programmers who wrote the Physics2D class did so in such a
		 * way so as to allow us to call all the functions on the Physics2D class (btw, they did this by
		 * making the functions static).
		 * 
		 * This is great, because now if I want to call OverlapCircleAll I don't have to (but I could) do:
		 * 		Physics2D myPhysics2DObject = new Physics2D();
		 * 		
		 * 		myPhysics2DObject.OverlapCircleAll(......);
		 * 
		 * instead I can just go:
		 * 
		 * 		Physics2D.OverlapCircleAll(.....)
		 */

		Collider2D[] listOfColliders;
		listOfColliders = Physics2D.OverlapCircleAll (groundcheck.position, groundRadious, whatIsGround);

		/*
		 *	If the list is not empty then I know I am grounded as there is at least 1 collider within the
		 *	circle who is on the whatIsGround layer.
		 */
		if (listOfColliders.Length > 0) {
			grounded = true;
		}
		 
		/* 
		 * Now I am going to loop through the listOfColliders and see if any of them are tagged
         * movingPlatform.
         */

		for (int i=0; i < listOfColliders.Length; i++) {
			if (listOfColliders [i].gameObject.tag == "movingPlatform") {

				// Set the parent of this gameObject (the Hero) transform to be the transform
				// of the gameObject of the i'th Collider2D in the array
				gameObject.transform.parent = listOfColliders [i].gameObject.transform;
			}
		}

		/*
		 * If I am not grounded, or no longer grounded, then make sure I have no parent
		 */
		if (!grounded) {
			gameObject.transform.parent = null;
		}

		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rb.velocity.y);
	}

	public void Move(float hAxisValue, bool doJump, bool doDuck) {

		// The character can only move if grounded OR canMoveInAir is true
		if (grounded || canMoveInAir) {
			
			// Let's make sure we are facing the right way
			if (hAxisValue > 0 && !facingRight) {
				Flip ();
			} else if (hAxisValue < 0 && facingRight) {
				Flip ();
			}

			// Create a variable that I will multiple speed by. By default this variable is
			// set to 1 so multiplying it by speed will have no effect. However, if I am
			// ducking I will set this variable to 0.33 so that my speed will be one third
			// of what it normally is.
			float duckSpeedMultiplier = 1.0f;

			// You can only duck if grounded
			if (grounded) {
				if (!doDuck && anim.GetBool ("Crouch") && platformOverhead) {
					doDuck = true;
				}

				// Trigger the crouch/duck animation
				anim.SetBool ("Crouch", doDuck);

				if (doDuck) {
					duckSpeedMultiplier = 0.33f;
				}
			}

			anim.SetFloat ("Speed", Mathf.Abs (hAxisValue));
			rb.velocity = new Vector2 (hAxisValue * maxSpeed * duckSpeedMultiplier, rb.velocity.y); 
		}

		if (grounded && doJump) {
			grounded = false;
			anim.SetBool ("Ground", false);
			rb.AddForce (new Vector2 (0f, jumpforce));
		}
			

	}
		

	void Flip ()
	{
		//saying facingright is equal to not facingright (we are facing the oppisit direction)
		facingRight = !facingRight;
		//Get the local scale
		Vector3 theScale = transform.localScale;
		//flip the x axis
		theScale.x *= -1;
		//apply it back to the local scale
		transform.localScale = theScale;
		//all together taking the world and fliping it 180 degrees
	}

	public void setCanMoveInAir(bool value) {
		canMoveInAir = value;
	}

	/*
	 * The following two methods are called by the child object CeilingCheckCollider
	 */

	public void OnChildTriggerEnter2D(ChildTriggerController childTrigger, Collider2D other) {

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
