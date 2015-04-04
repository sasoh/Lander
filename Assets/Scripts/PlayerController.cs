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

		// apply movement force
		Vector2 movementDirection = new Vector2(moveHorizontal, moveVertical);
		Rigidbody2D rBody = this.GetComponent<Rigidbody2D>();
		//rBody.AddForce(movementDirection * speed);

		Vector2 newForce = movementDirection * speed;
		// limit force
		newForce.x = Mathf.Clamp(newForce.x, -maximumSpeedHorizontal, maximumSpeedHorizontal);
		newForce.y = Mathf.Clamp(newForce.y, -maximumSpeedVertical, maximumSpeedVertical);

		rBody.AddForce(newForce);


		
	}

}
