using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	[Range(0.0f, 100.0f)]
	public float speed;

	[Range(0.0f, 10.0f)]
	public float maximumSpeedHorizontal = 4.0f;
	
	[Range(0.0f, 10.0f)]
	public float maximumSpeedVertical = 4.0f;

	private float moveHorizontal = 0.0f;
	private float moveVertical = 0.0f;

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

		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");

	}

	void UpdateMovement()
	{

		Vector2 movementDirection = new Vector2(moveHorizontal, moveVertical);
		Rigidbody2D rBody = this.GetComponent<Rigidbody2D>();
		rBody.AddForce(movementDirection * speed);

		Vector2 velocity = rBody.velocity;
		velocity.x = Mathf.Clamp(velocity.x, -100.0f, maximumSpeedHorizontal);
		velocity.y = Mathf.Clamp(velocity.y, -100.0f, maximumSpeedVertical);
		rBody.velocity = velocity;

	}

}
