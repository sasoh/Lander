using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	//public
	[Range(0.0f, 10.0f)]
	public float speedRotation = 1.0f;

	[Range(0.0f, 10.0f)]
	public float speedThrust = 1.0f;

	[Range(0.0f, 10.0f)]
	public float maximumSpeedVertical = 4.0f;

	[Range(0.0f, 1.0f)]
	public float maximumSpeedRotation = 1.0f;

	public bool isOnComplexGravityLevel = true;

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

			SetThrustParticleSystemStatus(true);
		}
		else
		{
			thrust = 0.0f;

			SetThrustParticleSystemStatus(false);
		}

		moveHorizontal = Input.GetAxis("Horizontal");

	}

	void UpdateMovement()
	{

		Rigidbody2D rigid2d = this.GetComponent<Rigidbody2D>();

		// apply thrust
		float thrustFactor = thrust * speedThrust;
		Vector3 thrustForce = transform.up;
		thrustForce *= thrustFactor;
		rigid2d.AddForce(thrustForce);

		// apply rotation
		if (isOnComplexGravityLevel == true)
		{

			if (isOnComplexGravityLevel == true && 1.0f - Mathf.Abs(moveHorizontal) < 0.001f)
			{

				// rotate in given direction
				float torqueForce = moveHorizontal * speedRotation;
				torqueForce = Mathf.Clamp(torqueForce, -maximumSpeedRotation, maximumSpeedRotation);
				rigid2d.AddTorque(-torqueForce);
			}
		}
		else
		{
			// move in given direction
			Vector2 rotationForce = new Vector2(moveHorizontal * speedRotation, 0.0f);
			rotationForce.x = Mathf.Clamp(rotationForce.x, -maximumSpeedVertical, maximumSpeedVertical);
			rigid2d.AddForce(rotationForce);
		}

	}

	void SetThrustParticleSystemStatus(bool status)
	{
		
		PlayerParticleSystemHelperScript particleController = GetComponent<PlayerParticleSystemHelperScript>();
		particleController.SetParticleTrailStatus(status);

	}

}
