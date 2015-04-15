using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	// public
	[Range(0.0f, 20.0f)]
	public float speedHorizontal = 1.0f;

	[Range(0.0f, 20.0f)]
	public float speedThrust = 1.0f;

	[Range(0.0f, 10.0f)]
	public float maximumThrust = 4.0f;

	[Range(0.0f, 10.0f)]
	public float maximumHorizontal = 4.0f;

	// private
	private float moveHorizontal = 0.0f;
	private float thrust = 0.0f;

	private GameObject cargoObject;

	void Start()
	{

		cargoObject = null;

	}

	void Update()
	{

		ProcessInput();

	}

	void FixedUpdate()
	{

		UpdateMovement();

	}

	void ProcessInput()
	{

		// thrust controlled with fire 1
		thrust = 0.0f;
		if (Input.GetButton("Fire1") == true || Input.GetKey(KeyCode.UpArrow) == true)
		{
			thrust = 1.0f;
		}

		moveHorizontal = Input.GetAxis("Horizontal");

	}

	void UpdateMovement()
	{

		Rigidbody2D rigid2d = this.GetComponent<Rigidbody2D>();

		// apply thrust
		Vector2 thrustForce = new Vector2(0.0f, thrust * speedThrust);
		rigid2d.AddForce(thrustForce);

		// move in given direction
		Vector2 horizontalForce = new Vector2(moveHorizontal * speedHorizontal, 0.0f);
		rigid2d.AddForce(horizontalForce);

		// velocity restriction
		Vector2 velocity = rigid2d.velocity;
		velocity.x = Mathf.Clamp(velocity.x, -maximumHorizontal, maximumHorizontal);
		velocity.y = Mathf.Clamp(velocity.y, -100.0f, maximumThrust);
		rigid2d.velocity = velocity;

	}


	void OnTriggerEnter2D(Collider2D otherObj)
	{

		if (cargoObject == null)
		{
		
			if (otherObj.gameObject.tag == "Cargo")
			{
		
				PickupCargo(otherObj.gameObject);
		
			}
		
		}

	}

	void OnTriggerExit2D(Collider2D otherObj)
	{

	}

	void PickupCargo(GameObject cargo)
	{

		if (cargo != null)
		{

			cargoObject = cargo;

			Rigidbody2D cargoRigid2d = cargoObject.GetComponent<Rigidbody2D>();
			cargoRigid2d.isKinematic = true;

		}

	}

	void DropCargo()
	{

		// remove kinematic flag
		if (cargoObject != null)
		{

			Rigidbody2D cargoRigid2d = cargoObject.GetComponent<Rigidbody2D>();
			cargoRigid2d.isKinematic = false;

		}

		cargoObject = null;

	}
}
