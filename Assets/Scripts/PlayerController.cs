using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	[Range(0.0f, 100.0f)]
	public float speed;

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

	}

}
