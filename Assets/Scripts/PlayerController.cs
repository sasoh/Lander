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

	void Start()
	{

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
		if (Input.GetButton("Fire1") == true)
		{
			thrust = 1.0f;

			SetThrustVisualsVisible(true);
		}
		else
		{
			thrust = 0.0f;

			SetThrustVisualsVisible(false);
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


	void SetThrustVisualsVisible(bool status)
	{

		print("Thrust visuals visible: " + status);

	}

}
